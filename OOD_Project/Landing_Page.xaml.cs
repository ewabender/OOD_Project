using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
//using System.Text.Json;
//using System.Text.Json.Nodes;

//ask keith
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static OOD_Project.Landing_Page;
using Newtonsoft.Json;

namespace OOD_Project
{
    /// <summary>
    /// Interaction logic for Landing_Page.xaml
    /// </summary>
    public partial class Landing_Page : Page
    {
        List<JsonBird> AllBirds = new List<JsonBird>();

        public Landing_Page()
        {
            InitializeComponent();
        }

        //Display certain properties
        private void lbshowbird_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            ////common name
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine()

            //    //location




        }


        private void btncreatebird_Click(object sender, RoutedEventArgs e)
        {

        }

    }

}

