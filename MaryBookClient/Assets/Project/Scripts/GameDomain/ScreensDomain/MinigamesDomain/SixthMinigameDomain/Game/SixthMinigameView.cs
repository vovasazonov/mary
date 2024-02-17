using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SixthMinigameDomain.Game
{
    public class SixthMinigameView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private float _decreaseProgressSpeed = 0.001f;
        [SerializeField] private Slider _progressSlider;
        [SerializeField] private float _shakingTimeDeltaSeconds;
        [SerializeField] private List<PartView> _parts;
        private SixthMinigameProgress _progress;
        private IRuleModel _ruleModel;
        private float _shakingTimeLeftSeconds;
        private int _previousPartIndex;
        
        public bool IsWon { get; private set; }

        [Inject]
        private void Constructor(
            SixthMinigameProgress progress,
            IRuleModel ruleModel
        )
        {
            _progress = progress;
            _ruleModel = ruleModel;
        }

        private void Update()
        {
            if (!IsWon)
            {
                _progress.Progress -= Time.deltaTime * _decreaseProgressSpeed;
                _progressSlider.value = _progress.Progress;
                IsWon = _progress.Progress > 1;

                UpdatePartShaking();

                if (IsWon)
                {
                    PlayWon();
                }
            }
        }

        private async UniTask PlayWon()
        {
            _animator.Rebind();
            _animator.Update(0f);
            _animator.Play("sixth_minigame_end");
            _ruleModel.FullProgress();
            await UniTask.Delay(5000);
            _ruleModel.Finish();
        }

        private void OnEnable()
        {
            _animator.Rebind();
            _animator.Update(0f);
            _animator.Play("sixth_minigame_start");
        }

        private void UpdatePartShaking()
        {
            _shakingTimeLeftSeconds += Time.deltaTime;
            if (_shakingTimeLeftSeconds > _shakingTimeDeltaSeconds)
            {
                _shakingTimeLeftSeconds = 0;

                int randomIndex;

                do
                {
                    randomIndex = Random.Range(0, _parts.Count);
                } while (randomIndex == _previousPartIndex);

                _previousPartIndex = randomIndex;

                foreach (var part in _parts)
                {
                    part.StopShake();
                }
                
                var partToShake = _parts[randomIndex];
                
                partToShake.StartShake();
            }
        }
    }
}