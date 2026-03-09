using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.IO;


namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for Create_Bird.xaml
    /// </summary>
    public partial class Create_Bird : Page
    {
        Bird b1 = new Bird();
        public Create_Bird()
        {

            InitializeComponent();



            string birdname;
            string sciencename;
            string where;
            string when;
            string howmany;


        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            //Source - https://stackoverflow.com/a/20807014
            // Posted by Jake, modified by community. See post 'Timeline' for change history
            // Retrieved 2026-02-11, License - CC BY-SA 4.0

            Create_Pg.Navigate(new Page());
            this.NavigationService.Navigate(new Uri("Landing_Page.xaml", UriKind.Relative));
        }

        private void btnimg_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files (*.bmp; *.png; *.jpg) |*.bmp; *.png; *.jpg";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == true)
            {
                //save the file
                b1.birdImage = openDialog.FileName;
                //shave the img of the path
                string img = System.IO.Path.GetFileName(b1.birdImage);

                //shove into the folder
                string destinationfold = @"C:\Users\EwaBender-STUDENT\Source\Repos\OOD_Project\OOD_Project\Images\";
                //get path to Images folder
                string appfolder = AppDomain.CurrentDomain.BaseDirectory;
                //shaving off the \\bin\\Debug\\
                int found = 0;
                found = appfolder.IndexOf(@"bin\Debug\");
                string path = appfolder.Substring(0, found);
                //combine path w/ img name
                string imgpath = path + img;

                destinationfold += img;
                //move the file 
                File.Copy(b1.birdImage, destinationfold);
            }



        }

        private void tbxCommonname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbxScientificName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbxwhere_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbxwhen_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbxhowmany_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btncreatebird_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
