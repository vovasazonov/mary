using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SixthMinigameDomain.Game
{
    public class PartView : MonoBehaviour
    {
        [SerializeField] private float _increasingPoint = 0.1f;
        private Animator _animator;
        private bool _isShaking;
        private SixthMinigameProgress _progress;

        [Inject]
        private void Constructor(SixthMinigameProgress progress)
        {
            _progress = progress;
        }
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void StartShake()
        {
            _isShaking = true;
            _animator.Play("PartMove");
        }
        
        public void StopShake()
        {
            _isShaking = false;
            _animator.Play("PartIdle");
        }

        private void OnMouseUpAsButton()
        {
            if (_isShaking)
            {
                StopShake();
                PlayGreenEffect();
                _progress.Progress += _increasingPoint;
            }
        }

        private void PlayGreenEffect()
        {
            
        }
    }
}