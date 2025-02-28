namespace CharacterCreation
{
    public class Characteristic
    {
        private GameStat.CharacteristicName _name;
        private GameStat.Inclinations[] _inclinations = new GameStat.Inclinations[2];
        private int _lvlLearned;
        private int _amount = 0;

        public string Name { get { return GameStat.characterTranslate[_name]; } }
        public GameStat.CharacteristicName InternalName { get => _name; }
        public int LvlLearned { get => _lvlLearned; set => _lvlLearned = value; }
        public int Amount { get => _amount; set => _amount = value; }

        public GameStat.Inclinations[] Inclinations { get { return _inclinations; } }

        public Characteristic(GameStat.CharacteristicName name, GameStat.Inclinations firstInclination, GameStat.Inclinations secondInclination)
        {
            _name = name;
            _inclinations[0] = firstInclination;
            _inclinations[1] = secondInclination;
        }

        public Characteristic(GameStat.CharacteristicName name, int amount)
        {
            _name = name;
            _amount = amount;
        }

        public Characteristic(Characteristic characteristic)
        {
            _name = characteristic.InternalName;
            _inclinations[0] = characteristic.Inclinations[0];
            _inclinations[1] = characteristic.Inclinations[1];
            _lvlLearned = characteristic.LvlLearned;
            _amount = characteristic.Amount;
        }

        public void UpgradeLvl()
        {
            _lvlLearned += 1;
            _amount += 5;
        }
    }
}

