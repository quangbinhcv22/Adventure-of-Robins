using UnityEngine;

namespace UI
{
    public class Screen : MonoBehaviour
    {
        [SerializeField] private ScreenID id;
        [SerializeField] private ScreenType type;

        public ScreenID ID => id;
        public ScreenType Type => type;
        

        public virtual void Open(object data = null)
        {
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}