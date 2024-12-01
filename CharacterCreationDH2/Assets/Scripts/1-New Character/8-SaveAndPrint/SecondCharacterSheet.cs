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

    public override void Initialize(ICharacter character)
    {
        base.Initialize(character);
        gameObject.SetActive(true);
        _character = character;
        onBody.SetToughness(character.BonusToughness, character.Characteristics[GameStat.CharacteristicToInt["Сила Воли"]].Amount/10);
        textWound.text = character.Wounds.ToString();
        textMoveHalf.text = character.HalfMove.ToString();
        textMoveFull.text = character.FullMove.ToString();
        textNatisk.text = character.Natisk.ToString();
        textRun.text = character.Run.ToString();
        textFatigue.text = character.Fatigue.ToString();
        textWeight.text = character.CarryWeight.ToString();
        textWeightPush.text = character.PushWeight.ToString();
        textWeightUp.text = character.LiftWeight.ToString();
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
            else if (equipment.TypeEq == Equipment.TypeEquipment.Armor)
            {
                foreach (ArmorBlock armorBlock in armorBlocks)
                {
                    if (armorBlock.IsEmpty)
                    {
                        Armor armor = (Armor)equipment;
                        armorBlock.FillBlock(armor, character.Implants);
                        break;
                    }
                }
            }
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
        List<string> nameBackgrounds = new List<string>();
        List<string> dirs = new List<string>();
        int backId = 0;
        dirs.AddRange(Directory.GetDirectories($"{Application.dataPath}/StreamingAssets/Backgrounds"));
        foreach(string dir in dirs)
        {
            nameBackgrounds.Add(GameStat.ReadText($"{dir}/Название.txt"));
        }

        for(int i = 0; i < nameBackgrounds.Count; i++)
        {
            if (string.Compare(nameBackgrounds[i], character.Background, true) == 0)
            {
                backId = i;
                break;
            }
        }
        string pathImage;
        if(character.Gender == "М")
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
