using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace brewrillaAPI.Models
{
    public class BeerItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tagline { get; set; }
        public string first_brewed { get; set; }
        public string description { get; set; }
        public string image_url { get; set; }
        public float abv { get; set; }
        public float ibu { get; set; }
        public float target_fg { get; set; }
        public float target_og { get; set; }
        public float ebc { get; set; }
        public float srm { get; set; }
        public float ph { get; set; }
        public float attenuation_level { get; set; }
        public string brewers_tips { get; set; }
    }
}
