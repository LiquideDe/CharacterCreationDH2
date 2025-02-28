using System.Collections.Generic;
using UnityEngine.UI;

namespace CharacterCreation
{
    public class BackgroundFinalPanelView : ViewWithButtonsDoneAndCancel, IFinalPanelWithToggles
    {
        private List<ToggleGroup> _toggleGroups;

        public void SetToggles(List<ToggleGroup> toggleGroups)
        {
            _toggleGroups = new List<ToggleGroup>(toggleGroups);
        }

        public List<ToggleGroup> GetToggles() => _toggleGroups;
    }
}

