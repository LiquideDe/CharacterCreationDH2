using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class ThirdCharacterSheet : TakeScreenshot
{
    [SerializeField] private TextMeshProUGUI _text, _textNameCharacter;
    private CreatorTalents _creatorTalents;
    private CreatorPsyPowers _creatorPsyPowers;
    private CreatorTraits _creatorFeatures;
    private int _page;

    [Inject]
    private void Construct(CreatorTalents creatorTalents, CreatorPsyPowers creatorPsyPowers, CreatorTraits creatorFeatures)
    {
        _creatorTalents = creatorTalents;
        _creatorPsyPowers = creatorPsyPowers;
        _creatorFeatures = creatorFeatures;
    }

    public void Initialize(ICharacter character)
    {
        _character = character;
        _textNameCharacter.text = _character.Name;

        _text.text += $"<indent=15%><size=150%>Таланты:</indent> \n<size=100%>";

        foreach (Talent talent in character.Talents)        
            _text.text += $"<b>{talent.Name}</b> - {_creatorTalents.GetTalent(talent.Name).LongDescription} \n \n";

        if(character.PsyPowers.Count > 0)
        {
            _text.text += $"<indent=15%><size=150%>Психо-силы:</indent> \n<size=100%>";
            foreach (PsyPower psyPower in character.PsyPowers)
                _text.text += $"<b>{psyPower.Name}</b> - Действие:{_creatorPsyPowers.GetPsyPower(psyPower.Name).Action}, {_creatorPsyPowers.GetPsyPower(psyPower.Name).Description} \n \n";

        }

        if(character.Implants.Count > 0)
        {
            _text.text += $"<indent=15%><size=150%>Импланты:</indent> \n<size=100%>";
            foreach (MechImplant implant in character.Implants)
                if (implant.Description.Length > 1)
                    _text.text += $"<b>{implant.Name}</b> - {implant.Description}\n \n";
        }        

        _text.text += $"<indent=15%><size=150%>Особенности:</indent> \n<size=100%>";
        foreach (Trait feature in character.Traits)
            _text.text += $"<b>{feature.Name}</b> - {_creatorFeatures.GetTrait(feature.Name).Description}\n \n";

        _text.text += $"<indent=15%><size=150%>Экипировка:</indent> \n<size=100%>";
        foreach (Equipment equipment in character.Equipments)
            _text.text += $"<b>{equipment.Name}</b>. Описание: {equipment.Description}. Вес: {equipment.Weight} \n \n";

        _text.text += $"{character.Tradition} \n \n";

        _text.text += $"{character.BonusHomeworld} \n \n";

        _text.text += $"{character.BonusBack} \n \n";

        _text.text += $"{character.BonusRole} \n \n";


        StartCoroutine(TakePauseForText());



        
    }

    IEnumerator TakePauseForText()
    {
        yield return new WaitForEndOfFrame();
        if(_text.textInfo.pageCount > 1)
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
}
