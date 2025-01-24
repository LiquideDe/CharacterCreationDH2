using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class BackgroundFinalPanelPresenter : IPresenter
{
    public event Action<ICharacter> CharacterIsChosen;
    public event Action CancelChoice;

    private CreatorTogglesForFinalPanel _creatorToggles;
    private BackgroundFinalPanelView _view;
    private AudioManager _audioManager;
    private ICharacter _character;
    private Background _background;
    private CreatorEquipment _creatorEquipment;

    public BackgroundFinalPanelPresenter(BackgroundFinalPanelView view, AudioManager audioManager, ICharacter character, Background background, CreatorEquipment creatorEquipment)
    {
        _view = view;
        _audioManager = audioManager;
        _character = character;
        _background = background;
        _creatorToggles = view.gameObject.GetComponent<CreatorTogglesForFinalPanel>();
        _creatorEquipment = creatorEquipment;
        Subscribe();
        CreateToggles();
    }

    private void CreateToggles()
    {
        if(_background.Skills.Count > 0)
        {
            if (_background.Skills[0][0].IsKnowledge)
                    _creatorToggles.CreateToggles(_background.Skills, "Знания");
            else
                _creatorToggles.CreateToggles(_background.Skills, "Навыки");
        }           
        

        if(_background.Talents.Count > 0)       
            _creatorToggles.CreateToggles(_background.Talents, "Таланты");       
        

        if(_background.Equipments.Count > 0)
            _creatorToggles.CreateToggleEquipments(_background.Equipments);
        

        if (_background.MechImplants.Count > 0)
            _creatorToggles.CreateToggles(_background.MechImplants, "Импланты");

        if (_background.Traits.Count > 0)
            _creatorToggles.CreateToggles(_background.Traits, "Черты");

        if(_background.Inclinations.Count > 0)
        {
            List<List<GameStat.Inclinations>> inclinationList = new List<List<GameStat.Inclinations>>();
            inclinationList.Add(new List<GameStat.Inclinations>());
            inclinationList[0].AddRange(_background.Inclinations);
            _creatorToggles.CreateToggleInclinations(inclinationList);
        }
            

        _creatorToggles.FinalResize();
    }

    private void Subscribe()
    {
        _view.Done += DoneDown;
        _view.Cancel += CancelDown;
    }

    private void Unsubscribe()
    {
        _view.Done -= DoneDown;
        _view.Cancel -= CancelDown;
    }

    private void CancelDown(CanDestroyView view)
    {
        _audioManager.PlayCancel();
        CancelChoice?.Invoke();
        Unsubscribe();
        view.DestroyView();
    }

    private void DoneDown()
    {
        _audioManager.PlayDone();
        List<ToggleGroup> toggleGroups = _view.GetToggles();
        Unsubscribe();
        _view.DestroyView();
        ConfigForCharacterFromBackground config = new ConfigForCharacterFromBackground();
        config.Bonus = _background.BonusText;
        config.Name = _background.Name;

        int sch = 0;
        List<Skill> skills = new List<Skill>();
        foreach (List<Skill> sk in _background.Skills)
        {
            if (sk.Count > 1)            
                skills.Add(sk[toggleGroups[sch].ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id]);            
            else            
                skills.Add(sk[0]);            
            sch++;
        }

        List<Talent> talents = new List<Talent>();
        foreach (List<Talent> tal in _background.Talents)
        {
            if (tal.Count > 1)            
                talents.Add(tal[toggleGroups[sch].ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id]);            
            else            
                talents.Add(tal[0]);            
            sch++;
        }

        List<Equipment> equipments = new List<Equipment>();
        foreach (List<Equipment> eq in _background.Equipments)
        {
            if (eq.Count > 1) 
            {
                if(eq[toggleGroups[sch].ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id].TypeEq == Equipment.TypeEquipment.Special)
                {
                    Equipment equipment = eq[toggleGroups[sch].ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id];
                    Special special = (Special) equipment;
                    equipments.Add(_creatorEquipment.GetEquipment(special.FirstName));
                    equipments[^1].Amount = special.AmountFirst;
                    equipments.Add(_creatorEquipment.GetEquipment(special.SecondName));
                    equipments[^1].Amount = special.AmountSecond;
                }
                else
                {
                    equipments.Add(eq[toggleGroups[sch].ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id]);
                }
            }                                    
            else            
                equipments.Add(eq[0]);            
            sch++;
        }

        List<MechImplant> implants = new List<MechImplant>();
        foreach(List<MechImplant> implant in _background.MechImplants)
        {
            if (implant.Count > 1)
                implants.Add(implant[toggleGroups[sch].ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id]);
            else
                implants.Add(implant[0]);
            sch++;
        }
        List<Trait> traits = new List<Trait>();
        foreach (List<Trait> trait in _background.Traits)
        {
            if (trait.Count > 1)
                traits.Add(trait[toggleGroups[sch].ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id]);
            else
                traits.Add(trait[0]);
            sch++;
        }

        config.Inclination = _background.Inclinations[toggleGroups[sch].ActiveToggles().FirstOrDefault().GetComponent<MyToggle>().Id];

        config.RememberThing = PoleChudes.GetVariantFrom(_background.RememberThings, PoleChudes.GenerateIntValue(100));

        config.SetSkills(skills);
        config.SetTalents(talents);
        config.SetEquipment(equipments);
        config.SetImplants(implants);
        config.SetTraits(traits);

        CharacterWithBackground character = new CharacterWithBackground(_character);
        character.SetBackground(config);

        CharacterIsChosen?.Invoke(character);
    }
}
