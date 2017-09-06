using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using movies.iOS;
using movies.Renderer;
using Foundation;
using CoreAnimation;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace movies.iOS
{
	public class MyEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.BorderStyle = UITextBorderStyle.None;

				var view = (Element as MyEntry);
				if (view != null)
				{
					DrawBorder(view);
					SetFontSize(view);
					SetPlaceholderTextColor(view);
				}
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			var view = (MyEntry)Element;

			if (e.PropertyName.Equals(view.BorderColor))
				DrawBorder(view);
			if (e.PropertyName.Equals(view.FontSize))
				SetFontSize(view);
			if (e.PropertyName.Equals(view.PlaceholderColor))
				SetPlaceholderTextColor(view);
		}

		void DrawBorder(MyEntry view)
		{
			var borderLayer = new CALayer();
			borderLayer.MasksToBounds = true;
			borderLayer.Frame = new CoreGraphics.CGRect(0f, Frame.Height / 2, Frame.Width, 0.5f);
            borderLayer.BorderColor = view.BorderColor.ToCGColor();
			borderLayer.BorderWidth = 0.5f;

			Control.Layer.AddSublayer(borderLayer);
			Control.BorderStyle = UITextBorderStyle.None;
		}

		void SetFontSize(MyEntry view)
		{
			if (view.FontSize != Font.Default.FontSize)
				Control.Font = UIFont.SystemFontOfSize((System.nfloat)view.FontSize);
			else if (view.FontSize == Font.Default.FontSize)
				Control.Font = UIFont.SystemFontOfSize(17f);
		}

		void SetPlaceholderTextColor(MyEntry view)
		{
			if (string.IsNullOrEmpty(view.Placeholder) == false && view.PlaceholderColor != Color.Default)
			{
				var placeholderString = new NSAttributedString(view.Placeholder,
											new UIStringAttributes { ForegroundColor = view.PlaceholderColor.ToUIColor() });
				Control.AttributedPlaceholder = placeholderString;
			}
		}
	}
}