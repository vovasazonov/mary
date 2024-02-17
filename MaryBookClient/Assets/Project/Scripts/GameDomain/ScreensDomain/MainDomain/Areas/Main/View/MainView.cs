using System;
using Project.CoreDomain.Services.Audio;
using Project.CoreDomain.Services.Audio.Configs.AudioPlayer;
using Project.CoreDomain.Services.Audio.Player;
using Project.CoreDomain.Services.Screen;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Main.View
{
    public class MainView : MonoBehaviour, IMainView
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private GameObject _menuCanvas;
        [SerializeField] private GameObject _gameCanvas;
        [SerializeField] private AudioPlayerConfig _audioPlayerConfig;
        private IScreensService _screensService;
        private IAudioService _audioService;
        private IAudioStopper _audioStopper;

        public event Action PlayClicked;

        [Inject]
        private void Constructor(IScreensService screensService, IAudioService audioService)
        {
            _screensService = screensService;
            _audioService = audioService;
        }

        public void ShowMenu()
        {
            _audioStopper?.Stop();
            _audioStopper = _audioService.Music.PlayImmediately(_audioPlayerConfig);
            _menuCanvas.SetActive(true);
            _gameCanvas.SetActive(false);
        }

        public void HideMenu()
        {
            _audioStopper?.Stop();
            _menuCanvas.SetActive(false);
            _gameCanvas.SetActive(true);
        }

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayClicked);
            _exitButton.onClick.AddListener(OnExitClicked);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayClicked);
            _exitButton.onClick.RemoveListener(OnExitClicked);
        }

        private void OnExitClicked()
        {
            ShowMenu();
            _screensService.SwitchAsync(MainScreen.Id);
        }

        private void OnPlayClicked()
        {
            PlayClicked?.Invoke();
        }
    }
}