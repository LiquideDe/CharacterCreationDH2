﻿using UnityEngine;
using Zenject;

namespace CharacterCreation
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private MainMenuView _viewPrefab;
        [SerializeField] private GameObject _canvasLoadPrefab;
        private LvlMediator _lvlMediator;
        private int _amountCreatorsDone = 0;
        private GameObject _canvasLoad;

        private void Start()
        {
            _canvasLoad = Instantiate(_canvasLoadPrefab);
        }

        [Inject]
        private void Construct(LvlMediator lvlMediator, CreatorTalents creatorTalents, CreatorWeaponTrait creatorWeaponTrait,
            CreatorPsyPowers creatorPsyPowers, CreatorTraits creatorTraits, CreatorImplant creatorImplant, CreatorSkills creatorSkills, CreatorEquipment creatorEquipment)
        {
            _lvlMediator = lvlMediator;
            creatorTalents.CreateTalentIsDone += FinishCreating;
            creatorPsyPowers.PsyPowersIsCreated += FinishCreating;
            creatorTraits.TraitsIsCreated += FinishCreating;
            creatorImplant.CreatingImplantIsDone += FinishCreating;
            creatorSkills.SkillsIsCreated += FinishCreating;
            creatorEquipment.RangeIsDone += FinishCreating;
            creatorEquipment.MeleeIsDone += FinishCreating;
            creatorEquipment.GrenadeIsDone += FinishCreating;
            creatorEquipment.SpecialIsDone += FinishCreating;
            creatorEquipment.ArmorIsDone += FinishCreating;
            creatorEquipment.ThingIsDone += FinishCreating;
            creatorWeaponTrait.TraitsIsCreated += FinishCreating;


            creatorTalents.StartCreating();
            creatorPsyPowers.StartCreating();
            creatorTraits.StartCreating();
            creatorImplant.StartCreate();
            creatorSkills.StartCreating();
            creatorEquipment.StartCreating();
            creatorWeaponTrait.StartCreating();
        }

        private void FinishCreating()
        {
            _amountCreatorsDone++;
            if (_amountCreatorsDone == 12)
            {
                Destroy(_canvasLoad);
                _lvlMediator.MainMenu();
            }

        }
    }
}

