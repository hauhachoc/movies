using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using movies.Renderer;
using movies.iOS;

[assembly: ExportRenderer(typeof(MultiLineLabel), typeof(CustomMultiLineLabelRenderer))]
namespace movies.iOS
{
	public class CustomMultiLineLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			MultiLineLabel multiLineLabel = (MultiLineLabel)Element;

			if (multiLineLabel != null && multiLineLabel.Lines != -1)
				Control.Lines = multiLineLabel.Lines;
		}
	}
}
