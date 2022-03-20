using System.Linq;
using ExitGames.Client.Photon;
using Network;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Network
{
    [RequireComponent(typeof(Button))]
    public class StartBattleButton : MonoBehaviourPunCallbacks
    {
        private Button _button;

        public void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(StartBattle);
        }

        public override void OnEnable()
        {
            base.OnEnable();
            CheckHeroSelection();
        }

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps) => CheckHeroSelection();
        public override void OnPlayerEnteredRoom(Player newPlayer) => CheckHeroSelection();
        public override void OnPlayerLeftRoom(Player otherPlayer) => CheckHeroSelection();

        private void CheckHeroSelection()
        {
            var players = PhotonNetwork.PlayerList.ToList();
            var fullSelection = players.All(player => player.CustomProperties[PlayerCustomProperty.Hero] != null);

            _button.interactable = fullSelection;
        }

        private void StartBattle()
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            
            NetworkController.Instance.events.startGame.SendRequest();
            print("Start Battle");
        }
    }
}