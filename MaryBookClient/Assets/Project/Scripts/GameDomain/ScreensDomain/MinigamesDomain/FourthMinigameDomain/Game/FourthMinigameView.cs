using Cysharp.Threading.Tasks;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FourthMinigameDomain.Game
{
    public class FourthMinigameView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private EyalFourthView _eyal;
        [SerializeField] private GarinFourthView _garin;

        private IRuleModel _ruleModel;
        private bool _isWon;
        private bool _isFailed;

        public bool IsWon => _isWon;

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }

        private void OnEnable()
        {
            _ruleModel.Started += OnMinigameStarted;
        }

        private void OnDisable()
        {
            _ruleModel.Started -= OnMinigameStarted;
        }

        private void OnMinigameStarted()
        {
            ResetValues();
        }

        private void Update()
        {
            if (!(_isFailed || _isWon))
            {
                if (_eyal.IsEyeOpen && _garin.IsPlaying && !_garin.IsFinish)
                {
                    _isFailed = true;
                    _ruleModel.Start();
                }
                else
                {
                    if (_garin.IsFinish && !_eyal.IsEyeOpen)
                    {
                        _isWon = true;
                        _animator.Play("finish_fourth_scene");
                        _ruleModel.FullProgress();
                        UniTask.Delay(5000).ContinueWith(() => _ruleModel.Finish());
                    }
                }
            }
        }

        private void ResetValues()
        {
            _isFailed = false;
            _isWon = false;
        }
    }
}