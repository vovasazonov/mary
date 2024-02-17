using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.NinthMinigameDomain.Game
{
    public class NinthMinigameView : MonoBehaviour
    {
        [SerializeField] private NinthProgressView _progress;
        [SerializeField] private List<AnimalView> _animals;
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
                _isWon = _progress.Progress > (_progress.MaxProgress - 0.1f);
                if (_isWon)
                {
                    Finish();
                }
            }
        }

        private async UniTask Finish()
        {
            _animals.ForEach(i=> i.Win());
            _ruleModel.FullProgress();
            await UniTask.Delay(5000);
            _ruleModel.Finish();
        }
    }
}