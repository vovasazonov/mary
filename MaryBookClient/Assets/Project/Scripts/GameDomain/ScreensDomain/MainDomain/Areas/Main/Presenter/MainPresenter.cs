using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Project.CoreDomain;
using Project.CoreDomain.Services.Audio;
using Project.CoreDomain.Services.Data;
using Project.CoreDomain.Services.Screen;
using Project.CoreDomain.Services.View;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.BookFlipper.View;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Dialog.View;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Main.View;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Main.Presenter
{
    public class MainPresenter : IPresenter
    {
        private IDisposableView<IMainView> _view;
        private readonly IViewService _viewService;
        private readonly IRuleModel _ruleModel;
        private readonly IScreensService _screensService;
        private readonly List<ITaskAsyncDisposable> _disposables = new();
        private readonly IAudioService _audioService;

        public MainPresenter(
            IViewService viewService,
            IRuleModel ruleModel,
            IScreensService screensService,
            IDataStorageService dataStorageService,
            IAudioService audioService
        )
        {
            _viewService = viewService;
            _ruleModel = ruleModel;
            _screensService = screensService;
            _audioService = audioService;

            UpdateMusicStatus(dataStorageService, audioService);
        }

        private static void UpdateMusicStatus(IDataStorageService dataStorageService, IAudioService audioService)
        {
            string isMusicOnDataKey = "is_music_on";
            bool isMusicOn = !dataStorageService.Contains(isMusicOnDataKey) || dataStorageService.Get<PrimitiveData<bool>>(isMusicOnDataKey).Value;
            audioService.Music.Volume = isMusicOn ? 1f : 0f;
            audioService.Sound.Volume = isMusicOn ? 1f : 0f;
        }

        public async UniTask InitializeAsync()
        {
            _view = await _viewService.CreateAsync<MainView>(MainScreenContentIds.MainCanvas);
            _view.Value.ShowMenu();

            AddListeners();
        }

        private async UniTask InitializePresenter(IPresenter presenter)
        {
            await presenter.InitializeAsync();
            _disposables.Add(presenter);
        }

        private void AddListeners()
        {
            _view.Value.PlayClicked += OnPlayClicked;
            _ruleModel.Finished += OnMinigameFinished;
            _ruleModel.Started += OnMinigameStarted;
            _ruleModel.LevelRequested += OnLevelRequested;
        }

        private void RemoveListeners()
        {
            _view.Value.PlayClicked -= OnPlayClicked;
            _ruleModel.Finished -= OnMinigameFinished;
            _ruleModel.Started -= OnMinigameStarted;
            _ruleModel.LevelRequested -= OnLevelRequested;
        }

        private void OnLevelRequested(int level)
        {
            _ruleModel.CurrentLevel = level;
            StartMinigame(true, level);
        }

        private void OnMinigameStarted()
        {
            _view.Value.HideMenu();
        }

        private void OnMinigameFinished()
        {
            if (_ruleModel.IsMaxLevel)
            {
                StartMinigame(false, 11);
            }
            else
            {
                _ruleModel.CurrentLevel++;
                StartMinigame();
            }
        }

        private void OnPlayClicked()
        {
            StartMinigame(true, 11);
        }

        private async UniTask StartMinigame(bool isStartFromMenu = false, int specificLevel = -1)
        {
            if (!isStartFromMenu)
            {
                BookView.Instance.Show();
            }

            var level = specificLevel > -1 ? specificLevel : _ruleModel.CurrentLevel;
            switch (level)
            {
                case 0:
                    await _screensService.SwitchAsync("FirstMinigameScreen");
                    break;
                case 1:
                    await _screensService.SwitchAsync("SecondMinigameScreen");
                    break;
                case 2:
                    await _screensService.SwitchAsync("ThirdMinigameScreen");
                    break;
                case 3:
                    await _screensService.SwitchAsync("FourthMinigameScreen");
                    break;
                case 4:
                    await _screensService.SwitchAsync("FifthMinigameScreen");
                    break;
                case 5:
                    await _screensService.SwitchAsync("EighthMinigameScreen");
                    break;
                case 6:
                    await _screensService.SwitchAsync("SixthMinigameScreen");
                    break;
                case 7:
                    await _screensService.SwitchAsync("SeventhMinigameScreen");
                    break;
                case 8:
                    await _screensService.SwitchAsync("NinthMinigameScreen");
                    break;
                case 9:
                    await _screensService.SwitchAsync("TenthMinigameScreen");
                    break;
                case 10:
                    await _screensService.SwitchAsync("EleventhMinigameScreen");
                    break;
                case 11:
                    await _screensService.SwitchAsync("TwelfthMinigameScreen");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (!isStartFromMenu)
            {
                BookView.Instance.Flip();
                BookView.Instance.PlayFlipSound(_audioService);
            }

            if (specificLevel != 11)
            {
                DialogView.Instance.Show();
            }

            _ruleModel.Start();
        }

        public async UniTask DisposeAsync()
        {
            RemoveListeners();

            foreach (var disposable in _disposables)
            {
                await disposable.DisposeAsync();
            }

            _view.Dispose();
            _disposables.Clear();
        }
    }
}