using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinRectangleTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MyWebView.Navigated += MyWebView_Navigated;
            MyWebView.rectangle = MyWebViewRectangle;
        }

        private void MyWebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
           
        }

        
    }
}
