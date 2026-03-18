using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for LandingWindow.xaml
    /// </summary>
    public partial class LandingWindow : Window
    {
        public ObservableCollection<Bird> AllBirds = new ObservableCollection<Bird>();

        public LandingWindow()
        {
            InitializeComponent();
        }

        async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string apiKey = "31ichicpcbi7";

            EbirdClient client = new EbirdClient(apiKey);

            string json = await client.GetRecentObservations("IE"); // IE = Ireland


            AllBirds = JsonSerializer.Deserialize<ObservableCollection<Bird>>(json);


            Bird b1 = new Bird() { comName = "Berd", sciName = "Stinky Stinky", howMany = 42, userBird = true };
            AllBirds.Add(b1);

            Bird b2 = new Bird() { comName = "Elsa", sciName = "Frozen Frozen", howMany = 62, userBird = true };
            AllBirds.Add(b2);

            rdAll.IsChecked = true;
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
            Bird jsonBird = lbshowbird.SelectedItem as Bird;

            if (jsonBird != null)
            {
                AllBirds.Remove(jsonBird);
            }
        }

        private void rdAll_Checked(object sender, RoutedEventArgs e)
        {
            lbshowbird.ItemsSource = AllBirds;
        }

        private void rdAPI_Checked(object sender, RoutedEventArgs e)
        {
          
            var query = from b in AllBirds
                        where b.userBird == false
                        select b;
            var resuls = query.ToList();

            lbshowbird.ItemsSource = query.ToList();
            //select birds
            //I want only the entries where the user bird is false 
        }

        private void rdUserMade_Checked(object sender, RoutedEventArgs e)
        {
           
            var query = from b in AllBirds
                        where b.userBird == true
                        select b;
            var resuls = query.ToList();

            lbshowbird.ItemsSource = query.ToList();
            //select birds
            //I want only the entries where the user bird is true 
            // lbshowbird.ItemsSource = AllBirds;

        }

        private void RefreshBird() 
        {
            lbshowbird.ItemsSource = null;
            lbshowbird.ItemsSource = AllBirds;
            lbshowbird.SelectedIndex = AllBirds.Count;
        

        }

        private void ShowBird(string filename) 
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(filename, UriKind.Absolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad; // load fully so file handle is released
            bitmap.EndInit();
            showbird.Source = bitmap; // replace "UploadedImage" with your Image control's x:Name
        }


    }
}
