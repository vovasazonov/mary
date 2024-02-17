using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FirstMinigameDomain.Game
{
    public class TuciFlyView : MonoBehaviour
    {
        [SerializeField] private Vector3 _leftMaxSide;
        [SerializeField] private Vector3 _rightMaxSide;
        [SerializeField] private Vector3 _bottomFail;
        [SerializeField] private Vector3 _direction = Vector3.right;
        [SerializeField] private float _speed = 5;
        [SerializeField] private Transform _orangeParent;
        [SerializeField] private Transform _goAwayOnWonPosition;
        [SerializeField] private Vector3 _maxHeight;
        private Vector3 _startPosition;
        private float _gravity = -9.81f;
        private float _velocity = 0;
        private bool _wasFirstInput;
        private IRuleModel _ruleModel;
        private bool _isWon;

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }

        private void Awake()
        {
            _startPosition = transform.position;
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
            UpdateDirection();
            UpdatePosition();
            UpdateFailFlag();
            UpdateHigh();
            UpdateInput();
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

        private void UpdatePosition()
        {
            if (_wasFirstInput && !_isWon)
            {
                var position = transform.position;
                position.x += _speed * Time.deltaTime * _direction.x;
                transform.position = position;
            }
        }

        private void UpdateDirection()
        {
            if (_wasFirstInput && !_isWon)
            {
                var rotation = transform.rotation;

                if (transform.position.x > _rightMaxSide.x)
                {
                    _direction = Vector3.left;
                    rotation.y = 180;
                }

                if (transform.position.x < _leftMaxSide.x)
                {
                    _direction = Vector3.right;
                    rotation.y = 0;
                }

                transform.rotation = rotation;
            }
        }

        private void OnStarted()
        {
            ResetValues();
        }

        private void ResetValues()
        {
            _direction = Vector3.right;
            var rotation = transform.rotation;
            rotation.y = 0;
            rotation.z = 0;
            transform.rotation = rotation;
            var position = transform.position;
            position.x = _startPosition.x;
            position.y = _startPosition.y;
            transform.position = position;

            _wasFirstInput = false;
            _velocity = 0;
        }

        public void SetOrangeParent(OrangeView orangeView)
        {
            orangeView.transform.SetParent(_orangeParent);
            orangeView.transform.localPosition = Vector3.zero;
            orangeView.transform.localScale = new Vector3(0.3f, 0.3f, 1);
            orangeView.transform.eulerAngles = new Vector3(0f, 0f, 115.9f);
            _isWon = true;
            var rotation = transform.rotation;
            rotation.y = 0;
            transform.rotation = rotation;
            _ruleModel.FullProgress();
            transform.DOMove(_goAwayOnWonPosition.position, 10f).OnComplete(() => Finish());
        }

        private async UniTask Finish()
        {
            _ruleModel.Finish();
        }
    }
}