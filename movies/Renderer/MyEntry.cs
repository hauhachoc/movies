﻿using System;
using Xamarin.Forms;

namespace movies.Renderer
{
    public class MyEntry: Entry
    {
		public static readonly BindableProperty BorderColorProperty =
			BindableProperty.Create<MyEntry, Color>(p => p.BorderColor, Color.Black);

		public Color BorderColor
		{
			get { return (Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}

		public static readonly BindableProperty FontSizeProperty =
			BindableProperty.Create<MyEntry, double>(p => p.FontSize, Font.Default.FontSize);

		public double FontSize
		{
			get { return (double)GetValue(FontSizeProperty); }
			set { SetValue(FontSizeProperty, value); }
		}

		public static readonly BindableProperty PlaceholderColorProperty =
			BindableProperty.Create<MyEntry, Color>(p => p.PlaceholderColor, Color.Default);

		public Color PlaceholderColor
		{
			get { return (Color)GetValue(PlaceholderColorProperty); }
			set { SetValue(PlaceholderColorProperty, value); }
		}

	}
}
