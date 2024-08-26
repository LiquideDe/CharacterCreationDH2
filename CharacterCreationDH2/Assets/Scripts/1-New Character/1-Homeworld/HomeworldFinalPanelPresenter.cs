using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class HomeworldFinalPanelPresenter : IPresenter
{
    public event Action<ICharacter> CharacterIsChosen;
    public event Action CancelChoice;
    private HomeworldFinalPanelView _panelView;
    private AudioManager _audioManager;
    private ICharacter _character;
    private ConfigForCharacterFromHomeworld _configs;
    private Homeworld _homeworld;
    private bool isFate, isWound, isAge, isHair, isTraditioan, isSkeen, isRemember, isBody, isEyes, isPhys;
    

    [Inject]
    private void Construct(AudioManager audioManager) => _audioManager = audioManager;

    public void Initialize(HomeworldFinalPanelView panelView, ICharacter character, Homeworld homeworld)
    {
        _panelView = panelView;
        _character = character;
        _configs = new ConfigForCharacterFromHomeworld();
        _homeworld = homeworld;
        Subscribe();
    }

    private void Subscribe()
    {
        _panelView.FateEntered += EnterFate;
        _panelView.ButtonFatePress += GenerateFate;

        _panelView.WoundEntered += EnterWound;
        _panelView.ButtonWoundPress += GenerateWound;

        _panelView.AgeEntered += EnterAge;
        _panelView.ButtonAgePress += GenerateAge;

        _panelView.HairEntered += EnterHair;
        _panelView.ButtonHairPress += GenerateHair;

        _panelView.TraditionEntered += EnterTradition;
        _panelView.ButtonTraditionPress += GenerateTradition;

        _panelView.SkeenEntered += EnterSkeen;
        _panelView.ButtonSkeenPress += GenerateSkeen;

        _panelView.RememberEntered += EnterRemember;
        _panelView.ButtonRememberPress += GenerateRemember;

        _panelView.BodyEntered += EnterBody;
        _panelView.ButtonBodyPress += GenerateBody;

        _panelView.EyesEntered += EnterEyes;
        _panelView.ButtonEyesPress += GenerateEyes;

        _panelView.PhysEntered += EnterPhys;
        _panelView.ButtonPhysPress += GeneratePhys;

        _panelView.Done += PressDone;
        _panelView.Cancel += PressCancel;
    }

    private void Unsubscribe()
    {
        _panelView.FateEntered -= EnterFate;
        _panelView.ButtonFatePress -= GenerateFate;

        _panelView.WoundEntered -= EnterWound;
        _panelView.ButtonWoundPress -= GenerateWound;

        _panelView.AgeEntered -= EnterAge;
        _panelView.ButtonAgePress -= GenerateAge;

        _panelView.HairEntered -= EnterHair;
        _panelView.ButtonHairPress -= GenerateHair;

        _panelView.TraditionEntered -= EnterTradition;
        _panelView.ButtonTraditionPress -= GenerateTradition;

        _panelView.SkeenEntered -= EnterSkeen;
        _panelView.ButtonSkeenPress -= GenerateSkeen;

        _panelView.RememberEntered -= EnterRemember;
        _panelView.ButtonRememberPress -= GenerateRemember;

        _panelView.BodyEntered -= EnterBody;
        _panelView.ButtonBodyPress -= GenerateBody;

        _panelView.EyesEntered -= EnterEyes;
        _panelView.ButtonEyesPress -= GenerateEyes;

        _panelView.PhysEntered -= EnterPhys;
        _panelView.ButtonPhysPress -= GeneratePhys;

        _panelView.Done -= PressDone;
        _panelView.Cancel -= PressCancel;
    }

    private void EnterFate(string value) => SetFate(TryParseStringToInt(value, 10));

    private void GenerateFate() => SetFate(PoleChudes.GenerateIntValue(10));

    private void SetFate(int porog)
    {
        if (porog == 0)
            return;

        _audioManager.PlayClick();
        int fate = _homeworld.Fatepoint;
        if (porog > _homeworld.PorogFatepoint)
            fate++;

        _configs.Fate = fate;

        _panelView.SetTextFate($"Ваши очки судьбы равны {fate}");
        isFate = true;
    }

    private void EnterWound(string value) => SetWound(TryParseStringToInt(value, 5));

    private void GenerateWound() => SetWound(PoleChudes.GenerateIntValue(5));

    private void SetWound(int addingWound)
    {
        if (addingWound == 0)
            return;

        _audioManager.PlayClick();
        int wounds = _homeworld.StartWound;
        wounds += addingWound;

        _configs.Wound = wounds;
        _panelView.SetTextWound($"Ваше здоровье равно {wounds}");
        isWound = true;
    }

    private void EnterAge(string value) => SetAge(TryParseStringToInt(value, 100));

    private void GenerateAge() => SetAge(PoleChudes.GenerateIntValue(100));

    private void SetAge(int d100)
    {
        if (d100 == 0)
            return;

        _audioManager.PlayClick();
        string age = PoleChudes.GetVariantFrom(_homeworld.AgeOptions, d100);
        int.TryParse(PoleChudes.GetVariantFrom(_homeworld.AgesIntOptions, d100), out int ageInt);

        _configs.Age = ageInt;
        _configs.AgeText = age;

        _panelView.SetTextAge($"В вашем возрасте вас называют как {age}");
        isAge = true;
    }

    private void EnterHair(string value) => SetHair(TryParseStringToInt(value, 100));

    private void GenerateHair() => SetHair(PoleChudes.GenerateIntValue(100));

    private void SetHair(int d100)
    {
        if (d100 == 0)
            return;

        _audioManager.PlayClick();
        string hair = PoleChudes.GetVariantFrom(_homeworld.HairOptions, d100);

        _configs.Hair = hair;
        _panelView.SetTextHair($"Ваши волосы {hair}");
        isHair = true;
    }

    private void EnterTradition(string value) => SetTradition(TryParseStringToInt(value,100));

    private void GenerateTradition() => SetTradition(PoleChudes.GenerateIntValue(100));

    private void SetTradition(int d100)
    {
        if (d100 == 0)
            return;

        _audioManager.PlayClick();
        string tradition = PoleChudes.GetVariantFrom(_homeworld.TraditionsOptions, d100);

        _configs.Tradition = tradition;
        string shortTradition = tradition.Substring(0, tradition.LastIndexOf(':') + 1);
        _panelView.SetTextTradition($"Вы придерживаетесь традиции: {shortTradition}");
        isTraditioan = true;
    }

    private void EnterSkeen(string value) => SetSkeen(TryParseStringToInt(value, 100));

    private void GenerateSkeen() => SetSkeen(PoleChudes.GenerateIntValue(100));

    private void SetSkeen(int d100)
    {
        if (d100 == 0)
            return;

        _audioManager.PlayClick();
        string skeen = PoleChudes.GetVariantFrom(_homeworld.SkeensOptions, d100);

        _configs.Skeen = skeen;
        _panelView.SetTextSkeen($"Ваша кожа {skeen}");
        isSkeen = true;
    }

    private void EnterRemember(string value) => SetRemember(TryParseStringToInt(value, 100));

    private void GenerateRemember() => SetRemember(PoleChudes.GenerateIntValue(100));

    private void SetRemember(int d100)
    {
        if (d100 == 0)
            return;

        _audioManager.PlayClick();
        string remember = PoleChudes.GetVariantFrom(_homeworld.RememberThingOptions, d100);

        _configs.Remember = remember;
        _panelView.SetTextRemember($"С вашего родного мира вы забрали с собой {remember}");
        isRemember = true;
    }

    private void EnterBody(string value) => SetBody(TryParseStringToInt(value, 100));

    private void GenerateBody() => SetBody(PoleChudes.GenerateIntValue(100));

    private void SetBody(int d100)
    {
        if (d100 == 0)
            return;

        _audioManager.PlayClick();
        string body = PoleChudes.GetVariantFrom(_homeworld.BodyOptions, d100);

        _configs.Body = body;
        _panelView.SetTextBody($"По вашему телосложению вас называют {body}");
        isBody = true;
    }

    private void EnterEyes(string value) => SetEyes(TryParseStringToInt(value, 100));

    private void GenerateEyes() => SetEyes(PoleChudes.GenerateIntValue(100));

    private void SetEyes(int d100)
    {
        if (d100 == 0)
            return;

        _audioManager.PlayClick();
        string eyes = PoleChudes.GetVariantFrom(_homeworld.EyesOptions, d100);

        _configs.Eyes = eyes;
        _panelView.SetTextEyes($"Ваши глаза {eyes}");
        isEyes = true;
    }

    private void EnterPhys(string value) => SetPhys(TryParseStringToInt(value, 100));

    private void GeneratePhys() => SetPhys(PoleChudes.GenerateIntValue(100));

    private void SetPhys(int d100)
    {
        if (d100 == 0)
            return;

        _audioManager.PlayClick();
        string phys = PoleChudes.GetVariantFrom(_homeworld.PhysOptions, d100);

        _configs.Phys = phys;
        _panelView.SetTextPhys(phys);
        isPhys = true;
    }

    private int TryParseStringToInt(string value, int maxInt)
    {
        int.TryParse(value, out int chislo);
        if (chislo > 0 && chislo <= maxInt)
            return chislo;
        else
            _audioManager.PlayWarning();

        return 0;
    }

    private void PressDone()
    {
        if (isAge && isBody && isEyes && isFate && isHair && isPhys && isRemember && isSkeen && isTraditioan && isWound)
        {
            _audioManager.PlayDone();
            _configs.HomeworldName = _homeworld.Name;
            _configs.Inclination = _homeworld.Inclination;
            _configs.AdvantageCharacteristicFirst = _homeworld.AdvantageCharacteristics[0];
            _configs.AdvantageCharacteristicSecond = _homeworld.AdvantageCharacteristics[1];
            _configs.DisadvantageCharacteristic = _homeworld.DisadvantageCharacteristic;
            _configs.BonusHomeworld = _homeworld.BonusFromHomeworld;

            _configs.SetSkills(_homeworld.Skills);

            if(_homeworld.GetTalents() != null)
                _configs.Talents.AddRange(_homeworld.GetTalents());

            CharacterWithHomeworld character = new CharacterWithHomeworld(_character);
            character.SetHomeWorld(_configs);
            CharacterIsChosen?.Invoke(character);
            Unsubscribe();
            _panelView.DestroyView();
            _panelView = null;
        }
        else
            _audioManager.PlayWarning();
    }

    private void PressCancel(CanDestroyView view)
    {
        _audioManager.PlayCancel();
        Unsubscribe();
        view.DestroyView();
        _panelView = null;
        CancelChoice?.Invoke();
    }
}
