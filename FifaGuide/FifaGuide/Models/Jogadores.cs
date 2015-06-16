using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FifaGuide.Models
{

    public class Jogador
    {
        public string resource_id { get; set; }
        public string base_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string common_name { get; set; }
        public string height { get; set; }
        public string dob { get; set; }
        public string foot { get; set; }
        public string club_id { get; set; }
        public string league_id { get; set; }
        public string nation_id { get; set; }
        public string attribute1 { get; set; }
        public string attribute2 { get; set; }
        public string attribute3 { get; set; }
        public string attribute4 { get; set; }
        public string attribute5 { get; set; }
        public string attribute6 { get; set; }
        public int rare { get; set; }
        public int rating { get; set; }

        public string type { get; set; }
        public string edition { get; set; }

        #region Campos Calculados

        public string urlProfileImage
        {
            get
            {
                return string.Format("http://cdn.content.easports.com/fifa/fltOnlineAssets/C74DDF38-0B11-49b0-B199-2E2A11D1CC13/2014/fut/items/images/players/web/{0}.png", base_id);
            }
        }

        public string urlTimeImage
        {
            get
            {
                return "http://cdn.content.easports.com/fifa/fltOnlineAssets/C74DDF38-0B11-49b0-B199-2E2A11D1CC13/2014/fut/items/images/clubbadges/web/{0}.png";
            }
        }

        public string urlNacImage
        {
            get
            {
                return string.Format("http://cdn.content.easports.com/fifa/fltOnlineAssets/C74DDF38-0B11-49b0-B199-2E2A11D1CC13/2014/fut/items/images/cardflagssmall/web/{0}.png", nation_id);
            }
        }

        public Color BgColor
        {
            get
            {
                switch (rare)
                {
                    case 1:
                        return Color.White;
                    case 2:
                        return Color.Silver;
                    case 3:
                        return Color.FromHex("#ffd700");
                    default:
                        return Color.White;
                }
            }
        }

        #endregion

    }

}
