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
    protected CreatorImplant creatorImplant;
    protected AudioWork audioWork;

    protected void InitialCreators(string path)
    {
        creatorEquipment = new CreatorEquipment();
        creatorSkills = new CreatorSkills();
        creatorTalents = new CreatorTalents();
        creatorFeatures = new CreatorFeatures();
        creatorImplant = new CreatorImplant();
        character = new Character(creatorSkills.Skills, creatorEquipment);
        Load load = new Load();
        load.LoadCharacter(character, path);
        character.LoadImplants(creatorImplant);
        creatorPsyPowers = new CreatorPsyPowers(character.PsyPowers);
    }

    public void RegDelegate(BackToMenu backToMenu, AudioWork audioWork)
    {
        this.backToMenu = backToMenu;
        this.audioWork = audioWork;
    }

    public void SaveAndExit()
    {
        audioWork.PlayClick();
        Save save = new Save(character);
        ScreenshotObserver screenshotObserver = gameObject.AddComponent<ScreenshotObserver>();
        screenshotObserver.RegDelegate(JustExit);
        screenshotObserver.OpenScreenShots(character, firstSheet, secondSheet);
    }

    public void SaveAndExitToMenu()
    {
        audioWork.PlayClick();
        Save save = new Save(character);
        ScreenshotObserver screenshotObserver = gameObject.AddComponent<ScreenshotObserver>();
        screenshotObserver.RegDelegate(ExitToMainMenu);
        screenshotObserver.OpenScreenShots(character, firstSheet, secondSheet);
    }

    public void JustExit()
    {
        audioWork.PlayClick();
        Application.OpenURL((Application.dataPath) + "/StreamingAssets/CharacterSheets");
        Application.Quit();
    }
    protected void Finish()
    {
        audioWork.PlayClick();
        exitPanel.SetActive(true);
    }
    private void ExitToMainMenu()
    {
        audioWork.PlayClick();
        backToMenu?.Invoke();
        Destroy(gameObject);
    }
}
