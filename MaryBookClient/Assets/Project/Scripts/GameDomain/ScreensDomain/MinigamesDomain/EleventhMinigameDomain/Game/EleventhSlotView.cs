using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EleventhMinigameDomain.Game
{
    public class EleventhSlotView : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private EleventhProgress _progress;

        public int Id => _id;

        [Inject]
        private void Constructor(EleventhProgress progress)
        {
            _progress = progress;
        }

        private void Awake()
        {
            _progress.MaxProgress++;
            HideColliderForSeconds();
        }

        public void Match()
        {
            _spriteRenderer.enabled = true;
            _progress.Progress++;
        }

        private async UniTask HideColliderForSeconds()
        {
            var collider = GetComponent<PolygonCollider2D>();
            collider.enabled = false;
            await UniTask.Delay(3000);
            collider.enabled = true;
        }
    }
}