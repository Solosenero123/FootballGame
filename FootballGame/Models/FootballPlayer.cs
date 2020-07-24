using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballGame.Library;

namespace FootballGame.Models
{
    class FootballPlayer
    {
        private uint age;

        public uint Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 0 && value < 80)
                    age = value;
            }
        }

        public string Surname { get; set; }

        private uint mastery;

        public uint Mastery
        {
            get
            {
                return mastery;
            }
            set
            {
                if (value >= 0 && value <= 100)
                    mastery = value;
            }
        }

        public FootballPlayer(string surname, uint age)
        {
            this.Surname = surname;
            this.Age = age;
            this.Mastery = (uint)Resourses.MyRandom.Next(0, 100);
        }

        public FootballPlayer()
        {
            this.Surname = "Random surname";
            this.Age = (uint)Resourses.MyRandom.Next(0, 80); 
            this.Mastery = (uint)Resourses.MyRandom.Next(0, 100);
        }
    }
}
