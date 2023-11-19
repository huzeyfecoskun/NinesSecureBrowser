using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace browser
{
    public class Browser : WebView2
    {
        public int Browser_NewWindowRequested { get; }

        delegate void NavigationCompletedEventHandler(object? sender, CoreWebView2NavigationCompletedEventArgs e);
        event NavigationCompletedEventHandler NavCompleted;
        public Browser(string Url = "https://www.google.com.tr")
        {
            Source = new Uri(Url);
            Dock = DockStyle.Fill;

            NavCompleted += Browser_NavigationCompleted;
        }

        private void Browser_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
