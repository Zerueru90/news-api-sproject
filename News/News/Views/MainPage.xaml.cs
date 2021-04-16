using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using News.Models; 

namespace News.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
 
    public partial class MainPage : TabbedPage
    {

        public MainPage()
        {
            InitializeComponent();
            this.Children.Add(new ArticleView() { Title = "Business" });
            this.Children.Add(new ArticleView() { Title = "Entertainment" });
            this.Children.Add(new ArticleView() { Title = "General" });
            this.Children.Add(new ArticleView() { Title = "Health" });
            this.Children.Add(new ArticleView() { Title = "Science" });
            this.Children.Add(new ArticleView() { Title = "Sports" });
            this.Children.Add(new ArticleView() { Title = "Technology" });

            
        }
    }
}