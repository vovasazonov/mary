using Project.CoreDomain.Services.Audio;
using Project.CoreDomain.Services.Audio.Configs.AudioPlayer;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using Zenject;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Confetti
{
    public class ConfettiFinishView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private AudioPlayerConfig _winSound;
        [SerializeField] private AudioPlayerConfig _confettiSound;
        private IRuleModel _ruleModel;
        private IAudioService _audioService;

        [Inject]
        private void Constructor(IRuleModel ruleModel, IAudioService audioService)
        {
            _ruleModel = ruleModel;
            _audioService = audioService;
        }

        private void OnEnable()
        {
            _ruleModel.FullProgressed += OnFullProgressed;
        }

        private void OnDisable()
        {
            _ruleModel.FullProgressed -= OnFullProgressed;
        }

        private void OnFullProgressed()
        {
            _particleSystem.gameObject.SetActive(true);
            _particleSystem.Play();
            _audioService.Sound.PlayImmediately(_winSound);
            _audioService.Sound.PlayImmediately(_confettiSound);
        }
    }
}