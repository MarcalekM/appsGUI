using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appsGUI
{
    internal class Alkalmazas
    {
        public string appName { get; set; }
        public Category category { get; set; }
        public ContentRating contentRating { get; set; }
        public double rating { get; set; }
        public int reviews { get; set; }
        public string currentVer { get; set; }
        public int updateYear { get; set; }
        public int updateMonth { get; set; }

        static public List<Alkalmazas> LoadFromCsv(string path)
        {
            List<Alkalmazas> appok = new();
            using StreamReader sr = new(
                path: @$"../../../src/{path}",
                encoding: Encoding.UTF8);
            _ = sr.ReadLine();
            while (!sr.EndOfStream) appok.Add(new(sr.ReadLine()));
            return appok;
        }

        public string ConvertToStars()
        {
            string stars = "";
            if (rating != 0) for (int i = 0; i < Math.Floor(rating); i++) stars += "*";
            if (stars == "") stars += "-";
            return stars;
        }

        public override string ToString()
        {
            return $"{appName} {ConvertToStars()}";
        }

        public Alkalmazas(string sor)
        {
            var temp = sor.Split(';');
            appName = temp[0];
            category = new Category(Convert.ToInt32(temp[1]), temp[2]);
            contentRating = new ContentRating(Convert.ToInt32(temp[3].Replace('.', ',')), temp[4]);
            rating = Convert.ToDouble(temp[5]);
            reviews = Convert.ToInt32(temp[6]);
            currentVer = temp[7];
            updateYear = Convert.ToInt32(temp[8]);
            updateMonth = Convert.ToInt32(temp[9]);
        }
    }
}
