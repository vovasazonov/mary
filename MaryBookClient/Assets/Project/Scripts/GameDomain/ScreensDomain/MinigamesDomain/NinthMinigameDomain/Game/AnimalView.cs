using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.NinthMinigameDomain.Game
{
    public class AnimalView : MonoBehaviour
    {
        [SerializeField] private NinthProgressView _progress;
        [SerializeField] private float _speed = 10;
        [SerializeField] private Vector3 _targetPosition;
        [SerializeField] private float _intervalSeconds = 15f;
        [SerializeField] private bool _needRotateOnHide;
        private float _nextIntervalSeconds;
        private float _timer;
        private Vector3 _startPosition;
        private bool _isClickable;
        private bool _isMoving;
        private TweenerCore<Vector3, Vector3, VectorOptions> _moveTween;
        private bool _isWin;

        private void Awake()
        {
            _progress.MaxProgress++;
            _startPosition = transform.position;
            _nextIntervalSeconds = GetNextIntervalSeconds();
        }

        private void OnMouseUpAsButton()
        {
            if (_isClickable)
            {
                _isClickable = false;
                _progress.Progress += 0.5f;
                Hide(_speed * 0.25f);
            }
        }

        private void Update()
        {
            if (_isWin)
            {
                return;
            }
            
            _timer += Time.deltaTime;

            if (!_isMoving)
            {
                if (_timer > _nextIntervalSeconds)
                {
                    _timer = 0;
                    Show();
                }
            }
        }

        private void Show(bool isAfterHiding = true)
        {
            var rotation = transform.eulerAngles;
            rotation.y = 0;
            transform.eulerAngles = rotation;

            _isMoving = true;
            _isClickable = true;
            _moveTween?.Kill();
            _moveTween = transform.DOMove(_targetPosition, _speed).OnComplete(() =>
            {
                if (isAfterHiding)
                {
                    Hide(_speed);
                }
            });
        }

        private void Hide(float speed)
        {
            if (_needRotateOnHide)
            {
                var rotation = transform.eulerAngles;
                rotation.y = 180;
                transform.eulerAngles = rotation;
            }

            _moveTween?.Kill();
            _moveTween = transform.DOMove(_startPosition, speed).OnComplete(() =>
            {
                _nextIntervalSeconds = GetNextIntervalSeconds();
                _isClickable = false;
                _isMoving = false;
                _timer = 0f;
            });
        }

        private float GetNextIntervalSeconds()
        {
            return Random.Range(5f, _intervalSeconds);
        }

        public void Win()
        {
            _isWin = true;
            Show(false);
        }
    }
}