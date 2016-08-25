﻿//
//  BmpPicture.cs
//
//  Author:
//       Jean-Philippe Bruyère <jp.bruyere@hotmail.com>
//
//  Copyright (c) 2015 jp
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.IO;
using Cairo;

namespace Crow
{
	public class BmpPicture : Picture
	{
		byte[] image;

		public BmpPicture ()
		{}
		public BmpPicture (string path) : base(path)
		{}
		protected override void loadFromStream (Stream stream)
		{
			using (MemoryStream ms = new MemoryStream ()) {
				stream.CopyTo (ms);
				loadBitmap (new System.Drawing.Bitmap (ms));	
			}
		}

		//load image via System.Drawing.Bitmap, cairo load png only
		void loadBitmap (System.Drawing.Bitmap bitmap)
		{
			if (bitmap == null)
				return;

			System.Drawing.Imaging.BitmapData data = bitmap.LockBits
				(new System.Drawing.Rectangle (0, 0, bitmap.Width, bitmap.Height),
					System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			Dimensions = new Size (bitmap.Width, bitmap.Height);

			int stride = data.Stride;
			int bitmapSize = Math.Abs (data.Stride) * bitmap.Height;

			image = new byte[bitmapSize];
			System.Runtime.InteropServices.Marshal.Copy (data.Scan0, image, 0, bitmapSize);

			bitmap.UnlockBits (data);           
		}

		#region implemented abstract members of Fill

		public override void SetAsSource (Context ctx, Rectangle bounds = default(Rectangle))
		{
			float widthRatio = 1f;
			float heightRatio = 1f;

			if (Scaled){
				widthRatio = (float)bounds.Width / Dimensions.Width;
				heightRatio = (float)bounds.Height / Dimensions.Height;
			}

			if (KeepProportions) {
				if (widthRatio < heightRatio)
					heightRatio = widthRatio;
				else
					widthRatio = heightRatio;
			}

			using (ImageSurface tmp = new ImageSurface (Format.Argb32, bounds.Width, bounds.Height)) {
				using (Cairo.Context gr = new Context (tmp)) {
					gr.Translate (bounds.Left, bounds.Top);
					gr.Scale (widthRatio, heightRatio);
					gr.Translate ((bounds.Width/widthRatio - Dimensions.Width)/2, (bounds.Height/heightRatio - Dimensions.Height)/2);

					using (ImageSurface imgSurf = new ImageSurface (image, Format.Argb32, 
						Dimensions.Width, Dimensions.Height, 4 * Dimensions.Width)) {
						gr.SetSourceSurface (imgSurf, 0,0);
						gr.Paint ();
					}
				}
				ctx.SetSource (tmp);
			}				
		}
		#endregion

		public override void Paint (Cairo.Context gr, Rectangle rect, string subPart = "")
		{
			float widthRatio = 1f;
			float heightRatio = 1f;

			if (Scaled){
				widthRatio = (float)rect.Width / Dimensions.Width;
				heightRatio = (float)rect.Height / Dimensions.Height;
			}

			if (KeepProportions) {
				if (widthRatio < heightRatio)
					heightRatio = widthRatio;
				else
					widthRatio = heightRatio;
			}

			gr.Save ();

			gr.Translate (rect.Left,rect.Top);
			gr.Scale (widthRatio, heightRatio);
			gr.Translate ((rect.Width/widthRatio - Dimensions.Width)/2, (rect.Height/heightRatio - Dimensions.Height)/2);
			
			using (ImageSurface imgSurf = new ImageSurface (image, Format.Argb32, 
				Dimensions.Width, Dimensions.Height, 4 * Dimensions.Width)) {
				gr.SetSourceSurface (imgSurf, 0,0);
				gr.Paint ();
			}
			gr.Restore ();
		}
	}
}

