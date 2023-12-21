using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class WeaponBlock : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textName, textClass, textRange, textRoFSingle, textRoFShort, textRoFLong, textDamage,
        textPenetration, textClip, textReload, textProp;
    private bool isEmpty = true;
    public bool IsEmpty { get => isEmpty; }
    public void FillBlock(Weapon weapon)
    {
        textName.text = weapon.Name;
        textClass.text = weapon.ClassWeapon;
        textRange.text = weapon.Range.ToString();
        Debug.Log($"имя оружия {weapon.Name}");
        if (weapon.Rof.Contains("/"))
        {
            List<string> rofs = weapon.Rof.Split(new char[] { '/' }).ToList();
            if (rofs.Count > 1)
            {
                textRoFSingle.text = rofs[0];
                textRoFShort.text = rofs[1];
                textRoFLong.text = rofs[2];
            }
        }
        
        textDamage.text = weapon.Damage;
        textPenetration.text = weapon.Penetration.ToString();
        textClip.text = weapon.Clip.ToString();
        textReload.text = weapon.Reload;
        textProp.text = weapon.Properties;
        isEmpty = false;
    }
}
