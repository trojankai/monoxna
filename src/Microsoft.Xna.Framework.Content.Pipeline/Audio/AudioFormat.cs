#region License
/*
MIT License
Copyright © 2009 The Mono.Xna Team

All rights reserved.

Authors: Lars Magnusson (lavima@gmail.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Collections.ObjectModel;

namespace Microsoft.Xna.Framework.Content.Pipeline.Audio
{


    public sealed class AudioFormat
    {
        #region Private Fields
        private int avgBytesPerSec;
        private int bitsPerSample;
        private int blockAlign;
        private int channels;
        private ReadOnlyCollection<byte> formatBufferCollection;
        private int formatTag;
        private byte[] rawFormatBuffer;
        private int sampleRate;
        #endregion

        #region Constructors
        internal AudioFormat()
        {

        }
        #endregion

        #region Properties
        public int AverageBytesPerSecond
        {
            get
            {
                return this.avgBytesPerSec;
            }
        }

        public int BitsPerSample
        {
            get
            {
                return this.bitsPerSample;
            }
        }

        public int BlockAlign
        {
            get
            {
                return this.blockAlign;
            }
        }

        public int ChannelCount
        {
            get
            {
                return this.channels;
            }
        }

        public int Format
        {
            get
            {
                return this.formatTag;
            }
        }

        public ReadOnlyCollection<byte> NativeWaveFormat
        {
            get
            {
                return this.formatBufferCollection;
            }
        }

        public int SampleRate
        {
            get
            {
                return this.sampleRate;
            }
        }
        #endregion
    }
}
