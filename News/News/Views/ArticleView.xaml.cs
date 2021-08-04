using News.Models;
using News.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace News.Views
{
    public partial class ArticleView : ContentPage
    {
        NewsService newsService;

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
            NewsGroup task = null;

            try
            {
                switch (this.Title)
                {
                    case "Business":
                        task = await newsService.GetNewsAsync(NewsCategory.business);
                        break;
                    case "Entertainment":
                        task = await newsService.GetNewsAsync(NewsCategory.entertainment);
                        break;
                    case "General":
                        task = await newsService.GetNewsAsync(NewsCategory.general);
                        break;
                    case "Health":
                        task = await newsService.GetNewsAsync(NewsCategory.health);
                        break;
                    case "Science":
                        task = await newsService.GetNewsAsync(NewsCategory.science);
                        break;
                    case "Sports":
                        task = await newsService.GetNewsAsync(NewsCategory.sports);
                        break;
                    case "Technology":
                        task = await newsService.GetNewsAsync(NewsCategory.technology);
                        break;
                    default:
                        break;
                }
            }
            catch (WebException ex)
            {
                await DisplayAlert("Error Message", ex.ToString(), "Cancel");
            }
            
            var groupedNews = task.Articles.GroupBy(x => x.DateTime).ToList();
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
