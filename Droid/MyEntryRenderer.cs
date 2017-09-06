using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using movies;
using movies.Droid;
using movies.Renderer;
[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace movies.Droid
{
	public class MyEntryRenderer : EntryRenderer
	{
		//protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		//{
		//	base.OnElementChanged(e);

		//	if (Control != null)
		//	{
  //              Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
		//	}
		//}
	}
}