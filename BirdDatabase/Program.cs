using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD_Project;
using System.Data.Entity;

namespace BirdDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BirdData db = new BirdData();

            using (db)
            {
                Bird b1 = new Bird() { comName = "Berd", sciName = "Stinky Stinky", howMany = 42, userBird = true, birdImage = @"C:\\Users\\EwaBender-STUDENT\\Source\\Repos\\OOD_Project\\OOD_Project\\Images\\OIP.jpg" };
                Bird b2 = new Bird() { comName = "Elsa", sciName = "Frozen Frozen", howMany = 62, userBird = true, birdImage = @"C:\\Users\\EwaBender-STUDENT\\Source\\Repos\\OOD_Project\\OOD_Project\\Images\\OIP.jpg" };

                db.Birds.Add(b1);
                db.Birds.Add(b2);

                db.SaveChanges();
                Console.WriteLine("Ready to rockn'roll");



            }
        }
    }
}
