// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Rsvg {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public class Pixbuf {

		[DllImport("rsvg-2")]
		static extern unsafe IntPtr rsvg_pixbuf_from_file(IntPtr file_name, out IntPtr error);

		[Obsolete]
		public static unsafe Gdk.Pixbuf FromFile(string file_name) {
			IntPtr native_file_name = GLib.Marshaller.StringToPtrGStrdup (file_name);
			IntPtr error = IntPtr.Zero;
			IntPtr raw_ret = rsvg_pixbuf_from_file(native_file_name, out error);
			Gdk.Pixbuf ret = GLib.Object.GetObject(raw_ret) as Gdk.Pixbuf;
			GLib.Marshaller.Free (native_file_name);
			if (error != IntPtr.Zero) throw new GLib.GException (error);
			return ret;
		}

		[DllImport("rsvg-2")]
		static extern unsafe IntPtr rsvg_pixbuf_from_file_at_size(IntPtr file_name, int width, int height, out IntPtr error);

		[Obsolete]
		public static unsafe Gdk.Pixbuf FromFileAtSize(string file_name, int width, int height) {
			IntPtr native_file_name = GLib.Marshaller.StringToPtrGStrdup (file_name);
			IntPtr error = IntPtr.Zero;
			IntPtr raw_ret = rsvg_pixbuf_from_file_at_size(native_file_name, width, height, out error);
			Gdk.Pixbuf ret = GLib.Object.GetObject(raw_ret) as Gdk.Pixbuf;
			GLib.Marshaller.Free (native_file_name);
			if (error != IntPtr.Zero) throw new GLib.GException (error);
			return ret;
		}

		[DllImport("rsvg-2")]
		static extern unsafe IntPtr rsvg_pixbuf_from_file_at_zoom(IntPtr file_name, double x_zoom, double y_zoom, out IntPtr error);

		[Obsolete]
		public static unsafe Gdk.Pixbuf FromFileAtZoom(string file_name, double x_zoom, double y_zoom) {
			IntPtr native_file_name = GLib.Marshaller.StringToPtrGStrdup (file_name);
			IntPtr error = IntPtr.Zero;
			IntPtr raw_ret = rsvg_pixbuf_from_file_at_zoom(native_file_name, x_zoom, y_zoom, out error);
			Gdk.Pixbuf ret = GLib.Object.GetObject(raw_ret) as Gdk.Pixbuf;
			GLib.Marshaller.Free (native_file_name);
			if (error != IntPtr.Zero) throw new GLib.GException (error);
			return ret;
		}

		[DllImport("rsvg-2")]
		static extern unsafe IntPtr rsvg_pixbuf_from_file_at_zoom_with_max(IntPtr file_name, double x_zoom, double y_zoom, int max_width, int max_height, out IntPtr error);

		[Obsolete]
		public static unsafe Gdk.Pixbuf FromFileAtZoomWithMax(string file_name, double x_zoom, double y_zoom, int max_width, int max_height) {
			IntPtr native_file_name = GLib.Marshaller.StringToPtrGStrdup (file_name);
			IntPtr error = IntPtr.Zero;
			IntPtr raw_ret = rsvg_pixbuf_from_file_at_zoom_with_max(native_file_name, x_zoom, y_zoom, max_width, max_height, out error);
			Gdk.Pixbuf ret = GLib.Object.GetObject(raw_ret) as Gdk.Pixbuf;
			GLib.Marshaller.Free (native_file_name);
			if (error != IntPtr.Zero) throw new GLib.GException (error);
			return ret;
		}

		[DllImport("rsvg-2")]
		static extern unsafe IntPtr rsvg_pixbuf_from_file_at_max_size(IntPtr file_name, int max_width, int max_height, out IntPtr error);

		[Obsolete]
		public static unsafe Gdk.Pixbuf FromFileAtMaxSize(string file_name, int max_width, int max_height) {
			IntPtr native_file_name = GLib.Marshaller.StringToPtrGStrdup (file_name);
			IntPtr error = IntPtr.Zero;
			IntPtr raw_ret = rsvg_pixbuf_from_file_at_max_size(native_file_name, max_width, max_height, out error);
			Gdk.Pixbuf ret = GLib.Object.GetObject(raw_ret) as Gdk.Pixbuf;
			GLib.Marshaller.Free (native_file_name);
			if (error != IntPtr.Zero) throw new GLib.GException (error);
			return ret;
		}

#endregion
#region Customized extensions
#line 1 "Pixbuf.custom"
// Rsvg.Pixbuf.custom - Rsvg Pixbuf class customizations
//
// Author: John Luke  <jluke@cfl.rr.com>
//
// Copyright (C) 2004 Novell, Inc.
//
// This code is inserted after the automatically generated code.
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of version 2 of the Lesser GNU General
// Public License as published by the Free Software Foundation.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this program; if not, write to the
// Free Software Foundation, Inc., 59 Temple Place - Suite 330,
// Boston, MA 02111-1307, USA.

	public static Gdk.Pixbuf LoadFromResource (string resource)
	{
		if (resource == null)
			throw new ArgumentNullException ("resource");

		System.IO.Stream s = System.Reflection.Assembly.GetCallingAssembly ().GetManifestResourceStream (resource);
		if (s == null)
			throw new ArgumentException ("resource must be a valid resource name of 'assembly'.");

		return LoadFromStream (s);
	}

	public static Gdk.Pixbuf LoadFromStream (System.IO.Stream input)
	{
		Handle loader = new Handle ();
		byte [] buffer = new byte [8192];
		int n;
		while ((n = input.Read (buffer, 0, 8192)) != 0)
			loader.Write (buffer, (uint) n);

		loader.Close ();
		return loader.Pixbuf;
	}

#endregion
	}
}
