using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FourthMinigameDomain.Game
{
    public class EyalFourthView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private float _betweenOpenCloseEyesSeconds = 2f;
        [SerializeField] private float _changeFlagEyeAfterAnimationSeconds = 1f;
        [SerializeField] private FourthMinigameView _fourthMinigameView;
        private float _leftSeconds;
        private string _currentStateAnimation;

        public bool IsEyeOpen { get; private set; }

        private void Update()
        {
            _leftSeconds += Time.deltaTime;

            if (_leftSeconds > _betweenOpenCloseEyesSeconds || _fourthMinigameView.IsWon && _currentStateAnimation == "close_eye")
            {
                _animator.Rebind();
                _animator.Update(0f);
                _currentStateAnimation = IsEyeOpen ? "close_eye" : "open_eye";
                _animator.Play(_currentStateAnimation);
                _leftSeconds = 0f;

                UniTask.Delay((int)(_changeFlagEyeAfterAnimationSeconds * 1000)).
                    ContinueWith(() => IsEyeOpen = !IsEyeOpen);
            }
        }
    }
}