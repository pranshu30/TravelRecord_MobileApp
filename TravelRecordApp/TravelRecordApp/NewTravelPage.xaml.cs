using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using SQLite;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewTravelPage : ContentPage
	{
        Post post;
		public NewTravelPage ()
		{
			InitializeComponent ();
            post = new Post();
            containerstacklayout.BindingContext = post;

		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await Venue.GetVenues(position.Latitude, position.Longitude);
            venueListView.ItemsSource = venues;
        }


        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                var selectedVenue = venueListView.SelectedItem as Venue;
                var firstCategory = selectedVenue.categories.FirstOrDefault();

                /*
                 * Binding context
                Post post = new Post()
                */

                //Experience = experienceEntry.Text,
                post.CategoryId = firstCategory.id;
                post.CategoryName = firstCategory.name;
                post.Address = selectedVenue.location.address;
                post.Distance = selectedVenue.location.distance;
                post.Latitude = selectedVenue.location.lat;
                post.Longitude = selectedVenue.location.lng;
                post.VenueName = selectedVenue.name;
                post.UserId = App.user.Id;
               

                /*SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
                 conn.CreateTable<Post>();
                 int rows = conn.Insert(post);
                 conn.Close();

                 if (rows > 0)
                     DisplayAlert("Success", "Experience successfully added", "Ok");
                 else
                     DisplayAlert("Failure", "Experience failed to be added", "Ok");
                 */

                //SQLite connection code

                /*using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Post>();
                    int rows = conn.Insert(post);


                    if (rows > 0)
                        DisplayAlert("Success", "Experience successfully added", "Ok");
                    else
                        DisplayAlert("Failure", "Experience failed to be added", "Ok");
                }
                */

                //Cleaning code for creating MVVM model
                //await App.MobileService.GetTable<Post>().InsertAsync(post);

                //Created Insert function in Post class in model that insert the data in Azure database
                Post.Insert(post);
                await DisplayAlert("Success", "Experience successfully added", "Ok");
            }

            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.ToString(), "ok");
            }

        }
    }
}