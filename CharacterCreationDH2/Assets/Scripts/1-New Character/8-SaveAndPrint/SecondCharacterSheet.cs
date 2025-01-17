using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;

public class SecondCharacterSheet : CharacterSheetWithCharacteristics
{
    [SerializeField] private TextMeshProUGUI textWound, textMoveHalf, textMoveFull, textNatisk, textRun, 
        textFatigue, textWeight, textWeightUp, textWeightPush, _textNameCharacter;
    [SerializeField] private WeaponBlock[] weaponBlocks;
    [SerializeField] private ArmorBlock[] armorBlocks;
    [SerializeField] private ArmorOnBody onBody;
    [SerializeField] private Image characterImage;
    [SerializeField] private Sprite _ispritePsyRateAstraTelepatica, _spritePsyRateInquisition;
    [SerializeField] private TextMeshProUGUI _textPsyRate, _textPsyRateMax;
    [SerializeField] private Image _imagePsyRate;

    public override void Initialize(ICharacter character)
    {
        base.Initialize(character);
        gameObject.SetActive(true);
        _character = character;
        int.TryParse(BonusStrength, out int strengthBonus);
        int.TryParse(Strength, out int strength);
        int.TryParse(BonusToughness, out int toughness);
        int.TryParse(BonusAgility, out int agility);
        int.TryParse(BonusWillpower, out int willpower);

        if (strengthBonus == 0)
            strength = strength / 10;
        else
            strength = strengthBonus;

        if (toughness == 0)
            toughness = character.Characteristics[GameStat.CharacteristicToInt["Выносливость"]].Amount / 10;

        if (agility == 0)
            agility = character.Characteristics[GameStat.CharacteristicToInt["Ловкость"]].Amount / 10;

        if (willpower == 0)
            willpower = character.Characteristics[GameStat.CharacteristicToInt["Сила Воли"]].Amount / 10;

        List<float> _parametrsForWeight = new List<float>() { 0.9f, 2.25f, 4.5f, 9f, 18f, 27f, 36f, 45f, 56f, 67f, 78f, 90f,
            112f, 225f, 337f, 450f, 675f, 900f, 1350f, 1800f, 2250f, 2900f, 3550f, 4200f, 4850f, 5500f, 6300f, 7250f, 8300f, 9550f, 11000,
        13000, 15000, 17000, 20000, 23000, 26000, 30000, 35000, 40000, 46000, 53000, 70000, 80000, 92000, 106000};

        onBody.SetToughness(toughness, character.Characteristics[GameStat.CharacteristicToInt["Сила Воли"]].Amount/10);
        textWound.text = character.Wounds.ToString();
        
        _textNameCharacter.text = $"Имя персонажа: <u>{character.Name}</u>";
        foreach(Equipment equipment in character.Equipments)
        {
            if(equipment.TypeEq == Equipment.TypeEquipment.Melee || equipment.TypeEq == Equipment.TypeEquipment.Range || equipment.TypeEq == Equipment.TypeEquipment.Grenade)
            {
                foreach (WeaponBlock block in weaponBlocks)
                {
                    if (block.IsEmpty)
                    {
                        Weapon weapon = (Weapon)equipment;
                        block.FillBlock(weapon);
                        break;
                    }
                }
            }
            else if (equipment.TypeEq == Equipment.TypeEquipment.Armor || equipment.TypeEq == Equipment.TypeEquipment.Shield)
            {
                foreach (ArmorBlock armorBlock in armorBlocks)
                {
                    if (armorBlock.IsEmpty)
                    {
                        Armor armor = (Armor)equipment;
                        armorBlock.FillBlock(armor, character.Implants, character.Traits);
                        break;
                    }
                }
            }
        }        
        
        textMoveHalf.text = $"{agility}" ;
        textMoveFull.text = $"{agility * 2}";
        textNatisk.text = $"{agility * 3}";
        textRun.text = $"{agility * 3 * 2}";
        textFatigue.text = $"{toughness + willpower}";
        textWeight.text = $"{_parametrsForWeight[strength + toughness]}";
        textWeightPush.text = $"{_parametrsForWeight[strength + toughness] * 4}";
        textWeightUp.text = $"{_parametrsForWeight[strength + toughness] * 2}";

        if(character.PsyRating > 0)
        {
            _imagePsyRate.gameObject.SetActive(true);
            if (string.Compare(character.Background, "Адептус Астра Телепатика", true) == 0)
            {
                _imagePsyRate.sprite = _ispritePsyRateAstraTelepatica;
                _textPsyRateMax.text = (character.PsyRating + 2).ToString();
            }                
            else
            {
                _imagePsyRate.sprite = _spritePsyRateInquisition;
                _textPsyRateMax.text = (character.PsyRating + 4).ToString();
            }               
            _textPsyRate.text = character.PsyRating.ToString();
        }

        onBody.GenerateQr();
        StartCoroutine(ReadyToStart(character));
    }

    IEnumerator ReadyToStart(ICharacter character)
    {
        yield return StartCoroutine(GetImage(character));
        StartScreenshot(PageName.Second.ToString());
    }

    IEnumerator GetImage(ICharacter character)
    {
        string pathImage = "";
        List<string> pathImages = new List<string>();
        if (Directory.Exists($"{Application.dataPath}/StreamingAssets/CharacterSheets/{character.Name}"))
        {
            pathImages = Directory.GetFiles($"{Application.dataPath}/StreamingAssets/CharacterSheets/{character.Name}", "*.jpeg").ToList();
            pathImages.AddRange(Directory.GetFiles($"{Application.dataPath}/StreamingAssets/CharacterSheets/{character.Name}", "*.jpg").ToList());
            if(pathImages.Count > 0)
            {
                if (pathImages[0] != null)
                    pathImage = pathImages[0];
            }
                
        }
        if (pathImage.Length < 2)
        {
            List<string> nameBackgrounds = new List<string>();
            List<string> dirs = new List<string>();
            int backId = 0;
            dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Backgrounds"));
            foreach (string dir in dirs)
            {
                nameBackgrounds.Add(GameStat.ReadText($"{dir}/Название.txt"));
            }

            for (int i = 0; i < nameBackgrounds.Count; i++)
            {
                if (string.Compare(nameBackgrounds[i], character.Background, true) == 0)
                {
                    backId = i;
                    break;
                }
            }

            if (character.Gender == "М")
            {
                string[] imagesF = Directory.GetFiles($"{dirs[backId]}/CharacterImage/Male", "*.jpg");
                string[] imagesS = Directory.GetFiles($"{dirs[backId]}/CharacterImage/Male", "*.jpeg");
                string[] images = imagesF.Concat(imagesS).ToArray();
                pathImage = images[0];
            }
            else
            {
                string[] imagesF = Directory.GetFiles($"{dirs[backId]}/CharacterImage/Female", "*.jpg");
                string[] imagesS = Directory.GetFiles($"{dirs[backId]}/CharacterImage/Female", "*.jpeg");
                string[] images = imagesF.Concat(imagesS).ToArray();
                pathImage = images[0];
            }

        }


        Sprite sprite = ReadImage(pathImage);

        characterImage.sprite = sprite;
        yield return new WaitForSeconds(0.1f);
    }

    
    private Sprite ReadImage(string path)
    {
        if (string.IsNullOrEmpty(path)) return null;
        if (System.IO.File.Exists(path))
        {

            int sprite_width = 100;
            int sprite_height = 100;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(sprite_width, sprite_height, TextureFormat.RGB24, false);
            texture.LoadImage(bytes);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            return sprite;
        }
        return null;
    }

}
