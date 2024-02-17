using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.ThirdMinigameDomain.Game
{
    public class OrangePartsManagerView : MonoBehaviour
    {
        [SerializeField] private List<OrangePartView> _parts;
        [SerializeField] private List<Level> _levels;
        [SerializeField] private Animator _animator;
        [SerializeField] private ThirdMinigameView _thirdMinigameView;
        [SerializeField] private Slider _slider;
        [SerializeField] private GameObject _restartButton;
        private IRuleModel _ruleModel;
        private int _currentLevel;
        private List<int> _currentQueues = new();
        private bool _isFailed;
        private bool _isLastMove;
        private bool _isWon;
        private bool _isPlayingAnimation;
        private int _waitAnimationColorPartMillisecodns = 1000;
        private bool _isFirstStart = true;

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }

        private void Awake()
        {
            _restartButton.SetActive(false);
        }

        private void Update()
        {
            _slider.value = _isWon ? 1 : (float)(_currentLevel) / _levels.Count;
        }

        private void OnEnable()
        {
            _ruleModel.Started += OnRestartedMinigame;

            foreach (var part in _parts)
            {
                part.Clicked += OnPartClicked;
            }

            _isPlayingAnimation = true;
        }

        private void OnDisable()
        {
            _ruleModel.Started -= OnRestartedMinigame;

            foreach (var part in _parts)
            {
                part.Clicked -= OnPartClicked;
            }
        }

        private void OnRestartedMinigame()
        {
            ResetValues();
            if (_isFirstStart)
            {
                _isFirstStart = false;
            }
            else
            {
                PlayNextLevel();
            }
        }

        private void ResetValues()
        {
            _currentQueues.Clear();
            _isFailed = false;
            _isLastMove = false;
            _isWon = false;
            _isPlayingAnimation = false;
        }

        private void OnPartClicked(OrangePartView part)
        {
            ProcessGameAsync(part);
        }

        private async UniTask ProcessGameAsync(OrangePartView part)
        {
            if (!_isFailed && !_isWon && !_isPlayingAnimation)
            {
                _currentQueues.Add(part.Id);
                part.PlayAnimationColor();

                _isLastMove = _levels[_currentLevel].OrderIds.Count == _currentQueues.Count;
                _isFailed = _levels[_currentLevel].OrderIds[_currentQueues.Count - 1] != part.Id;

                if (_isFailed)
                {
                    await UniTask.Delay(_waitAnimationColorPartMillisecodns);
                    _animator.Rebind();
                    _animator.Update(0f);
                    _animator.Play("fail");
                    await UniTask.Delay(_waitAnimationColorPartMillisecodns);
                    _ruleModel.Start();
                }
                else if (_isLastMove)
                {
                    await UniTask.Delay(_waitAnimationColorPartMillisecodns);
                    _animator.Rebind();
                    _animator.Update(0f);
                    _animator.Play("won");
                    await UniTask.Delay(_waitAnimationColorPartMillisecodns);
                    _currentLevel++;
                    _currentQueues.Clear();

                    if (_currentLevel >= _levels.Count)
                    {
                        _isWon = true;

                        _slider.gameObject.SetActive(false);
                        _thirdMinigameView.SetWon();
                    }
                    else
                    {
                        await PlayNextLevel();
                    }
                }
            }
        }

        public async UniTask PlayNextLevel(int waitBeforeStart = 0)
        {
            _restartButton.SetActive(false);
            _isPlayingAnimation = true;

            if (waitBeforeStart > 0)
            {
                await UniTask.Delay(waitBeforeStart);
            }

            foreach (var id in _levels[_currentLevel].OrderIds)
            {
                _parts.Find(i => i.Id == id).PlayAnimationColor();
                await UniTask.Delay(_waitAnimationColorPartMillisecodns);
            }

            _isPlayingAnimation = false;
            _restartButton.SetActive(true);
        }

        [Serializable] private struct Level
        {
            public List<int> OrderIds;
        }
    }
}