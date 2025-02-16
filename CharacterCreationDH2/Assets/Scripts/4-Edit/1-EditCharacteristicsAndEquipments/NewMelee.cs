using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class NewMelee : CreatorNewEquipment
{
    public event Action NeedInProperties;
    [SerializeField] protected Button _buttonAddProperty;
    [SerializeField] private Button _buttonDamageDice;
    [SerializeField] private TextMeshProUGUI _textDamageDice;
    public TMP_InputField inputClass, inputDamage, inputBonusDamage, inputPenetration;
    public MyDropDown _dropDown;
    public Transform content;
    public ItemWithNumberInList itemPrefab;
    List<ItemWithNumberInList> items = new List<ItemWithNumberInList>();
    private readonly string[] _dices = new string[2] {"к10", "к5"};
    protected bool _isNewWeapon = true;

    public override void Initialize()
    {
        base.Initialize();
        _buttonAddProperty.onClick.AddListener(NeedInPropertiesPressed);
        _buttonDamageDice.onClick.AddListener(ChangeTextDamageDice);
        List<string> options = new List<string>() { "Взрывной", "Режущий", "Ударный", "Энергетический"};
        _dropDown.AddOptions(options);
    }    

    public virtual void SetWeapon(Weapon weapon)
    {
        _isNewWeapon = false;
        _inputName.text = weapon.Name;
        _inputName.interactable = false;
        inputClass.text = weapon.ClassWeapon;
        inputPenetration.text = weapon.Penetration.ToString();
        _inputWeight.text = weapon.Weight.ToString();
        _inputRarity.text = weapon.Rarity.ToString();

        int amount;
        string dice;
        int bonusDamage = 0;
        string typeDamage;

        if (weapon.Damage.Contains('+'))
        {
            string[] parts = weapon.Damage.Split('+');

            string dicePart = parts[0];
            amount = int.Parse(dicePart.Split('к')[0]);
            dice = "к" + dicePart.Split('к')[1];

            string bonusPart = parts[1];
            bonusDamage = int.Parse(bonusPart.Substring(0, bonusPart.Length - 1));
            typeDamage = bonusPart.Substring(bonusPart.Length - 1);
        }
        else
        {
            string dicePart = weapon.Damage;
            amount = int.Parse(dicePart.Split('к')[0]);
            dice = "к" + dicePart.Split('к')[1].Substring(0, dicePart.Split('к')[1].Length - 1);
            typeDamage = dicePart.Substring(dicePart.Length - 1);
        }

        inputDamage.text = amount.ToString();
        inputBonusDamage.text = bonusDamage.ToString();

        switch (typeDamage)
        {
            case "В":
                _dropDown.Value = 0;
                break;
            case "Р":
                _dropDown.Value = 1;
                break;
            case "У":
                _dropDown.Value = 2;
                break;
            case "Э":
                _dropDown.Value = 3;
                break;
        }
                
        var properties = weapon.Properties.Split(new char[] { ',' }).ToList();
        foreach (var item in properties)
        {
            if (item.Contains("("))
            {
                int openBracketIndex = item.IndexOf('(');
                int closeBracketIndex = item.IndexOf(")");
                string name = item.Substring(0, openBracketIndex).Trim();
                string stringInt = item.Substring(openBracketIndex + 1, closeBracketIndex - (openBracketIndex + 1));
                int.TryParse(stringInt, out int value);
                AddProperty(name, value);
            }                
            else
                AddProperty(item);
        }
    }

    public override void FinishCreating()
    {
        if (_inputName.text != "" && inputClass.text.Length > 0 && inputPenetration.text.Length > 0 && _inputWeight.text.Length > 0)
        {
            float.TryParse(_inputWeight.text, out float weight);
            int.TryParse(inputPenetration.text, out int penetration);
            JSONMeleeReader meleeReader = new JSONMeleeReader
            {
                name = _inputName.text,
                penetration = penetration,
                properties = TranslatePropertiesToText(),
                weaponClass = inputClass.text,
                weight = weight,
                damage = MakeDamageText(),
                typeEquipment = Equipment.TypeEquipment.Melee.ToString(),
                amount = 1,
                rarity = _inputRarity.text,
                description = _inputDescription.text
                
            };

            if (_isNewWeapon)
                SaveEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Weapons/Melee/{meleeReader.name}.JSON", meleeReader);

            Weapon weapon = new Weapon(meleeReader);
            SendEquipment(weapon);
        }
        else
            WrongInputPressed();
    }

    public override void AddProperty(string property, int lvl = 0)
    {
        ItemWithNumberInList item = Instantiate(itemPrefab, content);
        item.RemoveThisItem += RemoveThisProperty;
        item.Initialize(property, lvl);
        items.Add(item);
    }

    protected string MakeDamageText()
    {
        string typeDamage = "";
        switch (_dropDown.Value)
        {
            case 0:
                typeDamage = "В";
                break;
            case 1:
                typeDamage = "Р";
                break;
            case 2:
                typeDamage = "У";
                break;
            case 3:
                typeDamage = "Э";
                break;
        }
        int.TryParse(inputDamage.text, out int damage);
        int.TryParse(inputBonusDamage.text, out int bonusDamage);
        if(damage == 0)
        {
            damage = 1;
        }
        string textdamage = $"{damage}{_textDamageDice.text}";

        if (bonusDamage != 0)        
            textdamage += $"+{bonusDamage}{typeDamage}";        
        else
            textdamage += $"{typeDamage}";

        
        return textdamage;
    }

    private void ChangeTextDamageDice()
    {
        _audio.PlayClick();
        if (_textDamageDice.text == _dices[0])
            _textDamageDice.text = _dices[1];
        else
            _textDamageDice.text = _dices[0];
    }    

    private void RemoveThisProperty(string name)
    {
        foreach(ItemWithNumberInList item in items)
        {
            if(string.Compare(item.Name, name, true) == 0)
            {
                items.Remove(item);
                Destroy(item.gameObject);                
                break;
            }
        }
    }

    protected string TranslatePropertiesToText()
    {
        string properties = "";
        foreach(ItemWithNumberInList item in items)
        {
            int.TryParse(item.Lvl, out int lvl);
            if(lvl != 0)
            {
                properties += $"{item.Name}({lvl}),";
            }
            else
            {
                properties += $"{item.Name},";
            }
            
        }
        properties = properties.TrimEnd(',');
        return properties;
    }

    private void NeedInPropertiesPressed() => NeedInProperties?.Invoke();

}
