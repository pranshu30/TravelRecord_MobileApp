using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

namespace TravelRecordApp.Model
{
    // Providing the travel info, providing history to user about the their travel
    public class Post:INotifyPropertyChanged
    {
        //For Sqlite database only
        // [PrimaryKey, AutoIncrement, NotNull]
        //public int Id { get; set; }

        //[PrimaryKey, AutoIncrement, NotNull]

        private string id;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");

            }
        }


        //public string Id { get; set; }

        //[MaxLength(250)]

        /*public string Experience { get; set; }
        public string VenueName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public int Distance { get; set; }

        //Connect each entry with usPer id defined with Azure servuce

        public string UserId { get; set; }
        */

        private string experience;

        public string Experience
        {
            get { return experience; }
            set {
                experience = value;
                OnPropertyChanged("Experience");
          
            }
        }

        private string venueName;

        public string VenueName
        {
            get { return venueName; }
            set
            {
                venueName = value;
                OnPropertyChanged("VenueName");

            }
        }

        private string categoryid;

        public string CategoryId
        {
            get { return categoryid; }
            set { categoryid = value;
                OnPropertyChanged("CategoryId");
            }
        }

        private string categoryname;

        public string CategoryName
        {
            get { return categoryname; }
            set { categoryname = value;
                OnPropertyChanged("CategoryName");
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set { address = value;
                OnPropertyChanged("Address");
            }
        }

        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value;
                OnPropertyChanged("Latitude");
            }
        }

        private double longitude;

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value;
                OnPropertyChanged("Longitude");
            }
        }

        private int distance;

        public int Distance
        {
            get { return distance; }
            set { distance = value;
                OnPropertyChanged("Distance");
            }
        }

        private string userid;

        public string UserId
        {
            get { return userid; }
            set { userid = value;
                OnPropertyChanged("UserId");
            }
        }


        //Implement Interface
        public event PropertyChangedEventHandler PropertyChanged;

        //Creating MVVM model
        // Create  function for adding data to database
        public static async void Insert(Post post)
        {
            await App.MobileService.GetTable<Post>().InsertAsync(post);
        }

        //MMVM -History Page
        public static async Task<List<Post>> Read()
        {
            var posts = await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.user.Id).ToListAsync();

            return posts;
        }

        //MVVM -Profile Page
        public static Dictionary<string, int> PostCategories(List<Post> posts)
        {
            var categories = (from p in posts
                              orderby p.CategoryId
                              select p.CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
            foreach (var category in categories)
            {
                var count = (from post in posts
                             where post.CategoryName == category
                             select post).ToList().Count;
                //Simply way to write SQL line
                //var count2 = posttable.Where(p => p.categoryname == category).ToList().Count;
                if (category != null)
                {
                    categoriesCount.Add(category, count);
                }
                else
                {
                    categoriesCount.Add("No category specified", count);
                }
            }


            return categoriesCount;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
         }

    }
}
