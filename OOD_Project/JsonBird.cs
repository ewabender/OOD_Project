using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OOD_Project
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class JsonBird
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
    



        public JsonBird()
        {
           // empty ctor 
        }

        protected JsonBird(string cnamne,string sname,string location, string when, int numspotted )
        {

            comName = cnamne;
            sciName = sname;
            locName = location;
            obsDt = when;
            howMany = numspotted;
            
        }

    }

    public class UserBird : JsonBird 
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
