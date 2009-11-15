﻿#region License
/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.

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

namespace Microsoft.Xna.Framework.Graphics
{
    
    public class DepthStencilBuffer : IDisposable
    {
        public DepthStencilBuffer(GraphicsDevice graphicsDevice, int width, int height, DepthFormat format){ throw new NotImplementedException(); }
        
        public DepthStencilBuffer(GraphicsDevice graphicsDevice, int width, int height, DepthFormat format, MultiSampleType multiSampleType, int multiSampleQuality){ throw new NotImplementedException(); }

        ~DepthStencilBuffer()
        {
        }

        //public static bool operator !=(DepthStencilBuffer left, DepthStencilBuffer right){ throw new NotImplementedException(); }
        
        //public static bool operator ==(DepthStencilBuffer left, DepthStencilBuffer right){ throw new NotImplementedException(); }

        public DepthFormat Format { get{ throw new NotImplementedException(); } }
        
        public GraphicsDevice GraphicsDevice { get{ throw new NotImplementedException(); } }
        
        public int Height { get{ throw new NotImplementedException(); } }
        
        public bool IsDisposed { get{ throw new NotImplementedException(); } }
        
        public int MultiSampleQuality { get{ throw new NotImplementedException(); } }
        
        public MultiSampleType MultiSampleType { get{ throw new NotImplementedException(); } }
        
        public string Name { get{ throw new NotImplementedException(); } set{ throw new NotImplementedException(); } }
        
        public object Tag { get{ throw new NotImplementedException(); } set{ throw new NotImplementedException(); } }
        
        public int Width { get{ throw new NotImplementedException(); } }

        public bool IsContentLost
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //public event EventHandler Disposing;
        
        public void Dispose(){ throw new NotImplementedException(); }
        
        protected virtual void Dispose(bool disposing){ throw new NotImplementedException(); }
        
        /*public override bool Equals(object obj){ throw new NotImplementedException(); }
        
        public override int GetHashCode(){ throw new NotImplementedException(); }
        
        protected void raise_Disposing(object sender, EventArgs e){ throw new NotImplementedException(); }*/
    }
}
