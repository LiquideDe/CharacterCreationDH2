using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationWithCharacter : MonoBehaviour
{
    public delegate void BackToMenu();
    protected Character character;
    protected BackToMenu backToMenu;
    [SerializeField] protected SkillTrainingCanvas skillTrainingCanvas;
    [SerializeField] protected TalentTrainingCanvas talentTrainingCanvas;
    [SerializeField] protected PsyCanvas psyCanvas;
    [SerializeField] protected GameObject exitPanel;
    [SerializeField] private FirstCharacterSheet firstSheet;
    [SerializeField] private SecondCharacterSheet secondSheet;
    protected CreatorEquipment creatorEquipment;
    protected CreatorSkills creatorSkills;
    protected CreatorTalents creatorTalents;
    protected CreatorPsyPowers creatorPsyPowers;
    protected CreatorFeatures creatorFeatures;

    protected void InitialCreators(string path)
    {
        creatorEquipment = new CreatorEquipment();
        creatorSkills = new CreatorSkills();
        creatorTalents = new CreatorTalents();
        creatorFeatures = new CreatorFeatures();
        character = new Character(creatorSkills.Skills, creatorEquipment);
        Load load = new Load();
        load.LoadCharacter(character, path);
        creatorPsyPowers = new CreatorPsyPowers(character.PsyPowers);
    }

    public void RegDelegate(BackToMenu backToMenu)
    {
        this.backToMenu = backToMenu;
    }

    public void SaveAndExit()
    {
        Save save = new Save(character);
        ScreenshotObserver screenshotObserver = gameObject.AddComponent<ScreenshotObserver>();
        screenshotObserver.RegDelegate(JustExit);
        screenshotObserver.OpenScreenShots(character, firstSheet, secondSheet);
    }

    public void SaveAndExitToMenu()
    {
        Save save = new Save(character);
        ScreenshotObserver screenshotObserver = gameObject.AddComponent<ScreenshotObserver>();
        screenshotObserver.RegDelegate(ExitToMainMenu);
        screenshotObserver.OpenScreenShots(character, firstSheet, secondSheet);
    }

    public void JustExit()
    {
        Application.OpenURL((Application.dataPath) + "/StreamingAssets/CharacterSheets");
        Application.Quit();
    }
    protected void Finish()
    {
        exitPanel.SetActive(true);
    }
    private void ExitToMainMenu()
    {
        backToMenu?.Invoke();
        Destroy(gameObject);
    }
}
