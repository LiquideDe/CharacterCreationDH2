using System.Collections.Generic;
using System;

namespace CharacterCreation
{
    [Serializable]
    public class CharacterData
    {
        public NewSaveLoadCharacter character;
        public List<SaveLoadName> talents;
        public List<SaveLoadName> mentalDisorders;
        public List<SaveLoadName> mutations;
        public List<SaveLoadName> psyPowers;
        public List<SaveLoadName> inclinations;
        public List<SaveLoadTrait> traits;
        public List<SaveLoadSkill> skills;
        public List<SaveLoadCharacteristic> characteristics;
        public List<SaveLoadImplant> implants;
        public List<JSONArmorReader> armors;
        public List<JSONGrenadeReader> grenades;
        public List<JSONMeleeReader> melees;
        public List<JSONEquipmentReader> equipments;
        public List<JSONRangeReader> ranges;
    }

    [Serializable]
    public class SaveLoadName
    {
        public string name;
    }

    [Serializable]
    public class SaveLoadTrait
    {
        public string name;
        public int lvl;
    }

    [Serializable]
    public class NewSaveLoadCharacter
    {
        public string name, background, role, ageText, prophecy, constitution, hair, eyes, skeen, physFeatures, memoryOfHome,
            memoryOfBackground, gender, bonusBack, homeworld, elite, tradition, bonusHomeworld, bonusRole;
        public int age, fatePoint, insanityPoints, corruptionPoints, wounds, psyRating,
            experienceTotal, experienceUnspent, experienceSpent;
    }

    [Serializable]
    public class SaveLoadImplant
    {
        public string name, partsOfBody, description;
        public int armor, bonusToughness;

    }
}


