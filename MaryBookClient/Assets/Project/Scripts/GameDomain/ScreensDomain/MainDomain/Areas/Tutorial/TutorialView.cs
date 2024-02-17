using System;
using Project.CoreDomain.Services.Audio;
using Project.CoreDomain.Services.Audio.Configs.AudioPlayer;
using UnityEngine;
using Zenject;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Tutorial
{
    public class TutorialView : MonoBehaviour
    {
        [SerializeField] private AudioPlayerConfig _clickSound;
        private IAudioService _audioService;

        public static TutorialView Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(this);
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        [Inject]
        private void Constructor(IAudioService audioService)
        {
            _audioService = audioService;
        }
        
        public void ConnectToWhatsApp()
        {
            // https://wa.me/972542426742?text=שלום!%20הגעתי%20מהמשחק%20"עץ%20הדר%20בלב%20מדבר"%20ואני%20רוצה%20לרכוש%20את%20הספר.
            Application.OpenURL("https://wa.me/972542426742?text=%D7%A9%D7%9C%D7%95%D7%9D!%20%D7%94%D7%92%D7%A2%D7%AA%D7%99%20%D7%9E%D7%94%D7%9E%D7%A9%D7%97%D7%A7%20%22%D7%A2%D7%A5%20%D7%94%D7%93%D7%A8%20%D7%91%D7%9C%D7%91%20%D7%9E%D7%93%D7%91%D7%A8%22%20%D7%95%D7%90%D7%A0%D7%99%20%D7%A8%D7%95%D7%A6%D7%94%20%D7%9C%D7%A8%D7%9B%D7%95%D7%A9%20%D7%90%D7%AA%20%D7%94%D7%A1%D7%A4%D7%A8.");
        }
        
        public void BuyViaLink()
        {
             Application.OpenURL("https://www.netbook.co.il/Book.aspx?id=14030");
        }

        public void PlayClickSound()
        {
            //_audioService.Sound.PlayImmediately(_clickSound);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}