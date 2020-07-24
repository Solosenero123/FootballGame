using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballGame.Models;

namespace FootballGame
{
    class Program
    {
        static void Main(string[] args)
        {
            FootballTeam barcelona = new FootballTeam("Barcelona");
            FootballTeam realMadrid = new FootballTeam("Real Madrid");
            for (int i = 0; i < 11; i++)
            {
                barcelona.AddRandomPlayers();
                realMadrid.AddRandomPlayers();
            }           
            FootballMatch match = new FootballMatch(barcelona, realMadrid);
            match.StartMatch();
            Console.ReadKey();
        }
    }
}
