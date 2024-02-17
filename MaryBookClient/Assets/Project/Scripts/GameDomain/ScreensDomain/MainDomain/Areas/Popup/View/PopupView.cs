using UnityEngine;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Popup.View
{
    public class PopupView : MonoBehaviour, IPopupView
    {
        [SerializeField] private string _id;

        public string Id => _id;
        
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}