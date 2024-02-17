using System.Collections.Generic;
using DG.Tweening;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FourthMinigameDomain.Game
{
    public class GarinFourthView : MonoBehaviour
    {
        [SerializeField] private List<Transform> _movePoints;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _speed = 0.5f; // u = s/t
        private readonly Queue<Vector3> _movePointsQueue = new();
        private float _closeDistance = 0.1f;
        private IRuleModel _ruleModel;
        private Vector3 _startPosition;
        private Sequence _moveTweenSequence;
        private bool _isWon;
        private string _currentStateAnimation;

        public bool IsPlaying { get; private set; }
        public bool IsFinish => _isWon;

        private void Awake()
        {
            _startPosition = transform.position;
        }

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }

        private void Update()
        {
            IsPlaying = false;

            if (!_isWon)
            {
                var isPlayedLastFrame = IsPlaying;
                IsPlaying = Input.touchCount > 0 || Input.GetMouseButton(0);

                var isGotToPoint = Vector3.Distance(_movePointsQueue.Peek(), transform.position) < _closeDistance;
                if (isGotToPoint)
                {
                    _movePointsQueue.Dequeue();
                    isPlayedLastFrame = false;
                }

                UpdateWon();
                UpdateAnimationMove(isPlayedLastFrame);
            }
        }

        private void UpdateWon()
        {
            _isWon = _movePointsQueue.Count == 0;
            if (_isWon)
            {
                _moveTweenSequence?.Kill();
                if (_currentStateAnimation != "idle")
                {
                    _currentStateAnimation = "idle";
                    _animator.Rebind();
                    _animator.Update(0f);
                    _animator.Play("idle");
                }
            }
        }

        private void UpdateAnimationMove(bool isPlayedLastFrame)
        {
            if (!isPlayedLastFrame && IsPlaying && _movePointsQueue.Count > 0)
            {
                _moveTweenSequence?.Kill();
                _moveTweenSequence = DOTween.Sequence();
                var t = (Vector3.Distance(transform.position, _movePointsQueue.Peek())) / _speed;
                _moveTweenSequence.Append(transform.DOMove(_movePointsQueue.Peek(), t));
                
                if (_currentStateAnimation != "shake_garin")
                {
                    _currentStateAnimation = "shake_garin";
                    _animator.Rebind();
                    _animator.Update(0f);
                    _animator.Play("shake_garin");
                }
            }

            if (!IsPlaying)
            {
                if (_currentStateAnimation != "idle")
                {
                    _currentStateAnimation = "idle";
                    _animator.Rebind();
                    _animator.Update(0f);
                    _animator.Play("idle");
                }


                _moveTweenSequence?.Kill();
                _moveTweenSequence = null;
            }
        }

        private void OnEnable()
        {
            _ruleModel.Started += OnMinigameRestarted;

            ResetValues();
        }

        private void OnDisable()
        {
            _ruleModel.Started -= OnMinigameRestarted;
        }

        private void OnMinigameRestarted()
        {
            ResetValues();
        }

        private void ResetValues()
        {
            transform.position = _startPosition;
            _movePointsQueue.Clear();
            foreach (var movePoint in _movePoints)
            {
                _movePointsQueue.Enqueue(movePoint.position);
            }
        }
    }
}