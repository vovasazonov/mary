using System;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.TenthMinigameDomain.Game
{
    public class AskTreeObjectView : MonoBehaviour
    {
        [SerializeField] private float _askIntervalSeconds = 5;
        [SerializeField] private float _points;
        [SerializeField] private GameObject _sunObject;
        [SerializeField] private GameObject _tipaObject;
        [SerializeField] private GameObject _cloudObject;
        private bool _isAskingSun;
        private bool _isAsking;
        private float _timerSeconds;
        private TenthProgress _progress;

        [Inject]
        private void Constructor(TenthProgress progress)
        {
            _progress = progress;
        }

        private void Awake()
        {
            _timerSeconds += _askIntervalSeconds + 1;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var fallObject = other.gameObject.GetComponent<FallObjectTreeView>();
            if (_isAsking && fallObject != null)
            {
                _isAsking = false;
                _timerSeconds = 0;
                _cloudObject.SetActive(false);

                if (_isAskingSun == fallObject.IsSun)
                {
                    _progress.Progress += _points;
                }
                else
                {
                    _progress.Progress -= _points;
                }
                
                fallObject.GotIt();
            }
        }

        private void Update()
        {
            _timerSeconds += Time.deltaTime;

            if (_timerSeconds > _askIntervalSeconds)
            {
                if (!_isAsking)
                {
                    _cloudObject.SetActive(true);
                    _isAsking = true;
                    var random = Random.Range(0, 2);
                    _isAskingSun = random == 1;
                    _sunObject.SetActive(_isAskingSun);
                    _tipaObject.SetActive(!_isAskingSun);
                }
            }
        }
    }
}