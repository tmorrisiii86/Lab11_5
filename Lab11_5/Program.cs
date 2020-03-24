using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab11_5
{
    class Program
    {
        static void Main(string[] args)
        {
            SakilaContext sakila = new SakilaContext();
            Film war17 = new Film("1917", "War Drama by Director Sam Mendes", "2019", 3, 5.99m, 179,
                19.99m, "R");
            Film joker = new Film("Joker", "Oscar Nominated SuperHero Drama", "2019", 3, 6.99m, 182,
                23.99m, "R");
            Film starWars = new Film("Star Wars: The Rise of Skywalker", "Trash Disney Fan-fic",
                "2019", 3, 4.99m, 202, 21.99m, "PG-13");

            sakila.Film.Add(war17);
            sakila.Film.Add(joker);
            sakila.Film.Add(starWars);
            sakila.SaveChanges();

            Film[] allfilms = (from db in sakila.Film
                               select new Film(db.title, db.description, db.release_year,
                               db.rental_duration, db.rental_rate, db.length, db.replacement_cost,
                               db.rating)).ToArray();

            var filter19 = allfilms.Where(x => x.release_year == "2019");

            StringBuilder html2019 = new StringBuilder();
            html2019.Append("<html>\n");
            html2019.Append("<head>\n");
            html2019.Append("<title> All 2019 Movies </title>\n");
            html2019.Append("<body>\n");
            html2019.Append("<h1> Movies of 2019 </h1>\n");
            html2019.Append("<ul>\n");

            foreach(var film in filter19)
            {
                html2019.Append("<li>");
                html2019.Append(film.title + " " + film.description);
                html2019.Append("</li>\n");
            }

            html2019.Append("</ul>\n");
            html2019.Append("</body>\n");
            html2019.Append("</html>");

            string htmlFile = "C:\\Users\\tmorr\\OneDrive\\Desktop\\C#Labs\\2019_movies.html";
            File.WriteAllText(htmlFile, html2019.ToString());
        }
    }
}
