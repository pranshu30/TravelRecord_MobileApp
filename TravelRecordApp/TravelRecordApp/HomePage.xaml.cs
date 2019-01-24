using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : TabbedPage
	{
        HomeVM viewModel;

		public HomePage ()
		{
			InitializeComponent ();

            viewModel = new HomeVM();
            //BInding context for entire page
            BindingContext = viewModel;
		}

        private void AddNewTravel_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewTravelPage());
        }
    }
}