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

namespace Microsoft.Xna.Framework.Content.Pipeline.Graphics
{
	
	
	public abstract class TextureContent : ContentItem
	{

		#region Private Fields
		
		private MipmapChainCollection faces;
		
		#endregion Private Fields
		
		#region Constructor
		
		protected TextureContent(MipmapChainCollection faces)
		{
			this.faces = faces;
		}

		#endregion
		
		#region Properties
        
		public MipmapChainCollection Faces { 
			get { throw new NotImplementedException(); }
		}
		
		#endregion
		
		#region Public Methods
		
		public void ConvertBitmapType(Type newBitmapType)
		{
			throw new NotImplementedException();
		}
		
		public virtual void GenerateMipmaps(bool overwriteExistingMipmaps)
		{
			foreach (MipmapChain face in faces)
			{
				if (!overwriteExistingMipmaps && face.Count > 1)
					continue;
				
				
			}
		}
		
		public virtual void Validate()
		{
			throw new NotImplementedException();
		}

		protected void Validate(bool facesMustHaveSameMipCount)
		{
			throw new NotImplementedException();
		}
		
		#endregion
		
	}
}
