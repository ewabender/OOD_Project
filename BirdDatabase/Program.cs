using Newtonsoft.Json;
using OOD_Project;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Text.Json;

namespace BirdDatabase
{
    internal class Program
    {

        static void Main(string[] args)
        {
            BirdData db = new BirdData();

            using (db)
            {

                Bird b1 = new Bird() { speciesCode = "yee yee", comName = "Berd", sciName = "Stinky Stinky", howMany = 42, userBird = true, birdImage = @"C:\Users\EwaBender-STUDENT\Source\Repos\OOD_Project\OOD_Project\Images\kittuh.png" };
                Bird b2 = new Bird() { speciesCode = "what what", comName = "Elsa", sciName = "Frozen Frozen", howMany = 62, userBird = true, birdImage = @"C:\\Users\\EwaBender-STUDENT\\Source\\Repos\\OOD_Project\\OOD_Project\\Images\\OIP.jpg" };

                db.Birds.Add(b1);
                db.Birds.Add(b2);


                

                //
                for (int i = 1; i < AllBirds.Count; i++)
                {
                    db.Birds.Add(AllBirds[i]);
                }


                db.SaveChanges();
                Console.WriteLine("Ready to rockn'roll");



            }


            async Task<ObservableCollection<Bird>> GetAPIData()
            {
                string apiKey = "31ichicpcbi7";

                EbirdClient client = new EbirdClient(apiKey);

                string json = await client.GetRecentObservations("IE"); // IE = Ireland


                ObservableCollection<Bird> AllBirds = System.Text.Json.JsonSerializer.Deserialize<ObservableCollection<Bird>>(json);

                return AllBirds;
            }
        }
    }
}
