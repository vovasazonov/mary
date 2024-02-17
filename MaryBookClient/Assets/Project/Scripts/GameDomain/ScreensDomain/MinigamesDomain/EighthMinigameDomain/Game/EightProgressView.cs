using System;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EighthMinigameDomain.Game
{
    public class EightProgressView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        private int _progress;
        
        public int MaxProgress { get; set; }

        private void Awake()
        {
            _slider.value = 0;
        }

        public int Progress
        {
            get => _progress;
            set
            {
                if (value <= MaxProgress)
                {
                    _progress = value;
                    _slider.value = (float)_progress / MaxProgress;
                }
            }
        }
    }
}