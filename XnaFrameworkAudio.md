See the related [Audio Issue](http://code.google.com/p/monoxna/issues/detail?id=19&can=2&q=) to track the Audio namespace's progress.

# XACT files format #

XACT is Microsoft Cross-Platform Audio Creation Tool. It's a GUI tool to assemble sounds, wave, effect etc... in a project and specify some informations about it like volume, when to trigger the sounds, how to store them etc...

It accepts 3 sounds formats :
  * WAV : should be simple to playback with the new System.Media namespace which is implemented in Mono 1.2.4
  * XMA, a special format based on WMA : I think this will be the hardest to use. SDLMIxer doesn't support this neither FFMpeg (unless it's still readable as WMA).
  * AIFF : seems to be a standard format (http://en.wikipedia.org/wiki/AIFF). Looks like some sort of MIDI container ?

==> I think it's also important to support other sounds format than these. If use FFMpeg (described below) we could load pretty much anything. There would be also some additions on the .xap file format but nothing that would break compatibility.

http://msdn2.microsoft.com/en-us/library/bb172317.aspx

XACT .xap file format is described here : http://msdn2.microsoft.com/en-us/library/bb174774.aspx

The .xap files are processed at compile-time by the Content Pipeline to xwb, xsb and xgs files (XACT Wave Bank, XACT Sound Bank, XACT General Settings). Ideally we could write up the same kind of editor with the possibilities to use any sound format. EDIT: when the xap project is compiled, the audio data in the xwb seems to be only standard PCM data (i.e. not compressed).

# XACT API #

XACT is also an API integrated in DirectSound to manage these file formats both with a high-level and low-level wrapper.

http://msdn2.microsoft.com/en-us/library/bb172328.aspx

I think Microsoft.Xna uses this native API internally as they did with the XBOX Gamepad (using xinput). Then it wouldn't be of too much hassle to do like this on Windows but what about other systems ?

Should we use native call on Windows and somehow make a managed implementation on other systems ? Do like Mono's libgdiplus library, i.e. with write our own native version of xact so that on Windows Mono.Xna uses MS's Xact and on other systems it uses our own (~~could take a look at Wine DirectSound implementation and maybe reuse it~~ apparently there is no implementation of XACT in Wine yet) ?

If we use the managed way, the XACT file parser etc... would be written in managed code and the playback would be assured ~~using either System.Media or P/Invoke into ffmpeg (or other) (maybe make a Tao.FFMpeg ?).~~ using OpenAL for 3D rendering (available in latest XNA) or SDLMixer (for basic "flat" rendering) ~~and FFMpeg (would need a Tao.FFMpeg ?) to retrieve the bare pcm data~~-> as i edited, there is only PCM data in the Wave Banks so no need for FFMPEG at this level.

I found a P/Invoke libray and a small audio player sample which use OpenAL for rendering, it's seem to be perfect for what I want to do but I'm unsure of the licence so I will mail the developper about it. -> http://sourceforge.net/projects/sharpffmpeg/

Antti (Sandriman) also raised concern about the problems Mono.Xna might face on patents by using ffmpeg (or any other thing which can play wma ...). Personally I think there is no problem since most Linux distrib use a stripped down version of ffmpeg to remove things like wma (and mp3 at most), so if we can't load the file beacause there is no codec then we won't play it but IMO users shouldn't be limited. Same thing for the xsb and xwb file format, can we make an encoder for these in the content pipeline ?

# Content of XACT related files #

The first goal is to understand sufficiently these formats to playback simple cue (i.e. cue with contains only default values and reference just one wave file).

## .XWB files, Xact Wave Bank ##

The file consist of a header of variable size with the four letter WBND at the beginning. Then  the data content of each wave file is put after this header without any separation.

~~Each value in the xwb's header seems separated with a combination of 3 zero bytes (\0)~~ It's because the value are represented with a 4 bytes integer. The header contains the name of the Wave bank.

The sub-header for each wave file has a 24 bit size. The corresponding size of the wav file is located in the 13th position.

So far the header is like this :
```
byte {4} - Header (WBND)
int {4} - Version (3)
int {4} - Size of Header 1(40)
int {4} - Size of Header 2(40)
int {4} - Offset to Details Directory (80)
int {4} - Length of Details Directory
int {4} - Offset to Filename Directory (80)
int {4} - Length of Filename Directory
int {4} - First File Offset (8192)
int {4} - Unknown
int16 {2} - Unknown (1)
int16 {2} - Unknown (1)
int {4} - Number of Files
byte {16} - Archive Filename (null) (without Extension)
int {4} - Length Of Each Details Entry (24)
int {4} - Length Of Each Filename Entry (64)
int {4} - Max padding size between each file (2048)
int {4} - null
```

## .XSB files, Xact Sound Bank ##

To see the explanation of Sound banks see the first link of the page.

So far the format is like this :

```
5 bytes : the word "SDBK)"
77 bytes : some sort of header with notably the two bytes at offset 0x11 and 0x1A that represent the number of cue and sound (who is who is unknow ;) ) and the number beginning at offset 0x2A (2 bytes ?) which represent the start offset of the cue's name list 
64 bytes : name of the sound bank
64 bytes : name of the target Wave Bank
starting at 0xD3, foreach cue/sound (?) in the sound bank
  12 bytes subheader where starting at 9th byte is the index (from 1 to ..) of the corresponding wave file in reverse order than the cue list (in form of a 4 byte integer).


...
```


## .XGS files, Xact General Settings ##

The variable name are located at the end of the file separated with a \0 char, ~~properties definition start at offset 0x72 and~~ are so far composed of three float values (4 bytes big-endian) representing in order max value, min value and current value.

The XGS file seems to be comprised of a header that has some information, such as counts and file offsets, after which properties/settings for categories, variables and RPC curves are embedded, in that order. From there, blocks of strings for category and variable names follow (they have some file offsets pointing to specific strings before the actual block of strings). The order of the names correlate to the properties of the earlier blocks.

Here is a more detailed documentation. There are still some unknowns but it is largely mapped out.

```
struct XGS_FILE {
	struct XGS_HEADER	hdr;
	struct XGS_CATEGORY	cats[hdr.cat_count];	// refer to cat strings in same order
	struct XGS_VARIABLE	vars[hdr.var_count];	// refer to var strings in same order
	struct XGS_RPS_CURVE	curves[hdr.rpc_count];
	BYTE			unkn_block1[32];	// no idea what goes on here
	struct XGS_CAT_NAMES	cat_names;
	BYTE			unkn_block2[32];	// ditto
	struct XGS_VAR_NAMES	var_names;
};

struct XGS_HEADER {
	DWORD	magic;			// should be XGSF
	WORD	content_ver;		// either 47 (XACT3 tool) or 45 (XACT2 tool)
	WORD	common_ident;		// unknown, but seems to be 0x002A across all files
					// perhaps the XACT version?
	WORD	unkn_mem1;		// unknown, maybe something to do with the last
					// modified values
	DWORD	last_mod_low;		// lower 32 bits of last modified date
	DWORD	last_mod_high;		// higher 32 bits of last modified date
	BYTE	unkn_mem2;		// unknown, seems to stay 0x03
	WORD	cat_count;		// count of categories
	WORD	var_count;		// count of variables
	WORD	unkn_mem3;		// unknown, seems to always be 0x16
	WORD	unkn_mem4;		// unknown, seems to always be 0x16
	WORD	rpc_count;		// count of runtime parameter control curves
	WORD	dsp_count;		// count of dsp effect presets (only Microsoft Reverbs?)
	WORD	dsp_param_count;	// count of dsp effect params (only 22?)
	DWORD	cat_pos;		// position of first category settings
	DWORD	var_pos;		// position of first variable settings
	DWORD	unkn_pos1;		// unknown, leads to a short with value of 1?
	DWORD	unkn_pos2;		// unknown, leads to another position that leads to cat names?
	DWORD	unkn_pos3;		// unknown, two shorts of values 2 and 3?
	DWORD	unkn_pos4;		// unknown, leads to another position that leads to var names?
	DWORD	cat_name_pos;		// leads to position of first cat name
	DWORD	var_name_pos;		// leads to position of first var name
	DWORD	rpc_pos;		// leads to position of first RPC curve
	DWORD	dsp_pos;		// leads to position of first dsp effect preset
	DWORD	dsp_param_pos		// leads to position of first dsp effect parameters
};

// instance limiting flags
// behaviour flags (reside in upper 5 bits of the byte)
#define FAIL_TO_PLAY 			0x00
#define QUEUE				0x01
#define REPLACE_LOWEST_PRIORITY		0x04
#define REPLACE_OLDEST			0x02
#define REPLACE_QUIETEST		0x03
// cross fade type flags (reside in lower 3 bits of byte)
#define XFADE_LINEAR			0x00
#define XFADE_LOG			0x01
#define XFADE_EQL_POW			0x02

// visibility flags (work like normal flags usually do)
#define BG_MUSIC			0x01
#define PUBLIC				0x02
#define PRIVATE				0x00	// aka the 2 bit is off

struct XGS_CATEGORY {
	BYTE	max_instances;		// maximum number of instances (if 0xFF, then there is no limit)
	WORD	fade_in;		// fixed point (1000 = 1.000) of fade in (in seconds)
	WORD	fade_out;		// fixed point (1000 = 1.000) of fade out (in seconds)
	BYTE	inst_flags;		// flags for instance limiting, refer to consts above
	WORD	unkn_mem1;		// unknown, seems to be 0xFFFF for Default and 0x0000 for everyone else
	BYTE	volume;			// don't know how to intrepert this, but 0xFF is 6.0, 0xB4 is 0.0
					// and 0x00 is -96.0
	BYTE	visibility_flags;	// flags for visibility, refer to  constants above
};

// variable settings flags
#define PUBLIC				0x01	// bit is off for PRIVATE
#define READ_ONLY			0x02	// bit is off for READWRITE
#define CUE_INSTANCE			0x04	// bit is off for GLOBAL
#define RESERVED			0x08

struct XGS_VARIABLE {
	BYTE	flags;			// various flags
	float	init_val;		// the starting value
	float	min_val;		// minimum value
	float	max_val;		// maximum value
};

// parameter constants
#define VOLUME		0x00
#define PITCH		0x01
#define REVERB		0x02	// unsure if 2 is reverb
#define FILTER_FREQ	0x03
#define FILTER_Q_FACTOR	0x04

struct XGS_RPC_CURVE {
	WORD	var_ndx;		// what variable this curve involves
	BYTE	pt_count;		// number of points in the curve
	SHORT	param;			// which parameter the curve affects
					// refer to the above constants
	struct XGS_RPS_POINT[pt_count];	// all the curve points
};

// curve type constants
#define LINEAR		0x00
#define FAST		0x01
#define SLOW		0x02
#define SINCOS		0x03

struct XGS_RPS_POINT {
	float	x;			// the X coordinate of the point
	float	y;			// the y coordinate of the point
	BYTE	type;			// what type of curve its going to be to the next
					// refer to the above constants
};

struct XGS_CAT_NAMES {
	DWORD	offsets[var_count];	// bunch of offsets to specific strings, though commonly
					// separated by 0xFFFF shorts. will doc later
	char	string_block;		// one big block of null terminated strings. 
};

struct XGS_VAR_NAMES {
	DWORD	offsets[var_count];	// bunch of offsets to specific strings, though commonly
					// separated by 0xFFFF shorts. will doc later
	char	string_block;		// one big block of null terminated strings. 
};
```