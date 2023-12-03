using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondCharacterSheet : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textWound, textEquipments, textExpTotal, textExpUnspent, textExpSpent, textMoveHalf, textMoveFull, textNatisk, textRun, 
        textFatigue, textWeight, textWeightUp, textWeightPush, textBonus;
    [SerializeField] CanvasScreenShot screenShot;
    [SerializeField] WeaponBlock[] weaponBlocks;
    [SerializeField] ArmorBlock[] armorBlocks;
    [SerializeField] ArmorOnBody onBody;
    Canvas canvasToScreenShot;
    public delegate void EndGame();
    EndGame endGame;
    private void Awake()
    {
        canvasToScreenShot = GetComponent<Canvas>();
    }
    public void OpenSecondSheet(Character character)
    {
        onBody.SetToughness(character.Characteristics[3].Amount/10);
        textWound.text = character.Wounds.ToString();
        Debug.Log($"Всего жэкипировки {character.Equipments.Count}");
        foreach(Equipment eq in character.Equipments)
        {
            textEquipments.text += eq.Name + "\n";
        }
        textExpTotal.text = character.ExperienceTotal.ToString();
        textExpSpent.text = character.ExperienceSpent.ToString();
        textExpUnspent.text = character.ExperienceUnspent.ToString();
        textMoveHalf.text = character.HalfMove.ToString();
        textMoveFull.text = character.FullMove.ToString();
        textNatisk.text = character.Natisk.ToString();
        textRun.text = character.Run.ToString();
        textFatigue.text = character.Fatigue.ToString();
        textWeight.text = character.CarryWeight.ToString();
        textWeightPush.text = character.PushWeight.ToString();
        textWeightUp.text = character.LiftWeight.ToString();
        textBonus.text = character.BonusBack;
        foreach(Equipment equipment in character.Equipments)
        {
            if(equipment.TypeEq == Equipment.TypeEquipment.Weapon)
            {
                Debug.Log($"Нашли оружие");
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
                Debug.Log($"Нашли броню");
                foreach (ArmorBlock armorBlock in armorBlocks)
                {
                    if (armorBlock.IsEmpty)
                    {
                        Armor armor = (Armor)equipment;
                        armorBlock.FillBlock(armor);
                        break;
                    }
                }
            }
        }

        StartCoroutine(EndWork());
        
    }

    IEnumerator TakeScreenshot()
    {
        
        CanvasScreenShot.OnPictureTaken += receivePNGScreenShot;

        //take ScreenShot(Image and Text)
        screenShot.takeScreenShot(canvasToScreenShot, SCREENSHOT_TYPE.IMAGE_AND_TEXT);
        //take ScreenShot(Image only)
        //screenShot.takeScreenShot(canvasToScreenShot, SCREENSHOT_TYPE.IMAGE_ONLY, false);
        //take ScreenShot(Text only)
        // screenShot.takeScreenShot(canvasToScreenShot, SCREENSHOT_TYPE.TEXT_ONLY, false);
        yield return new WaitForSeconds(1);
    }

    IEnumerator EndWork()
    {
        yield return TakeScreenshot();
        endGame?.Invoke();
        Destroy(gameObject, 0.2f);
    }

    void receivePNGScreenShot(byte[] pngArray)
    {
        Debug.Log("Picture taken");

        //Do Something With the Image (Save)
        string path = Application.dataPath + "/StreamingAssets/CharacterSheets/CharacterSheetSecond.png";
        System.IO.File.WriteAllBytes(path, pngArray);
        Debug.Log(path);
        
    }

    public void RegDelegate(EndGame endGame)
    {
        this.endGame = endGame;
    }
}
