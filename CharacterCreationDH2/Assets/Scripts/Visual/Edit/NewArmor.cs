using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewArmor : CreatorNewEquipment
{
    [SerializeField] TMP_InputField inputArmorPoint, inputHeadPoint, inputHandsPoint, inputBodyPoint, inputLegsPoint, inputMaxAgility, inputProp;
    int armor, head, hands, body, legs, maxAgility;

    private void Start()
    {
        inputs.Add(inputName);
        inputs.Add(inputWeight);
        inputs.Add(inputArmorPoint);
        inputs.Add(inputHeadPoint);
        inputs.Add(inputHandsPoint);
        inputs.Add(inputBodyPoint);
        inputs.Add(inputLegsPoint);
        inputs.Add(inputMaxAgility);
        inputs.Add(inputProp);
    }
    public new void FinishCreating()
    {
        if(inputName.text.Length > 0 && inputWeight.text.Length > 0)
        {
            int.TryParse(inputArmorPoint.text, out armor);
            int.TryParse(inputHeadPoint.text, out head);
            int.TryParse(inputHandsPoint.text, out hands);
            int.TryParse(inputBodyPoint.text, out body);
            int.TryParse(inputLegsPoint.text, out legs);
            int.TryParse(inputMaxAgility.text, out maxAgility);
            float.TryParse(inputWeight.text, out weight);

            JSONArmorReader armorReader = new JSONArmorReader();
            armorReader.body = body;
            armorReader.hands = hands;
            armorReader.head = head;
            armorReader.legs = legs;
            armorReader.maxAgility = maxAgility;
            armorReader.name = inputName.text;
            armorReader.weight = weight;
            armorReader.armorPoint = armor;
            armorReader.description = "";
            if (head > 0 && hands > 0 && body > 0 && legs > 0)
            {
                armorReader.description += $"��������� ��� ����.";
                armorReader.descriptionArmor = $"��������� ��� ����.";
            }
            else if(head == 0 && hands > 0 && body > 0 && legs > 0)
            {
                armorReader.description += $"��������� ��� ���� ����� ������.";
                armorReader.descriptionArmor = $"��������� ��� ���� ����� ������.";
            }
            else if(head == 0 && hands == 0 && body > 0 && legs > 0)
            {
                armorReader.description += $"��������� ������ ���� � ����.";
                armorReader.descriptionArmor = $"��������� ������ ���� � ����.";
            }
            else if (head == 0 && hands == 0 && body > 0 && legs == 0)
            {
                armorReader.description += $"��������� ������ ����.";
                armorReader.descriptionArmor = $"��������� ������ ����.";
            }
            else if (head == 0 && hands > 0 && body > 0 && legs == 0)
            {
                armorReader.description += $"��������� ������ ���� � ����.";
                armorReader.descriptionArmor = $"��������� ������ ���� � ����.";
            }
            else if (head == 0 && hands > 0 && body == 0 && legs == 0)
            {
                armorReader.description += $"��������� ������ ����.";
                armorReader.descriptionArmor = $"��������� ������ ����.";
            }
            else if (head == 0 && hands == 0 && body == 0 && legs > 0)
            {
                armorReader.description += $"��������� ������ ����.";
                armorReader.descriptionArmor = $"��������� ������ ����.";
            }
            else if (head > 0 && hands == 0 && body == 0 && legs == 0)
            {
                armorReader.description += $"��������� ������ ������.";
                armorReader.descriptionArmor = $"��������� ������ ������.";
            }

            armorReader.description += $"����� {armor}, ������������ �������� {maxAgility}.";
            SaveEquipment($"{Application.dataPath}/StreamingAssets/Equipments/Armor/{armorReader.name}.JSON", armorReader);
            Armor armorEq = new Armor(armorReader);
            createNewEq?.Invoke(armorEq);
            ClearInputs();
            gameObject.SetActive(false);
        }
    }
}
