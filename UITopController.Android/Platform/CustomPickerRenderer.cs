using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using UITopController.Droid.Platform;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]

namespace UITopController.Droid.Platform
{
	public class CustomPickerRenderer : PickerRenderer
	{
		public CustomPickerRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);
			if (Control == null || e.NewElement == null) return;
			//for example ,change the line to red:
			if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
				Control.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
			else
				Control.Background.SetColorFilter(Android.Graphics.Color.Transparent, PorterDuff.Mode.SrcAtop);
		}
	}
}