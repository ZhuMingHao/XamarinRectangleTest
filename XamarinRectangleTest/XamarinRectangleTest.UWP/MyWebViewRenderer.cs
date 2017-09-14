using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.UWP;
using XamarinRectangleTest.UWP;
using XamarinRectangleTest;
using Xamarin.Forms;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

[assembly: ExportRenderer(typeof(MyWebView), typeof(MyWebViewRenderer))]

namespace XamarinRectangleTest.UWP
{
    public class MyWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                SetNativeControl(new Windows.UI.Xaml.Controls.WebView() {});
               
            }
            if (e.OldElement != null)
            {
                Control.NavigationCompleted -= Control_NavigationCompleted;
            }
            if (e.NewElement != null)
            {
                Control.Name = (Element as MyWebView).ID;
                Control.NavigationCompleted += Control_NavigationCompleted;




                


                //if (//Element.rectangle != null)
                //{
                //    //Element.rectangle
                //}

            }

        }

        private async void Control_NavigationCompleted(Windows.UI.Xaml.Controls.WebView sender, Windows.UI.Xaml.Controls.WebViewNavigationCompletedEventArgs args)
        {
            
            var rect = RectangleRenderer.Native;
            var brush = await GetWebViewBrush(sender);
            rect.Fill = brush;

            //    Element.InvokeAction(rect);
        }
        async Task<WebViewBrush> GetWebViewBrush(Windows.UI.Xaml.Controls.WebView webView)
        {
            // resize width to content
            var _OriginalWidth = webView.Width;
            var _WidthString = await webView.InvokeScriptAsync("eval",
                new[] { "document.body.scrollWidth.toString()" });
            int _ContentWidth;

            if (!int.TryParse(_WidthString, out _ContentWidth))
                throw new Exception(string.Format("failure/width:{0}", _WidthString));

            webView.Width = _ContentWidth;

            // resize height to content
            var _OriginalHeight = webView.Height;

            var _HeightString = await webView.InvokeScriptAsync("eval",
                new[] { "document.body.scrollHeight.toString()" });
            int _ContentHeight;

            if (!int.TryParse(_HeightString, out _ContentHeight))
                throw new Exception(string.Format("failure/height:{0}", _HeightString));

            webView.Height = _ContentHeight;

            // create brush
            var _OriginalVisibilty = webView.Visibility;

            webView.Visibility = Windows.UI.Xaml.Visibility.Visible;

            var _Brush = new WebViewBrush
            {
                Stretch = Stretch.Uniform,
                SourceName = webView.Name
            };
          //  _Brush.SetSource(webView);

            _Brush.Redraw();

            // reset, return
            webView.Width = _OriginalWidth;
            webView.Height = _OriginalHeight;
            webView.Visibility = _OriginalVisibilty;
            return _Brush;
        }
    }
}
