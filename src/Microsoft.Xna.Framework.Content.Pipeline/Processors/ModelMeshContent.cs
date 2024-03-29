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
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace Microsoft.Xna.Framework.Content.Pipeline.Processors
{
	
	
	public sealed class ModelMeshContent
	{
		
#region Properties
		
		public BoundingSphere BoundingSphere 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public IndexCollection IndexBuffer 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public ModelMeshPartContentCollection MeshParts 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public string Name 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public ModelBoneContent ParentBone 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public MeshContent SourceMesh 
		{ 
			get { throw new NotImplementedException(); }
		}
		
		public Object Tag 
		{ 
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}
		
		public VertexBufferContent VertexBuffer 
		{ 
			get { throw new NotImplementedException(); }
		}
		
#endregion
		
	}
}
