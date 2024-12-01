using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class WeaponBlock : MonoBehaviour
{
    [SerializeField] private
    TextMeshProUGUI textName, textClass, textRange, textRoF, textDamage,
        textPenetration, textClip, textReload, textProp;
    [SerializeField] private RawImage _image;    

    private bool isEmpty = true;
    public bool IsEmpty { get => isEmpty; }

    public void FillBlock(Weapon weapon)
    {
        if(weapon.TypeEq == Equipment.TypeEquipment.Range)
        {
            //Для кодировки к примеру возьмем стабревольвер. он будет выглядеть как W/Стабревольвер/1/0/0/6/0
            //W - оружие, Стабревольвер название, 1 одиночный выстрел, 0 - короткая очередь, 0 - длинная очередь, 6 - вместимость магазина, 0 - id звука

            textRange.text = weapon.Range.ToString();
            textClip.text = weapon.Clip.ToString();
            textReload.text = weapon.Reload;
            textRoF.text = weapon.Rof;
            if (weapon.Rof.Contains("/"))
            {
                List<string> rofs = weapon.Rof.Split(new char[] { '/' }).ToList();
                if (rofs.Count > 1)
                {
                    string textToCode = $"W/{weapon.Name}/{rofs[0]}/{rofs[1]}/{rofs[2]}/{weapon.Clip}/{weapon.TypeSound}";
                    _image.texture = new GeneratorQRCode().EncodeTextToQrCode(textToCode);
                }
            }

        }
        textName.text = weapon.NameWithAmount;
        textClass.text = weapon.ClassWeapon;   
        textDamage.text = weapon.Damage;
        textPenetration.text = weapon.Penetration.ToString();
        textProp.text = weapon.Properties;
        isEmpty = false;
    }

    
}
