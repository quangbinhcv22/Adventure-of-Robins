using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.ScreenFlow
{
    public class ScreenFrame : MonoBehaviour
    {
        [SerializeField] private ScreenFrameSettings settings;

        private readonly List<Screen> _createdScreens = new List<Screen>();
        private readonly Dictionary<ScreenID, int> _screenOrders = new Dictionary<ScreenID, int>();


        public void Request(ScreenRequest request)
        {
            switch (request.action)
            {
                case ScreenAction.Open:
                    Open(request);
                    break;
                case ScreenAction.Close:
                    Close(request);
                    break;
                case ScreenAction.OpenNew:
                    OpenNew(request);
                    break;
                case ScreenAction.Switch:
                    Switch(request);
                    break;
                case ScreenAction.Remove:
                    Remove(request);
                    break;
            }
        }

        private void Open(ScreenRequest request) => (_createdScreens.GetScreen(request.id) ?? CreateScreen(request))?.Open(request.data);

        private void OpenNew(ScreenRequest request) => (_createdScreens.GetScreenNotActive(request.id) ?? CreateScreen(request))?.Open(request.data);

        private void Close(ScreenRequest request) => _createdScreens.GetActiveScreens(request.id).ForEach(screen => screen.Close());

        private void Switch(ScreenRequest request)
        {
            var switchedScreen = _createdScreens.GetScreen(request.id) ?? CreateScreen(request);
            if (switchedScreen is null) return;

            _createdScreens.GetHidedWhenSwitchScreens().ForEach(screen => screen.Hide());
            switchedScreen.Open();
        }

        private void Remove(ScreenRequest request) => _createdScreens.GetScreens(request.id).ForEach(RemoveScreen);


        private Screen CreateScreen(ScreenRequest request)
        {
            var screen = settings.GetScreen(request.id);
            if (screen is null) return null;

            var newScreen = GameObject.Instantiate(screen, this.transform);
            // newScreen.gameObject.SetActive(false);

            _createdScreens.Add(newScreen);
            SortScreensBasedOnOrder(screen.ID);

            return newScreen;
        }

        private void RemoveScreen(Screen screen)
        {
            _createdScreens.Remove(screen);
            Destroy(screen.gameObject);
        }

        private void SortScreensBasedOnOrder(ScreenID screenID)
        {
            if (!_screenOrders.ContainsKey(screenID)) _screenOrders.Add(screenID, settings.GetScreenOrder(screenID));

            var orderlyScreens = _createdScreens.OrderBy(screen => _screenOrders[screen.ID]).ToList();
            for (var i = 0; i < orderlyScreens.Count; i++) orderlyScreens[i].transform.SetSiblingIndex(i);
        }
    }

    internal static class ListScreenExtension
    {
        public static Screen GetScreen(this IEnumerable<Screen> screens, ScreenID screenID)
        {
            return screens.FirstOrDefault(screen => screen.ID.Equals(screenID));
        }

        public static List<Screen> GetScreens(this IEnumerable<Screen> screens, ScreenID screenID)
        {
            return screens.Where(screen => screen.ID.Equals(screenID)).ToList();
        }

        public static List<Screen> GetActiveScreens(this IEnumerable<Screen> screens, ScreenID screenID)
        {
            return screens.Where(screen => screen.ID.Equals(screenID) && IsActive(screen)).ToList();
        }

        public static Screen GetScreenNotActive(this IEnumerable<Screen> screens, ScreenID screenID)
        {
            return screens.FirstOrDefault(screen => screen.ID.Equals(screenID) && !IsActive(screen));
        }

        public static List<Screen> GetHidedWhenSwitchScreens(this List<Screen> screens)
        {
            return screens.FindAll(screen => screen.Type is ScreenType.Window && IsActive(screen)).ToList();
        }

        private static bool IsActive(Component screen) => screen.gameObject.activeInHierarchy;
    }
}