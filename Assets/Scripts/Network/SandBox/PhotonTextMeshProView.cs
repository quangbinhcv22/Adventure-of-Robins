using Photon.Pun;
using TMPro;
using UnityEngine;

namespace Network.SandBox
{
    [RequireComponent(typeof(TMP_Text))]
    public class PhotonTextMeshProView : MonoBehaviour, IPunObservable
    {
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(_text.text);
            }
            else
            {
                _text.SetText((string)stream.ReceiveNext());
            }
        }
    }
}