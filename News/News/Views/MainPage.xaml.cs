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

            newsService = new NewsService();


            //DETTA FUNKAAAAAAAAAAAAAAAAAAR!!!!!!!!!!!!!!!!!
            Task<NewsGroup> task1 = Task.Run(async () => await newsService.GetNewsAsync(NewsCategory.business));
            Task<NewsGroup> task2 = Task.Run(async () => await newsService.GetNewsAsync(NewsCategory.entertainment));
            Task<NewsGroup> task3 = Task.Run(async () => await newsService.GetNewsAsync(NewsCategory.general));
            Task<NewsGroup> task4 = Task.Run(async () => await newsService.GetNewsAsync(NewsCategory.health));
            Task<NewsGroup> task5 = Task.Run(async () => await newsService.GetNewsAsync(NewsCategory.science));
            Task<NewsGroup> task6 = Task.Run(async () => await newsService.GetNewsAsync(NewsCategory.sports));
            Task<NewsGroup> task7 = Task.Run(async () => await newsService.GetNewsAsync(NewsCategory.technology));
            Task.WaitAll(task1, task2, task3, task4, task5, task6, task7);

            //task.Wait();

            var task1returned = task1.Result;
            var task2returned = task2.Result;
            var task3returned = task3.Result;
            var task4returned = task4.Result;
            var task5returned = task5.Result;
            var task6returned = task6.Result;
            var task7returned = task7.Result;

            //var business = new ArticleView(h.Articles.Select(x => x.Url).ToString());
            //var url = task1returned.Articles.Select(x => x.Url).ToList();
            //var business = new ArticleView(h.Articles.Select(x => x.Url).ToString());
            //var test = h.Articles.Select(x => x.Url).FirstOrDefault();

            var url = task1returned.Articles.Select(x => x.Url);
            ArticleView stringTask1 = null;
            foreach (var item in url)
            {
                stringTask1 = new ArticleView(item);
            }
            //var stringTask2 = new ArticleView(/*task2returned*/);
            //var stringTask3 = new ArticleView(/*task3returned*/);
            //var stringTask4 = new ArticleView(/*task4returned*/);
            //var stringTask5 = new ArticleView(/*task5returned*/);
            //var stringTask6 = new ArticleView(/*task6returned*/);
            //var stringTask7 = new ArticleView(/*task7returned*/);

            var testing = new ArticleView("https://www.premierleague.com");
            testing.Title = "Premier League";
            var grouped = task1returned.Articles.OrderBy(x => x.DateTime).GroupBy(x => x.DateTime);
            stringTask1.Title = "Business";
            stringTask1.Something.ItemsSource = grouped;

            //stringTask2.Title = "Entertainment";
            //stringTask3.Title = "General";
            //stringTask4.Title = "Health";
            //stringTask5.Title = "Science";
            //stringTask6.Title = "Sports";
            //stringTask7.Title = "Technology";

            //var grouped = task1returned.Articles.OrderBy(x => x.DateTime).GroupBy(x => x.DateTime);
            //stringTask1.Content = grouped as View;


            this.Children.Add(new AboutPage());
            this.Children.Add(new ConsolePage());
            this.Children.Add(stringTask1);
            //this.Children.Add(stringTask2);
            //this.Children.Add(stringTask3);
            //this.Children.Add(stringTask4);
            //this.Children.Add(stringTask5);
            //this.Children.Add(stringTask6);
            //this.Children.Add(stringTask7);
            this.Children.Add(testing);
            //var grouped = h.Articles.OrderBy(x => x.DateTime).GroupBy(x => x.DateTime);
            //this.ItemsSource = grouped;
        }


        //Här ska man group alla URL och lägga upp dem beroende på category och när ett klick event sker så ska det skickas över till ArticleView.

        

    }
}