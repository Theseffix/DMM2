using DMM.Models;

namespace DMM.Components
{
    public partial class DiceRoller
    {
        //1 = Disadvantage, 2 = Advantage, n>2 = default (normal)
        int DieType = 3;
        List<Dice> DiceToRoll = new();
        List<Dice> RolledDice = new();
        Random Roll = new Random();

        public void AdvantageSwitch_Click()
        {
            if(DieType == 1 || DieType > 2)
                DieType = 2;
            
            else if (DieType == 2)
                DieType = 3;
        }
        public void DisAdvantageSwitch_Click()
        {
            if (DieType == 2 || DieType > 2)
                DieType = 1;

            else if (DieType == 1)
                DieType = 3;
        }

        public int RollAdvantage(int dietype)
        {
            int roll1 = Roll.Next(1,dietype+1);
            int roll2 = Roll.Next(1,dietype+1);

            if(roll1 >= roll2)
                return roll1;
            
            return roll2;
        }
        public int RollDisadvantage(int dietype)
        {
            int roll1 = Roll.Next(1, dietype + 1);
            int roll2 = Roll.Next(1, dietype + 1);

            if (roll1 <= roll2)
                return roll1;

            return roll2;
        }
        public void RemoveSingleDie(Dice die)
        {
            RolledDice.Remove(die);
        }

        public void ClearDice()
        {
            RolledDice = new();
            DiceToRoll = new();
            DieType = 3;
        }

        public void RollDice()
        {
            int i = 0;
            int roll1 = 0;
            int roll2 = 0;
            int result = 0;
            int highest = 0;
            DieType = 3;
            DiceToRoll = new();

            if(d20AdvantageToRoll != 0)
                for (i = 0; i < d20AdvantageToRoll; i++)
                {
                    roll1 = Roll.Next(1, 21);
                    roll2 = Roll.Next(1, 21);

                    if (roll1 > roll2)
                        highest = roll1;
                    else
                        highest = roll2;

                    DiceToRoll.Add(new Dice(20, true, false, roll1, roll2, highest));
                }

            if (d20ToRoll != 0)
                for (i = 0; i < d20ToRoll; i++)
                    DiceToRoll.Add(new Dice(20, false, false, 0, 0, Roll.Next(1,21)));

            if (d20DisAdvantageToRoll != 0)
                for (i = 0; i < d20DisAdvantageToRoll; i++)
                {
                    roll1 = Roll.Next(1, 21);
                    roll2 = Roll.Next(1, 21);

                    if (roll1 < roll2)
                        highest = roll1;
                    else
                        highest = roll2;

                    DiceToRoll.Add(new Dice(20, false, true, roll1, roll2, highest));
                }

            if (d12AdvantageToRoll != 0)
                for (i = 0; i < d12AdvantageToRoll; i++)
                {
                    roll1 = Roll.Next(1, 13);
                    roll2 = Roll.Next(1, 13);
                    result = roll1 + roll2;

                    DiceToRoll.Add(new Dice(12, true, false, roll1, roll2, result));
                }

            if (d12ToRoll != 0)
                for (i = 0; i < d12ToRoll; i++)
                    DiceToRoll.Add(new Dice(12, false, false, 0, 0, Roll.Next(1, 13)));

            if (d12DisAdvantageToRoll != 0)
                for (i = 0; i < d12DisAdvantageToRoll; i++)
                {
                    roll1 = Roll.Next(1, 13);
                    result = roll1 / 2;

                    DiceToRoll.Add(new Dice(12, false, true, roll1, 0, result));
                }

            if (d10AdvantageToRoll != 0)
                for (i = 0; i < d10AdvantageToRoll; i++)
                {
                    roll1 = Roll.Next(1, 11);
                    roll2 = Roll.Next(1, 11);
                    result = roll1 + roll2;

                    DiceToRoll.Add(new Dice(10, true, false, roll1, roll2, result));
                }

            if (d10ToRoll != 0)
                for (i = 0; i < d10ToRoll; i++)
                    DiceToRoll.Add(new Dice(10, false, false, 0, 0, Roll.Next(1, 11)));

            if (d10DisAdvantageToRoll != 0)
                for (i = 0; i < d10DisAdvantageToRoll; i++)
                {
                    roll1 = Roll.Next(1, 11);
                    result = roll1 / 2;

                    DiceToRoll.Add(new Dice(10, false, true, roll1, 0, result));
                }

            if (d8AdvantageToRoll != 0)
                for (i = 0; i < d8AdvantageToRoll; i++)
                {
                    roll1 = Roll.Next(1, 9);
                    roll2 = Roll.Next(1, 9);
                    result = roll1 + roll2;

                    DiceToRoll.Add(new Dice(8, true, false, roll1, roll2, result));
                }

            if (d8ToRoll != 0)
                for (i = 0; i < d8ToRoll; i++)
                    DiceToRoll.Add(new Dice(8, false, false, 0, 0, Roll.Next(1, 9)));

            if (d8DisAdvantageToRoll != 0)
                for (i = 0; i < d8DisAdvantageToRoll; i++)
                {
                    roll1 = Roll.Next(1, 9);
                    result = roll1 / 2;

                    DiceToRoll.Add(new Dice(8, false, true, roll1, 0, result));
                }

            if (d6AdvantageToRoll != 0)
                for (i = 0; i < d6AdvantageToRoll; i++)
                {
                    roll1 = Roll.Next(1, 7);
                    roll2 = Roll.Next(1, 7);
                    result = roll1 + roll2;

                    DiceToRoll.Add(new Dice(6, true, false, roll1, roll2, result));
                }

            if (d6ToRoll != 0)
                for (i = 0; i < d6ToRoll; i++)
                    DiceToRoll.Add(new Dice(6, false, false, 0, 0, Roll.Next(1, 7)));

            if (d6DisAdvantageToRoll != 0)
                for (i = 0; i < d6DisAdvantageToRoll; i++)
                {
                    roll1 = Roll.Next(1, 7);
                    result = roll1 / 2;
                    if (result == 0)
                        result = 1;

                    DiceToRoll.Add(new Dice(6, false, true, roll1, 0, result));
                }

            if (d4AdvantageToRoll != 0)
                for (i = 0; i < d4AdvantageToRoll; i++)
                {
                    roll1 = Roll.Next(1, 5);
                    roll2 = Roll.Next(1, 5);
                    result = roll1 + roll2;

                    DiceToRoll.Add(new Dice(4, true, false, roll1, roll2, result));
                }

            if (d4ToRoll != 0)
                for (i = 0; i < d4ToRoll; i++)
                    DiceToRoll.Add(new Dice(4, false, false, 0, 0, Roll.Next(1, 5)));

            if (d4DisAdvantageToRoll != 0)
                for (i = 0; i < d4DisAdvantageToRoll; i++)
                {
                    roll1 = Roll.Next(1, 5);
                    result = roll1 / 2;
                    if (result == 0)
                        result = 1;

                    DiceToRoll.Add(new Dice(4, false, true, roll1, 0, result));
                }

            foreach (var die in DiceToRoll)
                RolledDice.Add(die);

            RolledDice = RolledDice
                .OrderByDescending(x => x.DieResult)
                .ThenByDescending(x => x.DieType)
                .ToList();

            d20DisAdvantageToRoll = 0;
            d20ToRoll = 0;
            d20AdvantageToRoll = 0;
            d12DisAdvantageToRoll = 0;
            d12ToRoll = 0;
            d12AdvantageToRoll = 0;
            d10DisAdvantageToRoll = 0;
            d10ToRoll = 0;
            d10AdvantageToRoll = 0;
            d8DisAdvantageToRoll = 0;
            d8ToRoll = 0;
            d8AdvantageToRoll = 0;
            d6DisAdvantageToRoll = 0;
            d6ToRoll = 0;
            d6AdvantageToRoll = 0;
            d4DisAdvantageToRoll = 0;
            d4ToRoll = 0;
            d4AdvantageToRoll = 0;

        }

        #region Dice add & subtract
        int d20DisAdvantageToRoll = 0;
        int d20ToRoll = 0;
        int d20AdvantageToRoll = 0;

        int d12DisAdvantageToRoll = 0;
        int d12ToRoll = 0;
        int d12AdvantageToRoll = 0;

        int d10DisAdvantageToRoll = 0;
        int d10ToRoll = 0;
        int d10AdvantageToRoll = 0;

        int d8DisAdvantageToRoll = 0;
        int d8ToRoll = 0;
        int d8AdvantageToRoll = 0;

        int d6DisAdvantageToRoll = 0;
        int d6ToRoll = 0;
        int d6AdvantageToRoll = 0;

        int d4DisAdvantageToRoll = 0;
        int d4ToRoll = 0;
        int d4AdvantageToRoll = 0;

        public void AddD20DisAdvantage()
        {
            d20DisAdvantageToRoll++;
        }
        public void SubtractD20DisAdvantage()
        {
            if (d20DisAdvantageToRoll > 0)
                d20DisAdvantageToRoll--;
        }
        public void AddD20()
        {
            d20ToRoll++;
        }
        public void SubtractD20()
        {
            if (d20ToRoll > 0)
                d20ToRoll--;
        }
        public void AddD20Advantage()
        {
            d20AdvantageToRoll++;
        }
        public void SubtractD20Advantage()
        {
            if (d20AdvantageToRoll > 0)
                d20AdvantageToRoll--;
        }

        public void AddD12DisAdvantage()
        {
            d12DisAdvantageToRoll++;
        }
        public void SubtractD12DisAdvantage()
        {
            if (d12DisAdvantageToRoll > 0)
                d12DisAdvantageToRoll--;
        }
        public void AddD12()
        {
            d12ToRoll++;
        }
        public void SubtractD12()
        {
            if (d12ToRoll > 0)
                d12ToRoll--;
        }
        public void AddD12Advantage()
        {
            d12AdvantageToRoll++;
        }
        public void SubtractD12Advantage()
        {
            if (d12AdvantageToRoll > 0)
                d12AdvantageToRoll--;
        }

        public void AddD10DisAdvantage()
        {
            d10DisAdvantageToRoll++;
        }
        public void SubtractD10DisAdvantage()
        {
            if (d10DisAdvantageToRoll > 0)
                d10DisAdvantageToRoll--;
        }
        public void AddD10()
        {
            d10ToRoll++;
        }
        public void SubtractD10()
        {
            if (d10ToRoll > 0)
                d10ToRoll--;
        }
        public void AddD10Advantage()
        {
            d10AdvantageToRoll++;
        }
        public void SubtractD10Advantage()
        {
            if (d10AdvantageToRoll > 0)
                d10AdvantageToRoll--;
        }

        public void AddD8DisAdvantage()
        {
            d8DisAdvantageToRoll++;
        }
        public void SubtractD8DisAdvantage()
        {
            if (d8DisAdvantageToRoll > 0)
                d8DisAdvantageToRoll--;
        }
        public void AddD8()
        {
            d8ToRoll++;
        }
        public void SubtractD8()
        {
            if (d8ToRoll > 0)
                d8ToRoll--;
        }
        public void AddD8Advantage()
        {
            d8AdvantageToRoll++;
        }
        public void SubtractD8Advantage()
        {
            if (d8AdvantageToRoll > 0)
                d8AdvantageToRoll--;
        }

        public void AddD6DisAdvantage()
        {
            d6DisAdvantageToRoll++;
        }
        public void SubtractD6DisAdvantage()
        {
            if (d6DisAdvantageToRoll > 0)
                d6DisAdvantageToRoll--;
        }
        public void AddD6()
        {
            d6ToRoll++;
        }
        public void SubtractD6()
        {
            if (d6ToRoll > 0)
                d6ToRoll--;
        }
        public void AddD6Advantage()
        {
            d6AdvantageToRoll++;
        }
        public void SubtractD6Advantage()
        {
            if (d6AdvantageToRoll > 0)
                d6AdvantageToRoll--;
        }

        public void AddD4DisAdvantage()
        {
            d4DisAdvantageToRoll++;
        }
        public void SubtractD4DisAdvantage()
        {
            if (d4DisAdvantageToRoll > 0)
                d4DisAdvantageToRoll--;
        }
        public void AddD4()
        {
            d4ToRoll++;
        }
        public void SubtractD4()
        {
            if (d4ToRoll > 0)
                d4ToRoll--;
        }
        public void AddD4Advantage()
        {
            d4AdvantageToRoll++;
        }
        public void SubtractD4Advantage()
        {
            if (d4AdvantageToRoll > 0)
                d4AdvantageToRoll--;
        }
        #endregion
    }
}
