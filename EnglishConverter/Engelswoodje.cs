using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishConverter
{
    class Engelswoodje
    {
        public string woordjeEngels { get; set; }
        public string woordjeNederlands { get; set; }
        public string zinEngels { get; set; }

        public Engelswoodje(string woordjeEngels, string woordjeNederlands, string zinEngels)
        {
            this.woordjeEngels = woordjeEngels;
            this.woordjeNederlands = woordjeNederlands;
            this.zinEngels = zinEngels;
        }

        public  Engelswoodje(string woordjeEngels, string woordjeNederlands)
        {
            this.woordjeEngels = woordjeEngels;
            this.woordjeNederlands = woordjeNederlands;
            this.zinEngels = "";
        }
    }
}
