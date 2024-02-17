using System;
using UnityEngine;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.ThirdMinigameDomain.Game
{
    public class OrangePartView : MonoBehaviour
    {
        public event Action<OrangePartView> Clicked;

        [SerializeField] private Animator _animator;

        public int Id;

        private void OnMouseUpAsButton()
        {
            Clicked?.Invoke(this);
        }

        public void PlayAnimationColor()
        {
            _animator.Rebind();
            _animator.Update(0f);
            _animator.Play("click_part_orange");
        }
    }
}