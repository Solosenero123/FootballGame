using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballGame.Library;

namespace FootballGame.Models
{
    class FootballCoach
    {
        public string Surname { get; private set; }
        public double Lucky { get; private set; }

        public FootballCoach()
        {
            Lucky = Resourses.MyRandom.NextDouble() + 0.5;
        }
    }
}
