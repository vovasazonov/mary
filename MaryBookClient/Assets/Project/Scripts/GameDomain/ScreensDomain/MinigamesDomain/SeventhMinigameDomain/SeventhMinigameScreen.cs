using Cysharp.Threading.Tasks;
using Project.CoreDomain.Services.Screen;
using Project.CoreDomain.Services.View;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SeventhMinigameDomain.Game;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SeventhMinigameDomain
{
    public class SeventhMinigameScreen : Screen<SeventhMinigameScreen>
    {
        private readonly IViewService _viewService;
        private IDisposableView<SeventhMinigameView> _view;
        protected override string ScreenId => Id;

        public static string Id => "SeventhMinigameScreen";
        public override bool IsDisposeOnSwitch => true;

        public SeventhMinigameScreen(
            IViewService viewService
        )
        {
            _viewService = viewService;
        }

        public override UniTask ShowAsync()
        {
            return UniTask.CompletedTask;
        }

        public override UniTask HideAsync()
        {
            return UniTask.CompletedTask;
        }

        protected override async UniTask InitializeScreenAsync()
        {
            _view = await _viewService.CreateAsync<SeventhMinigameView>(SeventhMinigameScreenContentIds.AreaPrefabId);
        }

        protected override UniTask DisposeScreenAsync()
        {
            _view?.Dispose();
            _view = null;
            return UniTask.CompletedTask;
        }
    }
}