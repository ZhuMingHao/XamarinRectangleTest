using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinRectangleTest
{
    public class MyWebView : WebView
    {
        private Action<XamarinRectangle> action;

        public void GetWebViewContent(Action<XamarinRectangle> callback)
        {
            action = callback;
        }

        public void InvokeAction(XamarinRectangle res)
        {
            if (action == null || res == null)
            {
                return;
            }
            action.Invoke(res);
        }

        public XamarinRectangle rectangle { get; set; }

        public static readonly BindableProperty IDProperty = BindableProperty.Create(
    propertyName: "ID",
    returnType: typeof(string),
    declaringType: typeof(MyWebView),
    defaultValue: default(string));

        public string ID
        {
            get { return (string)GetValue(IDProperty); }
            set { SetValue(IDProperty, value); }
        }

    }
}
