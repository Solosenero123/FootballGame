using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FootballGame.Library;

namespace FootballGame.Models
{
    class FootballMatch
    {
        public event Action<FootballTeam> Goal;
        public event Func<FootballTeam,int, bool> Foul;
        private FootballReferee footballReferee;
        public FootballTeam FirstFootballTeam { get; private set; }
        public FootballTeam SecondFootballTeam { get; private set; }

        public FootballMatch(FootballTeam firstFootballTeam, FootballTeam secondFootballTeam)
        {
            this.FirstFootballTeam = firstFootballTeam;
            this.SecondFootballTeam = secondFootballTeam;
        }

        public void StartMatch()
        {
            footballReferee = new FootballReferee("Best referee");
            Foul += footballReferee.RefereeFoulHandler;
            Goal += footballReferee.RefereeGoalHandler;
            int firstTeamFouls = 0;
            int secondTeamFouls = 0;
            int[] score = { 0, 0 };
            Console.WriteLine("Match Started!");
            Thread.Sleep(350);
            for (int i = 0; i < 90; i++)
            {
                Thread.Sleep(350);
                Console.WriteLine($"{i} minutes of match");
                if (Resourses.MyRandom.Next(0, 90) < 5)
                {
                    int firstTeamChanseToGoal = Resourses.MyRandom.Next(0, (int)FirstFootballTeam.TeamMastery - firstTeamFouls);
                    int secondTeamChanseToGoal = Resourses.MyRandom.Next(0, (int)SecondFootballTeam.TeamMastery - secondTeamFouls);
                    if (firstTeamChanseToGoal > secondTeamChanseToGoal)
                    {
                        Goal?.Invoke(FirstFootballTeam);
                        score[0] += 1;
                        continue;
                    }
                    else
                    {
                        Goal?.Invoke(SecondFootballTeam);
                        score[1] += 1;
                        continue;
                    }
                }
                if (Resourses.MyRandom.Next(0, 90) < 4)
                {
                    if (Resourses.MyRandom.Next(0, 100) < 50)
                    {
                        if (Foul?.Invoke(FirstFootballTeam, 1) == true)
                            firstTeamFouls += 65;
                    }
                    else
                    {
                        if (Foul?.Invoke(SecondFootballTeam, 2) == true)
                            secondTeamFouls += 65;
                    }
                }
            }
            if (score[0] > score[1])
                Console.WriteLine($"Team {FirstFootballTeam.Name} wins with score {score[0]} : {score[1]}");
            else if (score[0] < score[1])
                Console.WriteLine($"Team {SecondFootballTeam.Name} wins with score {score[1]} : {score[0]}");
            else
                Console.WriteLine("Match was ended with draw");
        }
    }
}
