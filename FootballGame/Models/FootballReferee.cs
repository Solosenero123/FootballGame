using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FootballGame.Library;

namespace FootballGame.Models
{
    class FootballReferee
    {
        public string Surname { get; private set; }
        private int preference;
        public int Preference
        {
            get
            {
                return preference;
            }
            private set
            {
                if (value == 1 || value == 2 || value == 0)
                    preference = value;
                else
                    throw new Exception("Wrong Referee preference");
            }
        }

        public FootballReferee(string surname)
        {
            this.Surname = surname;
            this.Preference = Resourses.MyRandom.Next(3);
        }

        public void RefereeGoalHandler(FootballTeam footballTeam)
        {
            Console.WriteLine($"GOOOOOAAAAAL!!! Team {footballTeam.Name} score the goal!");
        }

        public bool RefereeFoulHandler(FootballTeam footballTeam, int numTeam)
        {
            
            Console.WriteLine($"{footballTeam.FootballPlayers[Resourses.MyRandom.Next(11)].Surname} player of team {footballTeam.Name} broke the rules");
            Thread.Sleep(500);
            if (numTeam == preference)
            {
                Console.WriteLine("But the referee's whistle is not heard, what a strange decision");
                return false;
            }
            else if (preference != numTeam && preference != 0)
            {
                
                Console.WriteLine("The referee blows the whistle and the player receives a yellow card");
                return true;

            }
            else
            {
                if (Resourses.MyRandom.Next(100) < 10)
                {
                    Console.WriteLine("But the referee was distracted and did not see it");
                    return false;
                }
                Console.WriteLine("The referee blows the whistle and the player receives a yellow card");
                return true;
            }
        }
    }
}
