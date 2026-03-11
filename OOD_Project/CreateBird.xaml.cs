using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    /// Interaction logic for CreateBird2.xaml
    /// </summary>
  

    public partial class CreateBird : Window
    {
        Bird b1 = new Bird();

        public string filename;

        public CreateBird()
        {
            InitializeComponent();
        }

 

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
           

            Create_Pg.Navigate(new Page());
            //this.NavigationService.Navigate(new Uri("Landing_Page.xaml", UriKind.Relative));
        }

        public void btnimg_Click(object sender, RoutedEventArgs e)
        {

            //all done by keith thank you

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select an Image",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.webp|All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string sourceFile = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(sourceFile);

                // Build the Images folder path relative to the exe
                string projectRoot = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
                string imagesFolder = System.IO.Path.Combine(projectRoot, "Images");

                Directory.CreateDirectory(imagesFolder); // creates folder if it doesn't exist

                string destinationFile = System.IO.Path.Combine(imagesFolder, fileName);

                filename=destinationFile;
                try
                {
                    File.Copy(sourceFile, destinationFile, overwrite: true);
                    DisplayImage(destinationFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to upload image: {ex.Message}", "Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }



            }

        }

      

        public void btncreatebird_Click(object sender, RoutedEventArgs e)
        {
            b1.birdImage = filename;
            b1.comName = tbxCommonname.Text;
            b1.sciName = tbxScientificName.Text;
            b1.locName = tbxwhere.Text;
            b1.obsDt = tbxwhen.Text;
            b1.howMany = Convert.ToInt32(tbxhowmany.Text);
            b1.userBird = true;

            //once all data gathered

            LandingWindow landingWindow = this.Owner as LandingWindow;
            landingWindow.AllBirds.Add(b1);
            //save it to the list of birds or the database
            //go back to the previous window

            this.Close();

        }

        public void DisplayImage(string filePath)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(filePath, UriKind.Absolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad; // load fully so file handle is released
            bitmap.EndInit();

        }

    }
}
