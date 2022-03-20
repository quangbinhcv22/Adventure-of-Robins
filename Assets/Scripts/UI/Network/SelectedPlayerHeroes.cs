using System.Collections.Generic;
using System.Linq;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace UI.Network
{
    public class SelectedPlayerHeroes : MonoBehaviourPunCallbacks
    {
        [SerializeField] private List<SelectedHero> heroes;


        public override void OnEnable()
        {
            base.OnEnable();
            ReloadData();
        }

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            ReloadData();
        }

        private void ReloadData()
        {
            var players = PhotonNetwork.PlayerList.ToList();
            print(players.Count);

            for (int i = 0; i < heroes.Count; i++)
            {
                heroes[i].UpdateView(players.Count > i ? players[i] : null);
            }
        }
    }
}