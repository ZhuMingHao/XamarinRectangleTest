using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.UWP;
using XamarinRectangleTest.UWP;
using XamarinRectangleTest;
using Windows.UI.Xaml.Shapes;
using Windows.UI;
using Windows.UI.Xaml.Media;

[assembly: ExportRenderer(typeof(XamarinRectangle), typeof(RectangleRenderer))]

namespace XamarinRectangleTest.UWP
{
    public class RectangleRenderer : ViewRenderer<XamarinRectangle, Rectangle>
    {
        public static Rectangle Native;
        protected override void OnElementChanged(ElementChangedEventArgs<XamarinRectangle> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                SetNativeControl(new Rectangle());
                Native = Control;
            }

            if (e.OldElement != null)
            {
                Control.Loaded -= Control_Loaded;
            }

            if (e.NewElement != null)
            {
                Control.Loaded += Control_Loaded;
            }

        }

        private void Control_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var _Rectangle = sender as Windows.UI.Xaml.Shapes.Rectangle;
            _Rectangle.Fill = new SolidColorBrush(Colors.Red);
          
            //_Rectangle.Fill = _Brush;
        }
    }
}
