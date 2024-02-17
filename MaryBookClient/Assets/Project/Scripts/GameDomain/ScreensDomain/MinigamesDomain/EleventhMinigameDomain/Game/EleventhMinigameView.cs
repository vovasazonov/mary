using System;
using Cysharp.Threading.Tasks;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EleventhMinigameDomain.Game
{
    public class EleventhMinigameView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private IRuleModel _ruleModel;
        private EleventhProgress _progress;
        private bool _isWon;

        [Inject]
        private void Constructor(IRuleModel ruleModel, EleventhProgress progress)
        {
            _ruleModel = ruleModel;
            _progress = progress;
        }

        private void Update()
        {
            if (!_isWon)
            {
                _isWon = _progress.MaxProgress <= _progress.Progress;
                if (_isWon)
                {
                    Finish();
                }
            }
        }

        private async UniTask Finish()
        {
            _animator.Rebind();
            _animator.Update(0f);
            _animator.Play("EleventhEnd");
            _ruleModel.FullProgress();
            await UniTask.Delay(15000);
            _ruleModel.Finish();
        }
    }
}