using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
        //vars and bits for the program

        public string filename;

        string insertnum;
        BirdData db = new BirdData();




        public CreateBird()
        {
            InitializeComponent();


        }


        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            //returns to bird viewing window
            this.Close();

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

                filename = destinationFile;
                try
                {
                    File.Copy(sourceFile, destinationFile, overwrite: true);

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
            //create new bird object
            Bird newBird = new Bird();

            //check that fields are all filled
            #region validation
            if (string.IsNullOrEmpty(tbxCommonname.Text) || string.IsNullOrEmpty(tbxScientificName.Text) || string.IsNullOrEmpty(tbxwhere.Text) || string.IsNullOrEmpty(tbxwhen.Text))
            {
                throw new Exception("The field can't be empty");
            }

            if (string.IsNullOrEmpty(tbxhowmany.Text))
            {
                throw new Exception("The number field can't be empty");

            }


            else
            {
                insertnum = tbxhowmany.Text;
                if (int.TryParse(insertnum, out int result))
                {

                    if (result <= 0)
                    {
                        throw new Exception("Enter a numeric value greater than 0");
                    }

                }
                else
                {
                    throw new Exception("Enter a numeric value");
                }


            }
            #endregion validation

            //add info entered to the newBird object
            newBird.birdImage = filename;
            newBird.comName = tbxCommonname.Text;
            newBird.sciName = tbxScientificName.Text;
            newBird.locName = tbxwhere.Text;
            newBird.obsDt = tbxwhen.Text;
            newBird.howMany = Convert.ToInt32(tbxhowmany.Text);
            //implement check here that sees if the thing can be an int.
            newBird.userBird = true;

            //add to database table
            db.Birds.Add(newBird);

            //save changes to database
            db.SaveChanges();

            //go back to the previous window
            LandingWindow landingWindow = this.Owner as LandingWindow;

            this.Close();
        }

        private void tbxCommonname_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearText(sender, e);
        }

        private void tbxScientificName_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearText(sender,e);
        }

        private void tbxwhere_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearText(sender, e);
        }

        private void tbxwhen_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearText(sender, e);
        }

        private void tbxhowmany_GotFocus(object sender, RoutedEventArgs e)
        {
            ClearText(sender, e);
        }

        static void ClearText(object sender,RoutedEventArgs e) 
        {
            // Source - https://stackoverflow.com/a/6972726
            // Posted by Donut
            // Retrieved 2026-04-15, License - CC BY-SA 3.0
            //clears the box 
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= ClearText;
        }
    }
}

