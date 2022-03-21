
using GamePlay.Object;
using TigerForge;
using UnityEngine;

namespace GamePlay.Character.Offline
{
    public class UseCheat : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private CharacterMove move;
        [SerializeField] private CharacterJump jump;
        [SerializeField] private Sword sword;
        private void Start()
        {
            EventManager.StartListening("TangTocDoChay",TangTocDoChay);
            EventManager.StartListening("TangMau",TangMau);
            EventManager.StartListening("TangLucNhay",TangLucNhay);
            EventManager.StartListening("TangDamage",TangDamage);
            EventManager.StartListening("GiamTocDoChay",GiamTocDoChay);
            EventManager.StartListening("GiamLucNhay",GiamLucNhay);
        }

        private void OnDisable()
        {
            EventManager.StopListening("TangTocDoChay",TangTocDoChay);
            EventManager.StopListening("TangMau",TangMau);
            EventManager.StopListening("TangLucNhay",TangLucNhay);
            EventManager.StopListening("TangDamage",TangDamage);
            EventManager.StopListening("GiamTocDoChay",GiamTocDoChay);
            EventManager.StopListening("GiamLucNhay",GiamLucNhay);
        }

        private void TangTocDoChay()
        {
            move.runSpeed += 1;
        }
        private void TangMau()
        {
            character.Info.health.Current += 100;
        }
        private void TangLucNhay()
        {
            jump.jumpSpeed += 1;
        }
        private void TangDamage()
        {
            sword.damage += 100;
        }
        private void GiamTocDoChay()
        {
            move.runSpeed -= 1;
        }
        private void GiamLucNhay()
        {
            jump.jumpSpeed -= 1;
        }
    }
}