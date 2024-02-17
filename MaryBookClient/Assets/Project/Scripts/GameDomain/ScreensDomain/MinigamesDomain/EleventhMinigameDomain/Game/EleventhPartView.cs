using System;
using UnityEngine;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EleventhMinigameDomain.Game
{
    public class EleventhPartView : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private Camera _camera;

        public int Id => _id;

        private EleventhSlotView _eleventhSlot;
        private bool _isFollowing;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var slot = other.gameObject.GetComponent<EleventhSlotView>();

            if (slot != null && slot.Id == _id)
            {
                _eleventhSlot = slot;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var slot = other.gameObject.GetComponent<EleventhSlotView>();

            if (slot != null && slot.Id == _id)
            {
                _eleventhSlot = null;
            }
        }

        private void Update()
        {
            if (_isFollowing)
            {
                if (Input.touchCount > 0 || Input.GetMouseButton(0))
                {
                    var position = _camera.ScreenToWorldPoint(Input.touchCount > 0 ? Input.touches[0].position : (Vector2)Input.mousePosition);
                    transform.position = new Vector3(position.x, position.y, 0);
                }
            }
        }

        private void OnMouseUp()
        {
            _isFollowing = false;
            if (_eleventhSlot != null)
            {
                if (_eleventhSlot.Id == _id)
                {
                    _eleventhSlot.Match();
                    Destroy(gameObject);
                }
            }

            _eleventhSlot = null;
        }

        private void OnMouseDown()
        {
            _eleventhSlot = null;
            _isFollowing = true;
        }
    }
}