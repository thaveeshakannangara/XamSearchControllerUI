using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using UITopController.CustomRenderers;
using UITopController.Droid.Platform;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]

namespace UITopController.Droid.Platform
{
	public class CustomEntryRenderer : EntryRenderer
	{
		public CustomEntryRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null && e.NewElement != null)
			{
				if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
					Control.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent); //entry.TextColor.ToAndroid()
				else
					Control.Background.SetColorFilter(Android.Graphics.Color.Transparent, PorterDuff.Mode.SrcAtop); //entry.TextColor.ToAndroid()
			}
		}
	}
}