using Cysharp.Threading.Tasks;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FifthMinigameDomain.Game
{
    public class FifthEyalView : MonoBehaviour
    {
        [SerializeField] private Transform _firstTarget;
        [SerializeField] private Transform _secondTarget;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _jumpForce = 5f;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private Animator _fifthSceneAnimator;
        private IRuleModel _ruleModel;
        private Vector3 _startedPosition;
        private Vector3 _realStartedPosition;
        private bool _isWon;
        private bool _isJumping;
        private float _velocity;
        private float _gravity = -9.8f;
        private string _currentPlayAnimation = "";
        private bool _isFirstInputDone;
        private bool _isSecondTarget;
        private Transform _target;

        public bool IsSecondTarget => _isSecondTarget;

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }

        private void Awake()
        {
            _realStartedPosition = transform.position;
            _startedPosition = transform.position;
        }

        private void OnEnable()
        {
            _target = _firstTarget;
            _ruleModel.Started += OnMinigameStarted;
            ResetValues();
        }

        private void OnDisable()
        {
            _ruleModel.Started -= OnMinigameStarted;
        }

        private bool IsTap() => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0);
        
        private void Update()
        {
            if (!_isFirstInputDone && IsTap())
            {
                _isFirstInputDone = true;
                PlayAnimation("FifthEyalMove");
                return;
            }
            
            if (!_isFirstInputDone)
            {
                return;
            }
            
            if (!_isWon)
            {
                transform.position = transform.position + transform.TransformDirection(_target.position) * _speed * Time.deltaTime * (_isSecondTarget ? 1 : - 1);

                if (!_isJumping && IsTap())
                {
                    _isJumping = true;
                    _velocity = _jumpForce;
                    PlayAnimation("FifthEyalUp");
                }

                if (_isJumping)
                {
                    _velocity = _velocity + _gravity * Time.deltaTime;
                    var position = transform.position;
                    position.y = position.y + _velocity * Time.deltaTime;
                    transform.position = position;

                    var animationDownName = "FifthEyalDown";
                    if (_velocity < 0 && _currentPlayAnimation != animationDownName)
                    {
                        PlayAnimation(animationDownName);
                    }

                    // check if landed
                    var aX = Mathf.Abs(_startedPosition.x - _target.position.x);
                    var aY = Mathf.Abs(_startedPosition.y - _target.position.y);
                    var bX = Mathf.Abs(transform.position.x - _target.position.x);
                    var c = bX / aX;
                    var bY = c * aY;
                    var landY = _target.position.y + bY;
                    if (transform.position.y <= landY && _velocity < 0)
                    {
                        _isJumping = false;
                        PlayAnimation("FifthEyalMove");
                        position.y = transform.position.y <= landY ? landY : transform.position.y;
                    }
                }

                _isWon = _isSecondTarget ? transform.position.x + 0.1f < _target.position.x :  transform.position.x + 0.1f > _target.position.x;
                if (_isWon)
                {
                    if (_isSecondTarget)
                    {
                        PlayFinish();
                    }
                    else
                    {
                        _isWon = false;
                        _isSecondTarget = true;
                        _target = _secondTarget;
                        var rotation = transform.eulerAngles;
                        rotation = new Vector3(0, 0, 0);
                        transform.eulerAngles = rotation;
                        _startedPosition = _firstTarget.position;
                    }
                }
            }
        }

        private async UniTask PlayFinish()
        {
            transform.position = _target.position;
            _fifthSceneAnimator.Rebind();
            _fifthSceneAnimator.Update(0f);
            _fifthSceneAnimator.Play("FifthScene_End");
            PlayAnimation("Idle");
            _ruleModel.FullProgress();
            await UniTask.Delay(5000);
            _ruleModel.Finish();
        }
        private void OnMinigameStarted()
        {
            ResetValues();
        }

        private void ResetValues()
        {
            _startedPosition = _realStartedPosition;
            _target = _firstTarget;
            transform.position = _startedPosition;
            PlayAnimation("Idle");
            _isJumping = false;
            _isFirstInputDone = false;
            _isSecondTarget = false;
            var rotation = transform.eulerAngles;
            rotation = new Vector3(0, 180, 0);
            transform.eulerAngles = rotation;
        }

        private void PlayAnimation(string animationName)
        {
            _animator.Rebind();
            _animator.Update(0f);
            _currentPlayAnimation = animationName;
            _animator.Play(animationName);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!_isWon)
            {
                if (other.gameObject.GetComponent<FifthEnemyView>() != null)
                {
                    _ruleModel.Start();
                }
            }
        }
    }
}