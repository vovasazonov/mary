using System;
using UnityEngine;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FifthMinigameDomain.Game
{
    public class FifthEnemyView : MonoBehaviour
    {
        [SerializeField] private FifthEyalView _eyal;
        [SerializeField] private bool _isForSecondTarget;
        private SpriteRenderer _spriteRenderer;
        private Vector3 _position;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _position = transform.position;
        }

        private void Update()
        {
            if (_isForSecondTarget == _eyal.IsSecondTarget)
            {
                if (_eyal.IsSecondTarget)
                {
                    _spriteRenderer.sortingOrder = _eyal.transform.position.x > _position.x ? 3 : 1;
                }
                else
                {
                    _spriteRenderer.sortingOrder = _eyal.transform.position.x < _position.x ? 3 : 1;
                }
            }
            else
            {
                _spriteRenderer.sortingOrder = 1;
            }
        }
    }
}