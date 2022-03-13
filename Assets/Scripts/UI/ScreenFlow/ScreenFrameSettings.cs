using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.ScreenFlow
{
    [CreateAssetMenu(fileName = nameof(ScreenFrameSettings), menuName = "ScriptableObject/UI/ScreenFrameSettings")]
    public class ScreenFrameSettings : ScriptableObject
    {
        [SerializeField] private List<Screen> screens;

        public Screen GetScreen(ScreenID screenID) => screens.FirstOrDefault(screen => screen.ID == screenID);
        public int GetScreenOrder(ScreenID screenID) => screens.FindIndex(screen => screen.ID == screenID);
    }
}