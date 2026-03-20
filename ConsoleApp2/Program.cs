using OOD_Project;
using System.Collections.ObjectModel;
using System.Globalization;
namespace ConsoleApp2
{

    internal class Program
    {
       
        static void Main(string[] args)
        {
            
            List<Bird> Birds = new List<Bird>(); 
            Bird bird = new Bird() {comName="sugar crash", sciName="suga" };
            Bird bird2= new Bird() { comName = "yee yee", sciName = "yee" };

            Birds.Add(bird);
            Birds.Add(bird2);

            foreach (Bird Bird in Birds)
            {
                Console.WriteLine(Bird.ToString());
            }

            


        }
    }
}
