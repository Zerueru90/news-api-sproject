using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace News.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticleFullView : ContentPage
    {
        public ArticleFullView(string Url)
        {
            InitializeComponent();

            BindingContext = new UrlWebViewSource
            {
                Url = HttpUtility.UrlDecode(Url)
            };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

        }

        private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {

            this.activityBar.IsRunning = true;
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {

            this.activityBar.IsRunning = false;
        }
    }
}