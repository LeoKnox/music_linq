using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = MusicStore.GetData().AllArtists;
            List<Group> Groups = MusicStore.GetData().AllGroups;

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            System.Console.WriteLine("starting");
            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            IEnumerable<Artist> vern = Artists.Where(arty => arty.Hometown == "Mount Vernon");
            foreach (var v in vern) {
                System.Console.WriteLine("From Mount Vernon");
                System.Console.WriteLine(v.ArtistName + " " + v.RealName);
            }
            //Who is the youngest artist in our collection of artists?
            IEnumerable<Artist> younger = Artists.OrderBy(youn => youn.Age);
            Artist y = younger.First();
            System.Console.WriteLine("Youngest");
            System.Console.WriteLine(y.ArtistName);

            //Display all artists with 'William' somewhere in their real name
            IEnumerable<Artist> wills = Artists.Where(will => will.RealName.Contains("William"));
            System.Console.WriteLine("Contains William");
            foreach (var w in wills)
            {
                System.Console.WriteLine(w.ArtistName + ":" + w.RealName);
            }

            //Display the 3 oldest artist from Atlanta
            IEnumerable<Artist> atl = Artists.OrderBy(ato => ato.Age).Reverse().Take(3);
            System.Console.WriteLine(" 3 Oldest");
            foreach (var a in atl)
            {
                System.Console.WriteLine(a.ArtistName + ":" + a.RealName + " " + a.Age);
            }

            IEnumerable<Group> eight = Groups.Where(eig => eig.GroupName.Length < 8);
            System.Console.WriteLine("Groups with short names");
            foreach(var e in eight)
            {
                System.Console.WriteLine(e.GroupName);
            }
            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
	        Console.WriteLine(Groups.Count);
        }
    }
}
