using System;
using Cysharp.Threading.Tasks;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EighthMinigameDomain.Game
{
    public class EighthMinigameView : MonoBehaviour
    {
        [SerializeField] private EightProgressView _progress;
        private bool _isWon;
        private IRuleModel _ruleModel;

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }
        
        private void Update()
        {
            if (!_isWon)
            {
                _isWon = _progress.MaxProgress == _progress.Progress;

                if (_isWon)
                {
                    NewMethod();
                }
            }
        }

        private async UniTask NewMethod()
        {
            _ruleModel.FullProgress();
            await UniTask.Delay(2500);
            _ruleModel.Finish();
        }
    }
}