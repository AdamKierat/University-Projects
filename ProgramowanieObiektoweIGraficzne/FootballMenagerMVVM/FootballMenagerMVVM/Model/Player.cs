namespace FootballMenagerMVVM.Model
{
    internal class Player
    {
        #region Propertis

        private string forename;
        private string surname;
        private double age;
        private double weight;

        public string Forename { 
            get => forename;
            set => forename = value;
        }
        public string Surname {
            get => surname;
            set => surname = value;
        }
        public double Age {
            get => age;
            set => age = value;
        } 
        public double Weight
        {
            get => weight;
            set => weight = value;
        }
        #endregion

        #region Contructors

        public Player()
        {
        }

        public Player(string forename,string surname,double age,double weight)
        {
            this.Forename = forename;
            this.Age = age;
            this.Surname = surname;
            this.weight = weight;
        }
        #endregion

        #region Methods
        
        public void Copy(Player player)
        {
            Forename = player.Forename;
            Surname = player.Surname;
            Age = player.Age;
            Weight = player.Weight;
        }

        public override string ToString()
        {
            return $"{Forename} {Surname} Age:{Age} years old, weight: {Weight}kg";
        }
        #endregion
    }

}
