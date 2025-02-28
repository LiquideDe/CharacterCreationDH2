using System.Collections.Generic;
using UnityEngine.UI;

namespace CharacterCreation
{
    public interface IFinalPanelWithToggles
    {
        void SetToggles(List<ToggleGroup> toggleGroups);
    }
}

