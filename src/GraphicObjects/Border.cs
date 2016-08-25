﻿using System;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Diagnostics;

namespace Crow
{
	public class Border : Container
	{
		#region CTOR
		public Border () : base(){}
		#endregion

		#region private fields
		int _borderWidth;
		#endregion

		#region public properties
		[XmlAttributeAttribute()][DefaultValue(1)]
		public virtual int BorderWidth {
			get { return _borderWidth; }
			set {
				_borderWidth = value;
				RegisterForGraphicUpdate ();
			}
		}
		#endregion

		#region GraphicObject override
		[XmlIgnore]public override Rectangle ClientRectangle {
			get {
				Rectangle cb = base.ClientRectangle;
				cb.Inflate (- BorderWidth);
				return cb;
			}
		}

		protected override int measureRawSize (LayoutingType lt)
		{
			int tmp = base.measureRawSize (lt);
			return tmp < 0 ? tmp : tmp + 2 * BorderWidth;
		}
		protected override void onDraw (Cairo.Context gr)
		{
			Rectangle rBack = new Rectangle (Slot.Size);

			//rBack.Inflate (-Margin);
//			if (BorderWidth > 0) 
//				rBack.Inflate (-BorderWidth / 2);			

			Background.SetAsSource (gr, rBack);
			CairoHelpers.CairoRectangle(gr, rBack, CornerRadius);
			gr.Fill ();

			if (BorderWidth > 0) {				
				Foreground.SetAsSource (gr, rBack);
				CairoHelpers.CairoRectangle(gr, rBack, CornerRadius, BorderWidth);
			}

			gr.Save ();
			if (ClipToClientRect) {
				//clip to client zone
				CairoHelpers.CairoRectangle (gr, ClientRectangle,Math.Max(0.0, CornerRadius-Margin));
				gr.Clip ();
			}

			if (child != null)
				child.Paint (ref gr);
			gr.Restore ();
		}		
		#endregion
	}
}

