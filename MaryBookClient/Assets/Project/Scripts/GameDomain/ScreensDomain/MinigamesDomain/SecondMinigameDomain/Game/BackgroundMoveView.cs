using System;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SecondMinigameDomain.Game
{
    public class BackgroundMoveView : MonoBehaviour
    {
        [SerializeField] private string _animationState;
        [SerializeField] private Animator _animator;
        private IRuleModel _ruleModel;

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }

        private void OnEnable()
        {
            _ruleModel.Started += OnMinigameStarted;
            _ruleModel.Finished += OnMinigameFinished;
            
            RestartAnimation();
        }

        private void OnDisable()
        {
            _ruleModel.Started -= OnMinigameStarted;
            _ruleModel.Finished -= OnMinigameFinished;
        }

        private void OnMinigameFinished()
        {
            _animator.StopPlayback();
        }

        private void OnMinigameStarted()
        {
            RestartAnimation();
        }

        private void RestartAnimation()
        {
            _animator.Rebind();
            _animator.Update(0f);
            _animator.Play(_animationState);
        }
    }
}