//
//  HelloCube.cs
//
//  Author:
//       Jean-Philippe Bruyère <jp.bruyere@hotmail.com>
//
//  Copyright (c) 2016 jp
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
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Crow;

namespace Tests
{
	class UIEditor : OpenTKGameWindow
	{
		[STAThread]
		static void Main ()
		{
			UIEditor win = new UIEditor ();
			win.Run (30);
		}

		public UIEditor ()
			: base(800, 600,"UIEditor")
		{
		}

		protected override void OnLoad (EventArgs e)
		{
			base.OnLoad (e);

			CrowInterface.AddWidget(
				new Window ()
				{
					Title = "Hello World"
				}
			);
		}
		public override void OnRender (FrameEventArgs e)
		{			
			base.OnRender (e);
		}
	}
}