using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EighthMinigameDomain.Game
{
    public class WordRockView : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private GameObject _arrow;
        [SerializeField] private float _forceMultiplier = 3f;
        [SerializeField] private Camera _camera;
        private Rigidbody2D _rigidBody;
        private Vector3 _startPosition;
        private Vector2 _mousePressDownPosition;
        private Vector2 _mouseReleasePosition;
        private bool _isShoot;
        private bool _isDrag;

        public int Id => _id;
        public bool IsDestroyed { get; set; }

        private void Awake()
        {
            _arrow.gameObject.SetActive(false);
            _rigidBody = GetComponent<Rigidbody2D>();

            _rigidBody.isKinematic = true;
            _startPosition = transform.position;
        }

        private void Update()
        {
            UpdateArrow();
        }

        private void OnMouseDown()
        {
            _isDrag = true;
            _mousePressDownPosition = _camera.WorldToScreenPoint(transform.position); 
        }

        private void OnMouseUp()
        {
            _isDrag = false;
            _mouseReleasePosition = GetPointerPosition();
            Shoot(_mousePressDownPosition - _mouseReleasePosition);
        }

        private Vector2 GetPointerPosition()
        {
            return Input.touchCount > 0 ? Input.touches[0].position : Input.mousePosition;
        }

        private async UniTask Shoot(Vector2 force)
        {
            if (_isShoot)
            {
                return;
            }

            _rigidBody.isKinematic = false;
            _rigidBody.AddForce(force * _forceMultiplier);
            _isShoot = true;

            await UniTask.Delay(3000);

            if (!IsDestroyed)
            {
                _rigidBody.velocity = Vector2.zero;
                _rigidBody.angularVelocity = 0;
                _rigidBody.isKinematic = true;
                _isShoot = false;
                transform.position = _startPosition;
                transform.eulerAngles = Vector3.zero;
            }
        }

        private void UpdateArrow()
        {
            _arrow.SetActive(_isDrag);

            if (_isDrag)
            {
                var scale = _arrow.transform.localScale;
                scale.x = 1f + Vector2.Distance(_mousePressDownPosition, GetPointerPosition()) * 0.01f;
                _arrow.transform.localScale = scale;

                var vec1 = Vector2.right;
                var vec2 = GetPointerPosition() - _mousePressDownPosition;
                var sign = vec2.y > 0 ? 1 : -1;
                _arrow.transform.eulerAngles = new Vector3(0, 0, sign * Vector2.Angle(vec1, vec2) + 180);
            }
        }
    }
}