using UnityEngine;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EighthMinigameDomain.Game
{
    public class WordInTextView : MonoBehaviour
    {
        [SerializeField] private int _id;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private EightProgressView _progressView;

        private void Awake()
        {
            _progressView.MaxProgress++;
            _spriteRenderer.enabled = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var wordRock = other.gameObject.GetComponent<WordRockView>();
            if (wordRock != null)
            {
                if (wordRock.Id == _id)
                {
                    _spriteRenderer.enabled = true;
                    _progressView.Progress++;
                    wordRock.IsDestroyed = true;
                    Destroy(other.gameObject);
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }
}