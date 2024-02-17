using Cysharp.Threading.Tasks;
using DG.Tweening;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SecondMinigameDomain.Game
{
    public class SecondGameTuciFlyView : MonoBehaviour
    {
        [SerializeField] private Vector3 _bottomFail;
        [SerializeField] private Slider _slider;
        [SerializeField] private Transform _finishLine;
        [SerializeField] private Transform _animationFinishTarget;
        [SerializeField] private Vector3 _maxHeight;
        private Vector3 _startPosition;
        private float _gravity = -9.81f;
        private float _velocity = 0;
        private bool _wasFirstInput;
        private IRuleModel _ruleModel;
        private bool _isWon;
        private Vector3 _firstPositionOfFinishLine;

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }

        private void Awake()
        {
            _startPosition = transform.position;
            _firstPositionOfFinishLine = _finishLine.transform.position;
        }

        private void OnEnable()
        {
            _ruleModel.Started += OnStarted;

            ResetValues();
        }

        private void OnDisable()
        {
            _ruleModel.Started -= OnStarted;
        }

        private void Update()
        {
            UpdateFailFlag();
            UpdateHigh();
            UpdateInput();
            UpdateWon();
        }

        private void UpdateInput()
        {
            if (Input.touchCount > 0 || Input.GetMouseButton(0))
            {
                _wasFirstInput = true;

                if (_velocity < Mathf.Abs(_gravity) && transform.position.y < _maxHeight.y)
                {
                    _velocity += Mathf.Abs(_gravity * 3) * Time.deltaTime;
                }
            }
        }

        private void UpdateHigh()
        {
            if (_wasFirstInput && !_isWon)
            {
                if (transform.position.y > _maxHeight.y)
                {
                    _velocity = 0;
                }
                _velocity += _gravity * Time.deltaTime;
                var position = transform.position;
                position.y += _velocity * Time.deltaTime;
                transform.position = position;
            }
        }

        private void UpdateFailFlag()
        {
            if (transform.position.y < _bottomFail.y && !_isWon)
            {
                _ruleModel.Start();
            }
        }

        private void UpdateWon()
        {
            if (!_isWon)
            {
                var totalDistance =  _firstPositionOfFinishLine.x - _startPosition.x;
                var passDistance = totalDistance - _finishLine.position.x - _startPosition.x;
                var passPercent = passDistance / totalDistance;
                _slider.value = passPercent;

                if (_slider.value >= 0.99f || _finishLine.position.x < _startPosition.x)
                {
                    _isWon = true;
                    _ruleModel.FullProgress();
                    transform.DOMove(_animationFinishTarget.position, 5f).OnComplete(() => Finish());
                }
            }
        }

        private async UniTask Finish()
        {
            _ruleModel.Finish();
        }

        private void OnStarted()
        {
            ResetValues();
        }

        private void ResetValues()
        {
            var rotation = transform.rotation;
            rotation.y = 0;
            rotation.z = 0;
            transform.rotation = rotation;
            var position = transform.position;
            position.x = _startPosition.x;
            position.y = _startPosition.y;
            transform.position = position;
            _slider.value = 0f;

            _wasFirstInput = false;
            _velocity = 0;
        }
    }
}