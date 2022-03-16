using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Network.Events
{
    public static class CharacterCoolDownSkill
    {
        public static IEnumerator CoolDownSkill(Button button,float duration)
        {
            DisableSkill(button);
            yield return new WaitForSeconds(duration);
            EnableSkill(button);
        }

        private static void EnableSkill(Button button)
        {
            button.interactable = true;
        }
        private static void DisableSkill(Button button)
        {
            button.interactable = false;
        }
    }
}