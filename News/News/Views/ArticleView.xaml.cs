using News.Models;
using News.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace News.Views
{
    public partial class ArticleView : ContentPage
    {
        //Here is where you show the news in Full page
        NewsService newsService;

        public ActivityIndicator activityIndicator => activityBar;
        public ArticleView()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            
             base.OnAppearing();

             xHeadLines.Text = $"Todays {Title} Headlines";

             MainThread.BeginInvokeOnMainThread(async () => { await LoadNews(); });
         
        }

        private async Task LoadNews()
        {
            this.activityBar.IsRunning = true;
            await Task.Delay(3000);
            newsService = new NewsService();
            Task<NewsGroup> task = null;
            switch (this.Title)
            {
                case "Business": task = Task.Run(async () => await newsService.GetNewsAsync(NewsCategory.business));
                    await task;
                    break;
                case "Entertainment": task = Task.Run(async () => await newsService.GetNewsAsync(NewsCategory.entertainment));
                    await task;
                    break;
                case "General": task = Task.Run(async () => await newsService.GetNewsAsync(NewsCategory.general));
                    await task;
                    break;
                case "Health": task = Task.Run(async () => await newsService.GetNewsAsync(NewsCategory.health));
                    await task;
                    break;
                case "Science": task = Task.Run(async () => await newsService.GetNewsAsync(NewsCategory.science));
                    await task;
                    break;
                case "Sports": task = Task.Run(async () => await newsService.GetNewsAsync(NewsCategory.sports));
                    await task;
                    break;
                case "Technology": task = Task.Run(async () => await newsService.GetNewsAsync(NewsCategory.technology));
                    await task;
                    break;
                default:
                    break;
            }
            var newsGroup = task.Result;

            var groupedNews = newsGroup.Articles.GroupBy(x => x.DateTime).ToList();

            groupedListView.ItemsSource = groupedNews;
            this.activityBar.IsRunning = false;
        }

        private async void groupedListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            NewsItem item = (NewsItem)e.Item;

            await Navigation.PushAsync(new ArticleFullView(item.Url));
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await LoadNews();
        }


    }
}
