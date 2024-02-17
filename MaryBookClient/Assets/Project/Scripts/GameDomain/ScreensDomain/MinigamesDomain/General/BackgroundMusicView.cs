using Project.CoreDomain.Services.Audio;
using Project.CoreDomain.Services.Audio.Configs.AudioPlayer;
using Project.CoreDomain.Services.Audio.Player;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.General
{
    public class BackgroundMusicView : MonoBehaviour
    {
        [SerializeField] private AudioPlayerConfig _audioPlayerConfig;
        private IAudioStopper _audioStopper;
        private IAudioService _audioService;

        [Inject]
        private void Constructor(IAudioService audioService)
        {
            _audioService = audioService;
        }

        private void Awake()
        {
            _audioStopper = _audioService.Music.PlayImmediately(_audioPlayerConfig);
        }

        private void OnDestroy()
        {
            if (_audioStopper != null)
            {
                _audioStopper.Stop();
                _audioStopper = null;
            }
        }
    }
}