using System;
using movies.Droid;
using movies.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
namespace movies.Droid
{
	public class CustomMultiLineLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			MultiLineLabel multiLineLabel = (MultiLineLabel)Element;

			if (multiLineLabel != null && multiLineLabel.Lines != -1)
			{
				Control.SetSingleLine(false);
				Control.SetLines(multiLineLabel.Lines);
			}
		}
	}
}
