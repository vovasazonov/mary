using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SixthMinigameDomain.Game
{
    public class SixthShualView : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _toHideOnWon;
        [SerializeField] private List<GameObject> _toShowOnWon;
        [SerializeField] private GameObject _eye;
        [SerializeField] private SixthMinigameView _sixthMinigameView;
        private SixthMinigameProgress _progress;
        private bool _isWon;

        [Inject]
        private void Constructor(SixthMinigameProgress progress)
        {
            _progress = progress;
        }

        private void Update()
        {
            if (!_isWon)
            {
                if (_sixthMinigameView.IsWon)
                {
                    _isWon = true;
                    _toHideOnWon.ForEach(i => i.SetActive(false));
                    _toShowOnWon.ForEach(i => i.SetActive(true));
                }
                else
                {
                    _eye.SetActive(_progress.Progress > 0.5f);
                }
            }
        }
    }
}