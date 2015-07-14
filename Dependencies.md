There are a number of external libraries that Mono.Xna requires to be installed in order to run.  These include:

### Windows ###
All of the Windows binaries for these packages are available in the latest [Tao](Tao.md) package.
  * [OpenGL](OpenGL.md) - `opengl32.dll`
  * [SDL\_NET](SDL_NET.md) - `sdl.dll, sdl_mixer.dll`
  * [DevIL](DevIL.md) - `devil.dll, ilu.dll, ilut.dll`

### Linux ###
For Debian and Debian-like distro you should have these packages installed :
  * `libdevil1c2`
  * `libsdl1.2debian`
  * `libsdl-image1.2`
  * `libsdl-mixer1.2`
  * `libsdl-ttf2.0-0`
  * `libgl1-mesa-glx` and `libglu1-mesa`, or you graphics card's vendor drivers (recommended for proper rendering)

Also make sure that each .dll.config files have good values and are in the same directory that the Mono.Xna's assemblies (that is .dll files).

### Mac ###
{{Stub}}



