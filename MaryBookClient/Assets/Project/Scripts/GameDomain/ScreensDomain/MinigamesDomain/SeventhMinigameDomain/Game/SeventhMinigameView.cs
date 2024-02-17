using Cysharp.Threading.Tasks;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SeventhMinigameDomain.Game
{
    public class SeventhMinigameView : MonoBehaviour
    {
        [SerializeField] private MazeView _mazeView;
        [SerializeField] private Animator _animator;
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
                if (_mazeView.IsWon)
                {
                    _isWon = true;
                    PlayFinish();
                }
            }
        }

        private async UniTask PlayFinish()
        {
            _animator.Rebind();
            _animator.Update(0f);
            _animator.Play("seventh_minigame_finish");
            _ruleModel.FullProgress();
            await UniTask.Delay(4000);
            _ruleModel.Finish();
        }
    }
}