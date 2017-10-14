using System;
using PuzzlersJordan.CustomControls;
using PuzzlersJordan.iOS.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyEditor), typeof(MyEditorRenderer))]
namespace PuzzlersJordan.iOS.CustomRenderers
{
    public class MyEditorRenderer: EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Layer.CornerRadius = 4;
                Control.Layer.BorderColor = Color.LightGray.ToCGColor();
                Control.Layer.BorderWidth = 1;
            }
        }
    }
}
