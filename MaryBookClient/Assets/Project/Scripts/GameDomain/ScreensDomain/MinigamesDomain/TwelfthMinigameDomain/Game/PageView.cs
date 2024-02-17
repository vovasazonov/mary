using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.TwelfthMinigameDomain.Game
{
    public class PageView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private int _level;
        [SerializeField] private Image _image;
        [SerializeField] private Sprite _closeSprite;
        [SerializeField] private Sprite _levelSprite;
        private IRuleModel _ruleModel;

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_level <= _ruleModel.HigherPassedLevel)
            {
                _ruleModel.RequestLevel(_level);
            }
        }

        private void Start()
        {
            if (_ruleModel.IsPassAllLevels || _level <= _ruleModel.HigherPassedLevel)
            {
                _image.sprite = _levelSprite;
            }
            else
            {
                _image.sprite = _closeSprite;
            }
        }
    }
}