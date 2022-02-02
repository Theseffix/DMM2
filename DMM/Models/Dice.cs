namespace DMM.Models
{
    public class Dice
    {
        public int DieType { get; set; }
        public bool Advantage { get; set; }
        public bool Disadvantage { get; set; }
        public int FirstRoll { get; set; }
        public int SecondRoll { get; set; }
        public int DieResult { get; set; }

        public Dice(int dietype, bool advantage, bool disadvantage,int firstroll, int secondroll, int dieresult)
        {
            DieType = dietype;
            Advantage = advantage;
            Disadvantage = disadvantage;
            FirstRoll = firstroll;
            SecondRoll = secondroll;
            DieResult = dieresult;
        }

    }
}
