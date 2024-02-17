using UnityEngine;
using UnityEngine.UI;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Popup.View
{
    public class ButtonPopupView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private string _popupId;
        [SerializeField] private bool _isOpen;
        [SerializeField] private PopupsView _popupsView;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            if (_isOpen)
            {
                _popupsView.Open(_popupId);
            }
            else
            {
                _popupsView.CloseAll();
            }
        }
    }
}