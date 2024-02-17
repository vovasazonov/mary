using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.NinthMinigameDomain.Game
{
    public class NinthProgressView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        private float _progress;

        public float MaxProgress { get; set; }

        public float Progress
        {
            get => _progress;
            set
            {
                if (value < 0)
                {
                    _progress = 0;
                }

                if (value <= MaxProgress + 0.1f)
                {
                    _progress = value;
                    _slider.value = _progress / MaxProgress;
                }
            }
        }
    }
}