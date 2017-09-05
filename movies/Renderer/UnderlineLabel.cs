using System;
using Xamarin.Forms;

namespace movies.Renderer
{
	public class UnderlineEffect : RoutingEffect
	{
		public const string EffectNamespace = "Example";

		public UnderlineEffect() : base($"{EffectNamespace}.{nameof(UnderlineEffect)}")
		{
		}
	}
}