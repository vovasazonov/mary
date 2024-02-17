using System;
using UnityEngine;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SeventhMinigameDomain.Game
{
    public class SeventhMinigameInputButton : MonoBehaviour
    {
        [SerializeField] private SeventhMinigameInputView _inputView;
        [SerializeField] private Vector2Int _direction;
        [SerializeField] private Animator _animator;

        private void OnMouseUpAsButton()
        {
            _inputView.Direction = _direction;
            
            _animator.Rebind();
            _animator.Update(0f);
            _animator.Play("seventh_button_pressed");
        }
    }
}