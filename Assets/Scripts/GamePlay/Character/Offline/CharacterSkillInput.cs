using TigerForge;
using UnityEngine;

namespace GamePlay.Character.Offline
{
    public class CharacterSkillInput : MonoBehaviour
    {
        [SerializeField] private CharacterSkillActivate skillActivate;
        private void Start()
        {
            EventManager.StartListening("Skill1",Skill1);
            EventManager.StartListening("Skill2",Skill2);
            EventManager.StartListening("Skill3",Skill3);
        }

        private void OnDisable()
        {
            EventManager.StopListening("Skill1",Skill1);
            EventManager.StopListening("Skill2",Skill2);
            EventManager.StopListening("Skill3",Skill3);
        }

        private void Skill1()
        {
            skillActivate.ActivateSkill1();
        }
        private void Skill2()
        {
            skillActivate.ActivateSkill2();
        }
        private void Skill3()
        {
            skillActivate.ActivateSkill3();
            skillActivate.ActivateSkill3();
        }
    }
}