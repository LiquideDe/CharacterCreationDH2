using System.Collections;
using UnityEngine;
using TMPro;
using Zenject;
using System.Linq;
using System.Text.RegularExpressions;

namespace CharacterCreation
{
    public class ThirdCharacterSheet : TakeScreenshot
    {
        [SerializeField] private TextMeshProUGUI _text, _textNameCharacter;
        private CreatorTalents _creatorTalents;
        private CreatorPsyPowers _creatorPsyPowers;
        private CreatorTraits _creatorTraits;
        private CreatorWeaponTrait _creatorWeaponTrait;
        private int _page;

        [Inject]
        private void Construct(CreatorTalents creatorTalents, CreatorPsyPowers creatorPsyPowers, CreatorTraits creatorTraits, CreatorWeaponTrait weaponTrait)
        {
            _creatorTalents = creatorTalents;
            _creatorPsyPowers = creatorPsyPowers;
            _creatorTraits = creatorTraits;
            _creatorWeaponTrait = weaponTrait;
        }

        public void Initialize(ICharacter character)
        {
            _character = character;
            _textNameCharacter.text = _character.Name;

            _text.text += $"<indent=15%><size=150%>Таланты:</indent> \n<size=100%>";

            foreach (Talent talent in character.Talents)
                _text.text += $"<b>{talent.Name}</b> - {GetDescriptionTalent(talent.Name)} \n \n";

            if (character.PsyPowers.Count > 0)
            {
                _text.text += $"<indent=15%><size=150%>Психо-силы:</indent> \n<size=100%>";
                foreach (PsyPower psyPower in character.PsyPowers)
                    _text.text += $"<b>{psyPower.Name}</b> - " +
                        $"Действие:{_creatorPsyPowers.GetPsyPower(psyPower.Name).Action}, {GetDescriptionPsy(psyPower.Name)} \n \n";

            }

            if (character.Implants.Count > 0)
            {
                _text.text += $"<indent=15%><size=150%>Импланты:</indent> \n<size=100%>";
                foreach (MechImplant implant in character.Implants)
                    if (implant.Description.Length > 1)
                        _text.text += $"<b>{implant.Name}</b> - {implant.Description}\n \n";
            }

            if (character.Traits.Count > 0)
            {
                _text.text += $"<indent=15%><size=150%>Особенности:</indent> \n<size=100%>";
                foreach (Trait trait in character.Traits)
                {
                    if (string.Compare(trait.Name, "Сверхъестественные чувства", true) == 0)
                    {
                        if (string.Compare(character.Background, "Адептус Астра Телепатика", true) == 0)
                            _text.text += $"<b>{trait.Name}({(int)(character.Characteristics[GameStat.CharacteristicToInt["Сила Воли"]].Amount)})</b> - {GetDescriptionTrait(trait.Name)}\n \n";
                        else
                            _text.text += $"<b>{trait.Name}({trait.Lvl})</b> - {GetDescriptionTrait(trait.Name)}\n \n";
                    }
                    else
                    {
                        if (trait.Lvl > 0)
                            _text.text += $"<b>{trait.Name}({trait.Lvl})</b> - {GetDescriptionTrait(trait.Name)}\n \n";
                        else
                            _text.text += $"<b>{trait.Name}</b> - {GetDescriptionTrait(trait.Name)}\n \n";
                    }

                }

            }

            _text.text += $"<indent=15%><size=150%>Экипировка:</indent> \n<size=100%>";
            foreach (Equipment equipment in character.Equipments)
            {
                _text.text += $"<b>{equipment.Name}</b>. {equipment.Amount}шт. \nОписание: {equipment.Description}. Вес: {equipment.Weight} \n \n";
                if (equipment is Weapon weapon)
                {
                    if (weapon.Properties.Length > 1)
                    {
                        string noWhitespace = Regex.Replace(weapon.Properties, @"\s+", "");
                        var weaponTraits = noWhitespace.Split(new char[] { ',' }).ToList();
                        foreach (var weaponTrait in weaponTraits)
                        {
                            if (!weaponTrait.Contains("("))
                            {    
                                _text.text += $"{weaponTrait} - {GetDescriptionWeaponTrait(weaponTrait)} \n\n";
                            }
                            else
                            {
                                int openBracketIndex = weaponTrait.IndexOf('(');
                                string name = weaponTrait.Substring(0, openBracketIndex).Trim();

                                _text.text += $"{weaponTrait} - {GetDescriptionWeaponTrait(weaponTrait)} \n\n";
                            }
                        }
                    }
                }
            }


            _text.text += $"<b>Традиция</b> - {character.Tradition} \n \n";

            _text.text += $"<b>Бонус Родного Мира</b> - {character.BonusHomeworld} \n \n";

            _text.text += $"<b>Бонус Предыстории</b> - {character.BonusBack} \n \n";

            _text.text += $"<b>Бонус Роли</b> - {character.BonusRole} \n \n";


            StartCoroutine(TakePauseForText());
        }

        IEnumerator TakePauseForText()
        {
            yield return new WaitForEndOfFrame();
            if (_text.textInfo.pageCount > 1)
            {
                _page = 1;
                base.PageSaved += PageSavedDown;
                StartScreenshot(PageName.Third.ToString(), true);
            }
            else
            {
                StartScreenshot(PageName.Third.ToString());
            }

        }

        private void PageSavedDown()
        {
            _page++;
            _text.pageToDisplay = _page;
            StartCoroutine(TakeAnotherPause());
        }

        IEnumerator TakeAnotherPause()
        {
            _text.pageToDisplay = _page;
            yield return new WaitForSeconds(0.2f);
            StartNextScreenshot();
        }

        private void StartNextScreenshot()
        {
            if (_page == _text.textInfo.pageCount)
                StartScreenshot($"{PageName.Third}+{_page}");
            else
                StartScreenshot($"{PageName.Third}+{_page}", true);
        }

        private string GetDescriptionWeaponTrait(string name)
        {
            var trait = _creatorWeaponTrait.Get(name);
            if (trait != null)
                return trait.Description;

            return "Описание не найдено";
        }

        private string GetDescriptionTrait(string name)
        {
            var trait = _creatorTraits.GetTrait(name);
            if(trait != null)
                return trait.Description;
            return "Описание не найдено";
        }

        private string GetDescriptionPsy(string name)
        {
            var trait = _creatorPsyPowers.GetPsyPower(name);
            if (trait != null)
                return trait.Description;
            return "Описание не найдено";
        }

        private string GetDescriptionTalent(string name)
        {
            var trait = _creatorTalents.GetTalent(name);
            if (trait != null)
                return trait.LongDescription;
            return "Описание не найдено";
        }
    }
}

