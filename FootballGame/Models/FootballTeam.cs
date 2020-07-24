using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballGame.Models
{
    class FootballTeam
    {
        public FootballCoach FootballCoach { get; private set; }
        public string Name { get; set; }
        public List<FootballPlayer> FootballPlayers;
        private uint teamMastery;
        public uint TeamMastery { 
            get 
            {
                return Convert.ToUInt32(teamMastery * FootballCoach.Lucky);
            }   
        }

        public FootballTeam(string name)
        {
            this.FootballPlayers = new List<FootballPlayer>();
            this.FootballCoach = new FootballCoach();
            this.Name = name;
        }

        public FootballTeam(string name, List<FootballPlayer> footballPlayers, FootballCoach footballCoach)
        {
            this.Name = name;
            this.FootballPlayers = footballPlayers;
            this.FootballCoach = footballCoach;
        }

        public void AddPlayer(FootballPlayer footballPlayer)
        {
            FootballPlayers.Add(footballPlayer);
            teamMastery += footballPlayer.Mastery;
        }

        public void AddRandomPlayers()
        {
            FootballPlayer randomPlayer = new FootballPlayer();
            FootballPlayers.Add(randomPlayer);
            teamMastery += randomPlayer.Mastery;
        }

        public void AllPlayers()
        {
            var b = FootballPlayers.OrderBy(x => x.Surname);
            foreach (var x in b){
                Console.WriteLine(x.Surname);
            }
        }

        public void OldPlayers()
        {
            var b = FootballPlayers.Where(x => x.Age > 30).OrderByDescending(x => x.Mastery);
            foreach (var x in b)
            {
                Console.WriteLine($"{x.Surname} {x.Age} {x.Mastery}");
            }
        }

    }
}
