using News.Models;
using News.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace News.Views
{
    public partial class AboutPage : ContentPage
    {
        List<NewsGroup> newsApis = new List<NewsGroup>();
        public AboutPage()
        {
            InitializeComponent();
        }
    }
}
