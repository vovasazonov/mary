using Project.CoreDomain.Services.Audio;
using Project.CoreDomain.Services.Data;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Tutorial;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Settings.View
{
    public class SettingsView : MonoBehaviour
    {
        [SerializeField] private Toggle _musicToggle;
        [SerializeField] private Button _resetProgressButton;
        private IAudioService _audioService;
        private IDataStorageService _dataStorageService;
        private PrimitiveData<bool> _isMusicOnData;
        private IRuleModel _ruleModel;
        private const string _isMusicOnDataKey = "is_music_on";

        [Inject]
        private void Constructor(
            IAudioService audioService,
            IDataStorageService dataStorageService,
            IRuleModel ruleModel
        )
        {
            _audioService = audioService;
            _dataStorageService = dataStorageService;
            _ruleModel = ruleModel;
        }

        private void Awake()
        {
            bool isMusicOn = !_dataStorageService.Contains(_isMusicOnDataKey) || _dataStorageService.Get<PrimitiveData<bool>>(_isMusicOnDataKey).Value;
            _isMusicOnData = _dataStorageService.Contains(_isMusicOnDataKey)
                ? _dataStorageService.Get<PrimitiveData<bool>>(_isMusicOnDataKey)
                : _dataStorageService.Create<PrimitiveData<bool>>(_isMusicOnDataKey);
            _isMusicOnData.Value = isMusicOn;
            _musicToggle.isOn = _isMusicOnData.Value;
            _audioService.Music.Volume = _isMusicOnData.Value ? 1f : 0f;
            _audioService.Sound.Volume = _isMusicOnData.Value ? 1f : 0f;
        }

        private void OnEnable()
        {
            _musicToggle.onValueChanged.AddListener(OnMusicToggleChanged);
            _resetProgressButton.onClick.AddListener(OnResetProgressClicked);
        }

        private void OnDisable()
        {
            _musicToggle.onValueChanged.RemoveListener(OnMusicToggleChanged);
            _resetProgressButton.onClick.RemoveListener(OnResetProgressClicked);
        }

        private void OnResetProgressClicked()
        {
            _ruleModel.ResetData();
            PlayerPrefs.DeleteAll();
        }

        private void OnMusicToggleChanged(bool isOn)
        {
            _isMusicOnData.Value = isOn;
            _audioService.Music.Volume = _isMusicOnData.Value ? 1f : 0f;
            _audioService.Sound.Volume = _isMusicOnData.Value ? 1f : 0f;
            _dataStorageService.Save();
        }

        public void BuyBook()
        {
            TutorialView.Instance.Show();
        }
    }
}