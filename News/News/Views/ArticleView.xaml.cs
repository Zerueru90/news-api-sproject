using System.Web;
using Xamarin.Forms;

namespace News.Views
{
    public partial class ArticleView : ContentPage
    {
        //Here is where you show the news in Full page
        public ArticleView()
        {
            InitializeComponent();
         }
        public ArticleView(string Url)
        {
            InitializeComponent();
            BindingContext = new UrlWebViewSource
            {
                Url = HttpUtility.UrlDecode(Url)
            };
        }

        // De enda denna sida måste göra är att ta emot Url strängen och sen även kanske visa en viss titel som i Lektion 19 Övning WebViewsExercisePage



    }
}
