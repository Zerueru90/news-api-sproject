using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using News.Models; // Fanns innan.. tips..?
using News.Services; // La till själv
using Xamarin.Essentials; // La till själv

namespace News.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
 
    public partial class MainPage : TabbedPage
    {
        List<NewsGroup> newsApis = new List<NewsGroup>(); // För att fånga alla hämtade nyheter och sen kunna skicka vidare till ArticleView
        NewsGroup newsGroup;
        NewsService newsService;

        public MainPage()
        {
            InitializeComponent();

            newsGroup = new NewsGroup();
            newsService = new NewsService();


        }

        //Kan vara att här så hämtar man all data från nätet och sen skickar över det med this.Children.Add men hur ska man få upp alla categorier. Ska man sätta dom själv med string Title i konstruktorn eller kan man använda grouping här för att få upp alla sidor?
        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    //Task<NewsGroup> t1 = null;

        //    //t1 = newsService.GetNewsAsync(NewsCategory.business);

        //    //newsApis.Add(t1.Result);

        //    //MainThread.BeginInvokeOnMainThread(async () => { await LoadNews(); });
        //}

        //private async Task LoadNews()
        //{
        //    //Heare you load the forecast 

        //    Task<NewsGroup> t1 = null, t2 = null, t3 = null, t4 = null, t5 = null, t6 = null, t7 = null;

        //    try
        //    {
        //        t1 = newsService.GetNewsAsync(NewsCategory.business);
        //        t2 = newsService.GetNewsAsync(NewsCategory.entertainment);
        //        t3 = newsService.GetNewsAsync(NewsCategory.general);
        //        t4 = newsService.GetNewsAsync(NewsCategory.health);
        //        t5 = newsService.GetNewsAsync(NewsCategory.science);
        //        t6 = newsService.GetNewsAsync(NewsCategory.sports);
        //        t7 = newsService.GetNewsAsync(NewsCategory.technology);

        //        Task.WaitAll(t1, t2, t3, t4, t5, t6, t7);

        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Error", $"Error message: {ex.Message}", "Cancel");
        //    }

        //    List<NewsGroup> newsApis = new List<NewsGroup>()
        //        {
        //        t1.Result,
        //        t2.Result,
        //        t3.Result,
        //        t4.Result,
        //        t5.Result,
        //        t6.Result,
        //        t7.Result,
        //        };

        //    this.ItemsSource = newsApis.ToList();
        //}
    }
}