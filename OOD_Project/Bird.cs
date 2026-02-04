using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOD_Project
{
    public abstract class Bird
    {
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public string SpottedLoc { get; set; }
        public DateTime SpottedWhen { get; set; }
        public int SpottedCount { get; set; }


        public Bird()
        {
           
        }

        protected Bird(string cnamne,string sname,string location, DateTime when, int numspotted )
        {
           
            CommonName = cnamne;
            ScientificName = sname;
            SpottedLoc = location;  
            SpottedWhen = when;
            SpottedCount = numspotted;
            
        }

    }

    public class UserBird : Bird 
    {
        //user created bird entries come with the ability to add image, it can't be null
        public byte[] birdimng { get; set; }

        // add an ability for the user to upload an image for the bird of their choice.
        public UserBird(byte[] birdimng)
        {
            this.birdimng = birdimng;
        }

        public UserBird()
        {
            
        }
    }
}
