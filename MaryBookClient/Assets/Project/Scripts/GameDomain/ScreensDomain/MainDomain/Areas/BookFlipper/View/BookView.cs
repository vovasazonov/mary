using Cysharp.Threading.Tasks;
using Project.CoreDomain.Services.Audio;
using Project.CoreDomain.Services.Audio.Configs.AudioPlayer;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.BookFlipper.View
{
    public class BookView : MonoBehaviour, IBookView
    {
        [SerializeField] private Sprite _betweenPagesSprite;
        [SerializeField] private Book _book;
        [SerializeField] private AutoFlip _autoFlip;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private AudioPlayerConfig _bookFlipSound;
        
        public static IBookView Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
            _book.bookPages = new Sprite[2];
            _book.bookPages[0] = null;
            _book.bookPages[1] = _betweenPagesSprite;
            Hide();
        }

        public void Show()
        {
            _book.currentPage = 0;
            _book.UpdateSprites();
            _canvasGroup.alpha = 1;
        }

        public void Flip()
        {
            FlipAsync();
        }

        private async UniTask FlipAsync()
        {
            _autoFlip.FlipRightPage();
            await UniTask.Delay(2000);
            Hide();
            _autoFlip.FlipLeftPage();
        }

        public void Hide()
        {
            _canvasGroup.alpha = 0;
        }

        public void SetFirstPage(Texture2D texture)
        {
            int indexPage = 0;
            SetPage(texture, indexPage);
        }

        public void PlayFlipSound(IAudioService audioService)
        {
            audioService.Sound.PlayImmediately(_bookFlipSound);
        }

        private void SetPage(Texture2D texture, int indexPage)
        {
            Destroy(_book.bookPages[indexPage]);
            _book.bookPages[indexPage] = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
    }
}