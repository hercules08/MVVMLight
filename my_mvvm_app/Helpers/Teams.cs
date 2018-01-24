using my_mvvm_app.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_mvvm_app.Helpers
{
    public class Teams
    {
        public static List<Cards> GenerateCards
        {
            get
            {
                return new List<Cards>()
                {
                    new Cards {TeamName="Liverpool", Capacity=45276, StadiumName="Anfield", Latitude=53.430833, Longitude=2.960833 },
                    new Cards {TeamName="West Ham United", Capacity=35345, StadiumName="Upton Park",Latitude=51.531944, Longitude=0.039444 },
                    new Cards {TeamName="Aston Villa", Capacity=42682, StadiumName="Villa Park", Latitude=52.509167, Longitude=1.884722 },
                    new Cards {TeamName="Tottenham Hotspurs", Capacity=36284, StadiumName="White Hart Lane", Latitude=51.603333, Longitude=0.065833 }
                };
            }
        }
    }
}
