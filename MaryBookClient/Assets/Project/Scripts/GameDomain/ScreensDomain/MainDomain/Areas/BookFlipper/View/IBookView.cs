using Project.CoreDomain.Services.Audio;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.BookFlipper.View
{
    public interface IBookView
    {
        void Show();
        void Flip();
        void Hide();

        void SetFirstPage(Texture2D texture);
        void PlayFlipSound(IAudioService audioService);
    }
}