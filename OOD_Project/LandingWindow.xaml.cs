using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media.Imaging;

namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for LandingWindow.xaml
    /// </summary>
    public partial class LandingWindow : Window
    {
        public ObservableCollection<Bird> AllBirds = new ObservableCollection<Bird>();

        private BirdData db;

        public LandingWindow()
        {
            InitializeComponent();
        }

        void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //string apiKey = "31ichicpcbi7";

            //EbirdClient client = new EbirdClient(apiKey);

            //string json = await client.GetRecentObservations("IE"); // IE = Ireland


            //AllBirds = JsonSerializer.Deserialize<ObservableCollection<Bird>>(json);


            //Bird b1 = new Bird() { speciesCode = "yee yee", comName = "Berd", sciName = "Stinky Stinky", howMany = 42, userBird = true, birdImage = @"C:\Users\EwaBender-STUDENT\Source\Repos\OOD_Project\OOD_Project\Images\kittuh.png" };
            //AllBirds.Add(b1);

            //Bird b2 = new Bird() { speciesCode = "what what", comName = "Elsa", sciName = "Frozen Frozen", howMany = 62, userBird = true, birdImage = @"C:\\Users\\EwaBender-STUDENT\\Source\\Repos\\OOD_Project\\OOD_Project\\Images\\OIP.jpg" };
            //AllBirds.Add(b2);

            db = new BirdData();

            var query = from b in db.Birds
                        select b;
            
            var sorted = query.OrderBy(b => b.comName).ToList();

            lbshowbird.ItemsSource = sorted;

            rdAll.IsChecked = true;

            imgshowbird.Source = new BitmapImage(new Uri(@"C:\\Users\\EwaBender-STUDENT\\Source\\Repos\\OOD_Project\\OOD_Project\\Images\\berd.png", UriKind.Absolute));
        }
        //Display certain properties
        private void lbshowbird_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //selects the birds object 
            Bird Bird = lbshowbird.SelectedItem as Bird;

            //if the thing ain't null 
            if (Bird != null)
            {

                //this displays info about the bird
                tbdescribebird.Text = string.Format($"Common Name: {Bird.comName} \nScientific Name: {Bird.sciName} \nLocation: {Bird.locName} \nWhen: {Bird.obsDt} \nHow many: {Bird.howMany}");

                imgshowbird.Source = new BitmapImage(new Uri(@"C:\\Users\\EwaBender-STUDENT\\Source\\Repos\\OOD_Project\\OOD_Project\\Images\\berd.png", UriKind.Absolute));

                if (Bird.userBird == true && ! String.IsNullOrEmpty(Bird.birdImage))
                {
                    imgshowbird.Source = new BitmapImage(new Uri(Bird.birdImage, UriKind.Absolute));
                }
            }

        }

        //implement a functionality when you can move between pages
        private void btncreatebird_Click(object sender, RoutedEventArgs e)
        {

            CreateBird create = new CreateBird();

            create.Owner = this;
            create.ShowDialog();

            //refresh display

            RefreshBird();

            //save it to the list of birds or the database
            //go back to the previous window
        }

        private void btndelbird_Click(object sender, RoutedEventArgs e)
        {
            Bird selectedBird = lbshowbird.SelectedItem as Bird;

            if (selectedBird != null)
            {
                //remove bird from database
                db.Birds.Remove(selectedBird);

                //save changes
                db.SaveChanges();

                //refresh display
                RefreshBird() ;
            }
        }

        private void rdAll_Checked(object sender, RoutedEventArgs e)
        {

            SortBirds();
        }

        private void rdAPI_Checked(object sender, RoutedEventArgs e)
        {

            var query = from b in db.Birds
                        where b.userBird == false
                        select b;
            var resuls = query.ToList();

            var sorted = query.OrderBy(b => b.comName).ToList();
            lbshowbird.ItemsSource = sorted;
            //select birds
            //I want only the entries where the user bird is false 
        }

        private void rdUserMade_Checked(object sender, RoutedEventArgs e)
        {

            var query = from b in db.Birds
                        where b.userBird == true
                        select b;
            var resuls = query.ToList();

            var sorted = query.OrderBy(b => b.comName).ToList();

            lbshowbird.ItemsSource = sorted;
            //select birds
            //I want only the entries where the user bird is true 
            // lbshowbird.ItemsSource = AllBirds;

        }

        private void RefreshBird()
        {
            //figure out what you are currently view - all birds, user birds or json birds

            var query = db.Birds.OrderBy(b => b.comName).ToList();

            if (rdAll.IsChecked == true)
            {

                //display all birds
                lbshowbird.ItemsSource = query;
            }
            else if (rdAPI.IsChecked == true)
            {
                //display api birds
                lbshowbird.ItemsSource = query.Where(b => b.userBird == false).ToList();
            }
            else
            {

                //diplays user birds
                lbshowbird.ItemsSource = query.Where(b => b.userBird == true).ToList();

            }

            lbshowbird.SelectedIndex = 0;

        }

        private void SortBirds()
        {
            var sorted = db.Birds.OrderBy(b => b.comName).ToList();
            lbshowbird.ItemsSource = sorted;
        }
    }
}
