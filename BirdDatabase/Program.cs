using OOD_Project;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BirdDatabase
{
    internal class Program
        
    {
        public ObservableCollection<Bird> AllBirds = new ObservableCollection<Bird>();
        static void Main(string[] args)
        {
            

            BirdData db = new BirdData();

            using (db)
            {

                Bird b1 = new Bird() { speciesCode = "yee yee", comName = "Berd", sciName = "Stinky Stinky", howMany = 42, userBird = true, birdImage = @"C:\Users\EwaBender-STUDENT\Source\Repos\OOD_Project\OOD_Project\Images\kittuh.png" };


                Bird b2 = new Bird() { speciesCode = "what what", comName = "Elsa", sciName = "Frozen Frozen", howMany = 62, userBird = true, birdImage = @"C:\\Users\\EwaBender-STUDENT\\Source\\Repos\\OOD_Project\\OOD_Project\\Images\\OIP.jpg" };


                

                db.Birds.Add(b1);
                db.Birds.Add(b2);

                for (int i = 1; i < AllBirds.length(); i++)
                {
                    db.Birds.Add(AllBirds[i]);
                }


                db.SaveChanges();
                Console.WriteLine("Ready to rockn'roll");



            }
        }
    }
}
