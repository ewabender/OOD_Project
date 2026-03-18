using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Security.RightsManagement;
using System.Data.Entity;

namespace OOD_Project
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

    public class Bird : IComparable
    {
        public string speciesCode { get; set; }
        public string comName { get; set; }
        public string sciName { get; set; }
        public string locId { get; set; }
        public string locName { get; set; }
        public string obsDt { get; set; }
        public int howMany { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public bool obsValid { get; set; }
        public bool obsReviewed { get; set; }
        public bool locationPrivate { get; set; }
        public string subId { get; set; }
        public bool userBird { get; set; }
        public string birdImage { get; set; }





        public Bird()
        {
            // empty ctor 
        }

        protected Bird(string scode, string cnamne, string sname, string location, string when, int numspotted)
        {
            speciesCode = scode;
            comName = cnamne;
            sciName = sname;
            locName = location;
            obsDt = when;
            howMany = numspotted;
            userBird = false;

        }
        public override string ToString()
        {
            return $"{comName}";
        }

        public int CompareTo(object obj)
        {
            Bird bird = obj as Bird;
            return this.comName.CompareTo(bird.comName);
        }
    }

    public class BirdData : DbContext
    {
        public BirdData() :base("Bird Data") { }
        public DbSet<Bird> Birds { get; set; }
    }


}


