using System;

namespace CharacterCreation
{
    [Serializable]
    public class JSONSpecialReader
    {
        public string name, description, firstEquipment, secondEquipment, typeEquipment;
        public int amountFirst, amountSecond;
    }
}