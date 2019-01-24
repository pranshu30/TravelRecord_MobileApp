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
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();
		}
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            //using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //For SQLite
            //var posttable = conn.Table<Post>().ToList();

            //Azure service in use
            var posttable = await Post.Read();

           var categoriesCount = Post.PostCategories(posttable);
            categoriesListView.ItemsSource = categoriesCount; 
            postLabelCount.Text = posttable.Count.ToString();
           // }
        }
    }
}