using System;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.ThirdMinigameDomain.Game
{
    public class RestartButtonThirdView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private IRuleModel _ruleModel;

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }
        
        private void OnMouseUpAsButton()
        {
            _animator.Rebind();
            _animator.Update(0f);
            _animator.Play("third_button_click");
            _ruleModel.Start();
        }
    }
}