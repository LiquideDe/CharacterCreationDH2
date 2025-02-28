
namespace CharacterCreation
{
    public class WeaponTrait : Trait
    {
        public WeaponTrait(string name, string description) : base(name, description)
        {

        }

        public WeaponTrait(string name, int lvl) : base(name, lvl)
        {
        }

        public WeaponTrait(WeaponTrait weaponTrait) : base(weaponTrait)
        {
        }
    }
}

