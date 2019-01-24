using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage ()
		{
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            // to avoid writing conn.close we use the following code
            /*
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation)) 
            {
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();
                PostListView.ItemsSource = posts; 

            };
            */

            //var posts = await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.user.Id).ToListAsync();
            //MVVM 
            var posts = await Post.Read();
            PostListView.ItemsSource = posts;
            
        }

    }


}