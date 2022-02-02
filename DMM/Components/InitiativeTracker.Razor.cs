using DMM.Models;

namespace DMM.Components
{
    public partial class InitiativeTracker
    {
        List<Initiative> InitiativeList = new();
        private InitiativeFormModel InitFormModel = new();
        Random rnd = new Random();

        public void AddPlayers()
        {
            InitiativeList.Add(new Initiative("Beorm", rnd.Next(1,21) + 2, 1, false));
            InitiativeList.Add(new Initiative("Kaia Nova", rnd.Next(1, 21) + 3, 1, false));
            InitiativeList.Add(new Initiative("Leo Woodlock", rnd.Next(1, 21) + 2, 1, false));
            InitiativeList.Add(new Initiative("Sam Logan", rnd.Next(1, 21) + 3, 1, false));
            InitiativeList.Add(new Initiative("Victor Morningstar", rnd.Next(1, 21) + 1, 1, false));

            InitiativeList = InitiativeList.OrderByDescending(x=> x.Roll).ToList();
        }
        public void RemoveInitiative(Initiative i)
        {
            InitiativeList.Remove(i);
            if (i.IsCurrent == true && InitiativeList.Count > 0)
            {
                InitiativeList.First().IsCurrent = true;
            }
        }
        public void ChangeRoll(Initiative i, int newInitiative)
        {
            foreach (var ini in InitiativeList.Where(x => x == i))
            {
                ini.Roll = newInitiative;
            }
        }
        public void AddInitiative(string initiativeName, int initiativeRoll, int status)
        {
            if (initiativeName != "" && initiativeName != null && initiativeRoll >= -99 && initiativeRoll <= 99 )
            {
                var i = new Initiative(
                    initiativeName,
                    (initiativeRoll == 0 ? rnd.Next(1,21) : initiativeRoll),
                    status,
                    false
                );

                if (InitiativeList.Count == 0 || InitiativeList.First().IsCurrent == false)
                    InitiativeList.Add(i);
                else
                {
                    int index = 0;
                    foreach (var initiative in InitiativeList)
                    {
                        if (InitiativeList.Max(x => x.Roll) > i.Roll && InitiativeList.Min(x => x.Roll) < i.Roll)
                        {
                            index = InitiativeList.FindIndex(x => x == initiative);
                            if (initiative.Roll > i.Roll && (InitiativeList.Count() < index + 2 || InitiativeList[index + 1].Roll <= i.Roll))
                            {
                                index++;
                                break;
                            }
                        }
                        else
                        {
                            if (InitiativeList.Max(x => x.Roll) <= i.Roll && initiative.Roll == InitiativeList.Max(x => x.Roll))
                            {
                                index = InitiativeList.FindIndex(x => x == initiative);
                                break;
                            }
                            if (InitiativeList.Min(x => x.Roll) >= i.Roll && initiative.Roll == InitiativeList.Min(x => x.Roll))
                            {
                                index = InitiativeList.FindIndex(x => x == initiative) + 1;
                                break;
                            }
                        }

                    }
                    if (index < InitiativeList.Count && index != 0)
                    {
                        InitiativeList.Insert(index, i);
                    }
                    else
                    {
                        InitiativeList.Add(i);
                    }

                }
                InitFormModel.Name = "";
                InitFormModel.Roll = 0;
            }
        }
        public void SortInitiative()
        {
            if (InitiativeList.Count > 0)
            {
                InitiativeList = InitiativeList.OrderBy(x => x.Roll).Reverse().ToList();
                foreach (var i in InitiativeList)
                {
                    i.IsCurrent = false;
                }
                InitiativeList.First().IsCurrent = true;
            }

        }
        public void NextInitiative()
        {
            if (InitiativeList.Count > 0)
            {
                Initiative i = InitiativeList.First();
                InitiativeList.Remove(i);
                i.IsCurrent = false;
                InitiativeList.Add(i);
                InitiativeList.First().IsCurrent = true;
            }
        }
        public void ClearInitiative()
        {
            InitiativeList = new();
        }
    }
}
