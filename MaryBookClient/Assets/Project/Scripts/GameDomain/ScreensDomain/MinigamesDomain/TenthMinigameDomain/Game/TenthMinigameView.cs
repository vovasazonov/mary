using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.TenthMinigameDomain.Game
{
    public class TenthMinigameView : MonoBehaviour
    {
        [SerializeField] private FallObjectTreeView _fallTreeObject;
        [SerializeField] private Transform _leftBorder;
        [SerializeField] private Transform _rightBorder;
        [SerializeField] private Transform _bottomBorder;
        [SerializeField] private float _speed;
        [SerializeField] private Slider _slider;
        [SerializeField] private float _speedProgressDown = 0.1f;
        [SerializeField] private List<GameObject> _trees;
        private TenthProgress _progress;
        private bool _isWon;
        private IRuleModel _ruleModel;
        private int _level;

        [Inject]
        private void Constructor(TenthProgress progress, IRuleModel ruleModel)
        {
            _progress = progress;
            _ruleModel = ruleModel;
        }
        
        private void Awake()
        {
            InitializeFallObject();
        }

        private void InitializeFallObject()
        {
            var x = Random.Range(_leftBorder.position.x, _rightBorder.position.x);
            _fallTreeObject.transform.position = new Vector3(x, _leftBorder.position.y);
            _fallTreeObject.IsSun = Random.Range(0, 2) == 1;
        }

        private void OnEnable()
        {
            _fallTreeObject.Gotted += OnGotted;
        }

        private void OnDisable()
        {
            _fallTreeObject.Gotted -= OnGotted;
        }

        private void OnGotted()
        {
            InitializeFallObject();
        }

        private void Update()
        {
            if (_isWon)
            {
                return;
            }
            
            if (_progress.Progress > 0.99f)
            {
                _isWon = true;
                Finish();
                return;
            }

            _progress.Progress = _progress.Progress - _speedProgressDown * Time.deltaTime;
            
            _slider.value = _progress.Progress;

            UpdateLevelTree();
            
            if (_fallTreeObject.transform.position.y < _bottomBorder.position.y)
            {
                InitializeFallObject();
            }

            var position = _fallTreeObject.transform.position;
            position.x = position.x + _speed * Time.deltaTime * GetDirectionInput().x;
            position.y = position.y - _speed * Time.deltaTime;
            _fallTreeObject.transform.position = position;
        }

        private void UpdateLevelTree()
        {
            if (_progress.Progress > 0.3 && _level == 0)
            {
                _level = 1;
                _trees.ForEach(i=>i.SetActive(false));
                _trees[_level].SetActive(true);
            }
        }

        private async UniTask Finish()
        {
            _level = 2;
            _trees.ForEach(i=>i.SetActive(false));
            _trees[_level].SetActive(true);
            _ruleModel.FullProgress();
            await UniTask.Delay(3000);
            _ruleModel.Finish();
        }

        private Vector2 GetDirectionInput()
        {
            if (Input.touchCount > 0 || Input.GetMouseButton(0))
            {
                var position = Input.touchCount > 0  ? Input.touches[0].position : (Vector2)Input.mousePosition;
                if (position.x > Screen.width/2f)
                {
                    return Vector2.right;
                }
                else
                {
                    return Vector2.left;
                }
            }
            
            return Vector2.zero;
        }
    }
}