using System;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FirstMinigameDomain.Game
{
    public class TreeTouchesTuciView : MonoBehaviour
    {
        [SerializeField] private GameObject _arrow;
        [SerializeField] private Animator _animator;
        [SerializeField] private Slider _treeSlider;
        [SerializeField] private float _treeProgressSpeed = 5;
        [SerializeField] private Animator _orangeAnimator;
        private IRuleModel _ruleModel;
        private bool _isTuciInTree;
        private bool _isTuciAndTreePartWon;

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }

        private void OnEnable()
        {
            _ruleModel.Started += OnStarted;

            ResetValues();
        }

        private void OnDisable()
        {
            _ruleModel.Started -= OnStarted;
        }

        private void OnStarted()
        {
            ResetValues();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<TuciFlyView>() != null)
            {
                _treeSlider.gameObject.SetActive(!_isTuciAndTreePartWon && true);
                _arrow.SetActive(false);
                _animator.Play("TreeShaking");
                _isTuciInTree = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<TuciFlyView>() != null)
            {
                _animator.Play("TreeIdle");
                _isTuciInTree = false;
            }
        }

        private void Update()
        {
            UpdateTuciTreeProgress();
            UpdateCheckTuciAndTreePartWon();
        }

        private void UpdateCheckTuciAndTreePartWon()
        {
            if (!_isTuciAndTreePartWon && _treeSlider.value > 0.99f)
            {
                _treeSlider.gameObject.SetActive(false);
                _isTuciAndTreePartWon = true;
                _orangeAnimator.Play("OrangeFall");
            }
        }

        private void UpdateTuciTreeProgress()
        {
            if (_isTuciInTree)
            {
                _treeSlider.value += _treeProgressSpeed * Time.deltaTime;
            }
        }

        private void ResetValues()
        {
            _arrow.SetActive(!_isTuciAndTreePartWon);
            _animator.Play("idle");
            _treeSlider.gameObject.SetActive(!_isTuciAndTreePartWon);
            _treeSlider.value = 0;
            _isTuciInTree = false;
        }
    }
}