using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstCharacterSheet : MonoBehaviour
{
    [SerializeField] SkillList[] skillSquares;
    [SerializeField] TextMeshProUGUI textName, textHomeworld, textBackstory, textRole, textProphecy, textGender, textAge, textSkeen, textPhys, textEyes,
        textTraditions, textMemories, textWeapon, textBallistic, textStrength, textToughness, textAgility, textIntelligence, textPerception, textWillpower,
        textFelloweship, textInfluence, textFate, textTalents, textBody, textHair;
    Canvas canvasToScreenShot;
    [SerializeField] CanvasScreenShot screenShot;
    [SerializeField] GameObject[] circlesWeapon;
    [SerializeField] GameObject[] circlesBallistic;
    [SerializeField] GameObject[] circlesStrength;
    [SerializeField] GameObject[] circlesToughness;
    [SerializeField] GameObject[] circlesAgility;
    [SerializeField] GameObject[] circlesIntelligence;
    [SerializeField] GameObject[] circlesPerception;
    [SerializeField] GameObject[] circlesWillpower;
    [SerializeField] GameObject[] circlesFellowship;
    private List<GameObject[]> circlesGroups = new List<GameObject[]>();

    public delegate void ShowNextSheet();
    ShowNextSheet nextSheet;

    private void Awake()
    {
        circlesGroups.Add(circlesWeapon);
        circlesGroups.Add(circlesBallistic);
        circlesGroups.Add(circlesStrength);
        circlesGroups.Add(circlesToughness);
        circlesGroups.Add(circlesAgility);
        circlesGroups.Add(circlesIntelligence);
        circlesGroups.Add(circlesPerception);
        circlesGroups.Add(circlesWillpower);
        circlesGroups.Add(circlesFellowship);
        canvasToScreenShot = GetComponent<Canvas>();
    }
    public void FillCharacterSheet(Character character)
    {
        textName.text = character.Name;
        textHomeworld.text = character.HomeWorld.NameWorld;
        textBackstory.text = character.Background;
        textRole.text = character.Role;
        textProphecy.text = character.Prophecy;
        textGender.text = character.Gender;
        textAge.text = character.Age.ToString();
        textSkeen.text = character.Skeen;
        textPhys.text = character.PhysFeatures;
        textEyes.text = character.Eyes;
        //textTraditions.text = character.HomeWorld.Traditions;
        textMemories.text = $"{character.MemoryOfHome}, {character.MemoryOfBackground}";
        textWeapon.text = character.Characteristics[0].Amount.ToString();
        textBallistic.text = character.Characteristics[1].Amount.ToString();
        textStrength.text = character.Characteristics[2].Amount.ToString();
        textToughness.text = character.Characteristics[3].Amount.ToString();
        textAgility.text = character.Characteristics[4].Amount.ToString();
        textIntelligence.text = character.Characteristics[5].Amount.ToString();
        textPerception.text = character.Characteristics[6].Amount.ToString();
        textWillpower.text = character.Characteristics[7].Amount.ToString();
        textFelloweship.text = character.Characteristics[8].Amount.ToString();
        textInfluence.text = character.Characteristics[9].Amount.ToString();

        textFate.text = character.FatePoint.ToString();
        textBody.text = character.Constitution;
        textHair.text = character.Hair;
        for (int i = 0; i < circlesGroups.Count; i++)
        {
            for(int j = 0; j < character.Characteristics[i].LvlLearned; j++)
            {
                circlesGroups[i][j].SetActive(true);
            }
        }
        foreach (Talent talent in character.Talents)
        {
            textTalents.text += $"{talent.Name}\n";
        }

        foreach (Skill skill in character.Skills)
        {
            if(skill.LvlLearned > 0)
            {
                ActivateSquare(skill);
            }
        }
        StartCoroutine(EndWork());
        


    }

    private void ActivateSquare(Skill skill)
    {
        if(!skill.IsKnowledge)
        {
            foreach (SkillList skillList in skillSquares)
            {
                if (skillList.SkillName == skill.InternalName)
                {

                    skillList.SetLvlLearned(skill.LvlLearned);
                    break;
                }
            }
        }
        else
        {
            foreach (SkillList skillList in skillSquares)
            {
                if (skillList.SkillName == skill.InternalName)
                {
                    if (skillList.KnowledgeTextName == "")
                    {
                        skillList.KnowledgeTextName = skill.Name;
                        skillList.SetLvlLearned(skill.LvlLearned);
                        break;
                    }
                }
            }
        }

        
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
        yield return new WaitForSeconds(2);
    }

    IEnumerator EndWork()
    {
        yield return TakeScreenshot();
        nextSheet?.Invoke();
    }

    void receivePNGScreenShot(byte[] pngArray)
    {
        Debug.Log("Picture taken");

        //Do Something With the Image (Save)
        string path = Application.dataPath + "/StreamingAssets/CharacterSheets/CharacterSheetFirst.png";        
        System.IO.File.WriteAllBytes(path, pngArray);
        Debug.Log(path);
        CanvasScreenShot.OnPictureTaken -= receivePNGScreenShot;
    }

    public void RegDelegate(ShowNextSheet nextSheet)
    {
        this.nextSheet = nextSheet;
    }
}
