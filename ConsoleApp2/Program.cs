using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        static void Main(string[] args)
        {
            InitialiserDatas();

            //Afficher liste prénoms auteur %G
            Console.WriteLine("Liste des prenoms des auteurs dont le nom commence par G :");
            var prenoms = ListeAuteurs.Where(a => a.Nom.StartsWith("G")).Select(a => a.Prenom);

            foreach (var prenom in prenoms)
            {
                Console.WriteLine(prenom);
            }

            //Afficher auteur écrit le + de livres
            Console.WriteLine();
            Console.WriteLine("Auteur qui a écrit le plus de livres :");


            //Afficher nombre M de pages pas livre par auteur
            Console.WriteLine();
            Console.WriteLine("Nombre moyen de pages par livre par auteur :");


            //Afficher titre livre avec le + de pages
            Console.WriteLine();
            Console.WriteLine("Titre du livre avec le plus de pages :");
            var livrePagesMax = ListeLivres.OrderByDescending(l => l.NbPages).First();
            Console.WriteLine(livrePagesMax.Titre);

            //Afficher combien auteurs ont gagnés en M
            Console.WriteLine();
            Console.WriteLine("Moyenne gains des auteurs :");


            //Afficher auteurs et liste de leurs livres
            Console.WriteLine();
            Console.WriteLine("Auteurs et liste de leurs livres :");
            var listeLivresAuteur = ListeLivres.GroupBy(l => l.Auteur);
 

            //Afficher titres livres triés par ordre alphab
            Console.WriteLine();
            Console.WriteLine("Titres de tous les livres triés par ordre alphabétique :");
            var listeLivreOrder = ListeLivres.Select(l => l.Titre).OrderBy(t => t);

           
            //Afficher liste livres dont nb de pages > à M
            Console.WriteLine();
            Console.WriteLine("Liste des livres dont le nombre de page est > à la moyenne :");
            var moyenne = ListeLivres.Average(l => l.NbPages);
            var moyenneMax = ListeLivres.Where(l => l.NbPages > moyenne);


            //Afficher auteur ayant écrit le - de livres
            Console.WriteLine();
            Console.WriteLine("Auteur ayant écrit le moins de livres :");

            Console.ReadKey();
        }

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
    }
}

