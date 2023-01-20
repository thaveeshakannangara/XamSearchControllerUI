using UITopController.iOS.Platform;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Picker), typeof(CustomPickerRenderer))]

namespace UITopController.iOS.Platform
{
	public class CustomPickerRenderer : PickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);

			if (Control == null || e.NewElement == null)
				return;
			Control.Layer.BorderWidth = 0;
			Control.BorderStyle = UIKit.UITextBorderStyle.None;
			Control.Layer.BorderColor = Color.Transparent.ToCGColor();
			Control.BackgroundColor = Color.Transparent.ToUIColor();
		}
	}
}