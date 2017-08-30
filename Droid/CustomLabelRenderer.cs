using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Text;
using movies.Droid;

[assembly: ExportRenderer(typeof(Label), typeof(CustomLabelRenderer))]
namespace movies.Droid
{
	public class CustomLabelRenderer : LabelRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				//Control.Ellipsize = TextUtils.TruncateAt.End;
				Control.SetMaxLines(2);
			}
		}
	}
}
