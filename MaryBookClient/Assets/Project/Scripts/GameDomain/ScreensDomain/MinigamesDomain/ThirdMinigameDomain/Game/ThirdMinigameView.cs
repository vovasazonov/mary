using System;
using Cysharp.Threading.Tasks;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Dialog.View;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.ThirdMinigameDomain.Game
{
    public class ThirdMinigameView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private OrangePartsManagerView _orangePartsManager;
        private IRuleModel _ruleModel;

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }

        private void Start()
        {
            PlayStartAsync();
        }

        private async UniTask PlayStartAsync()
        {
            while (DialogView.Instance.IsActive)
            {
                await UniTask.DelayFrame(1);
            }
            
            _animator.Rebind();
            _animator.Update(0f);
            _animator.Play("ThirdMinigame_EnterScene");

            await UniTask.Delay(10000);
            _orangePartsManager.PlayNextLevel();
        }

        public async UniTask SetWon()
        {
            _animator.Rebind();
            _animator.Update(0f);
            _animator.Play("ThirdMinigame_FinishScene");
            _ruleModel.FullProgress();
            await UniTask.Delay(5000);
            _ruleModel.Finish();
        }
    }
}