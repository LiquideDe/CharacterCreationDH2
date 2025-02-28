using System;

namespace CharacterCreation
{
    [Serializable]
    public class SaveLoadCharacter
    {
        public string name, background, role, ageText, prophecy, constitution, hair, eyes, skeen, physFeatures, memoryOfHome,
            memoryOfBackground, gender, bonusBack, homeworld, talents, inclinations, mentalDisorders, mutation, equipments, psyPowers,
            traits, traitsLvl, elite, tradition, bonusHomeworld, bonusRole;
        public int age, fatePoint, insanityPoints, corruptionPoints, wounds, psyRating,
            experienceTotal, experienceUnspent, experienceSpent, amountImplants, amountSkills;

    }
}


