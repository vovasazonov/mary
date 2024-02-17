using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FourthMinigameDomain.Game
{
    public class ArrowFourthView : MonoBehaviour
    {
        private IRuleModel _ruleModel;

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }

        private void OnEnable()
        {
            _ruleModel.Started += OnMinigameRestarted;
        }

        private void OnDisable()
        {
            _ruleModel.Started -= OnMinigameRestarted;
        }

        private void OnMinigameRestarted()
        {
            gameObject.SetActive(true);
        }

        private void Update()
        {
            if (Input.touchCount > 0 || Input.GetMouseButton(0))
            {
                gameObject.SetActive(false);
            }
        }
    }
}