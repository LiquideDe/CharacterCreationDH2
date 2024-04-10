using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleObserver : MonoBehaviour
{
    public delegate void FinishChooseRole(Role role);
    private CreatorRole creatorRole;
    private RoleVisual roleVisual;
    private FinishChooseRole finishChooseRole;

    public void OpenRoleCanvas(RoleVisual roleVisual, CreatorTalents creatorTalents, AudioWork audioWork)
    {
        
        creatorRole = new CreatorRole();
        this.roleVisual = Instantiate(roleVisual);
        this.roleVisual.RegDelegate(ShowNextRole, ShowPrevRole);
        this.roleVisual.RegFinalDelegate(Finish);
        this.roleVisual.OpenRole(creatorRole.GetNextRole(), creatorTalents);
        this.roleVisual.SetAudio(audioWork);
    }

    public void RegDelegate(FinishChooseRole finishChooseRole)
    {
        this.finishChooseRole = finishChooseRole;
    }

    private void ShowNextRole()
    {
        roleVisual.ShowRole(creatorRole.GetNextRole());
    }

    private void ShowPrevRole()
    {
        roleVisual.ShowRole(creatorRole.GetPrevRole());
    }

    private void Finish(Role role)
    {
        finishChooseRole?.Invoke(role);
        Destroy(this);
    }
}
