using System;
using Cysharp.Threading.Tasks;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SeventhMinigameDomain.Game
{
    public class MazeView : MonoBehaviour
    {
        [SerializeField] private GameObject _wallPrefab;
        [SerializeField] private GameObject _waterPrefab;
        [SerializeField] private GameObject _garin;
        [SerializeField] private float _width;
        [SerializeField] private SeventhMinigameInputView _input;
        private const int _wallId = 1;
        private const int _floorId = 0;
        private const int _playerId = 2;
        private const int _exitId = 3;
        private const int _waterId = 4;
        private (int x, int y) _playerIndex;
        private (int x, int y) _startPositionPlayerIndex;
        private Vector3 _startPositionPlayer;
        private IRuleModel _ruleModel;

        private int[,] _maze = new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 2, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1 },
            { 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1 },
            { 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1 },
            { 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1 },
            { 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1 },
            { 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1 },
            { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 3 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };

        public bool IsWon { get; private set; }

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }
        
        private void Awake()
        {
            _playerIndex = GetPlayerIndex();
            _startPositionPlayerIndex = _playerIndex;
            _startPositionPlayer = _garin.transform.position;
            GenerateMazeView();
        }

        private void GenerateMazeView()
        {
            for (int i = 0; i < _maze.GetLength(0); i++)
            {
                for (int j = 0; j < _maze.GetLength(1); j++)
                {
                    if (_maze[i, j] == _wallId)
                    {
                        var wall = Instantiate(_wallPrefab, transform);
                        UpdatePosition(j, i, wall);
                    }
                }
            }
        }

        private void UpdatePosition(int x, int y, GameObject obj)
        {
            var position = _startPositionPlayer;
            position.x = _startPositionPlayer.x + _width * (x + _startPositionPlayerIndex.x);
            position.y = _startPositionPlayer.y - (_width * (y - _startPositionPlayerIndex.y));
            obj.transform.position = position;
        }

        private (int x, int y) GetPlayerIndex()
        {
            for (int i = 0; i < _maze.GetLength(0); i++)
            {
                for (int j = 0; j < _maze.GetLength(1); j++)
                {
                    if (_maze[i, j] == _playerId)
                    {
                        return (j, i);
                    }
                }
            }

            throw new ArgumentOutOfRangeException();
        }

        private void Update()
        {
            if (!IsWon)
            {
                if (_input.Direction != Vector2Int.zero)
                {
                    (int x, int y) newPlayerIndex = (_playerIndex.x + _input.Direction.x, _playerIndex.y + _input.Direction.y);
                    bool isIndexesOnMaze = newPlayerIndex.x < _maze.GetLength(1) && newPlayerIndex.y < _maze.GetLength(0);

                    if (isIndexesOnMaze)
                    {
                        bool isFloor = _maze[newPlayerIndex.y, newPlayerIndex.x] == _floorId;
                        bool isExit = _maze[newPlayerIndex.y, newPlayerIndex.x] == _exitId;

                        if (isFloor || isExit)
                        {
                            _maze[_playerIndex.y, _playerIndex.x] = _floorId;
                            _playerIndex = newPlayerIndex;
                            _maze[_playerIndex.y, _playerIndex.x] = _playerId;
                            UpdatePosition(_playerIndex.x, _playerIndex.y, _garin);

                            if (isExit)
                            {
                                IsWon = true;
                            }
                        }
                    }

                    _input.Direction = Vector2Int.zero;
                }
            }
        }
    }
}