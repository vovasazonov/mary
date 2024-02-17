using Cysharp.Threading.Tasks;
using Project.CoreDomain.Services.Screen;
using Project.CoreDomain.Services.View;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FifthMinigameDomain.Game;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FifthMinigameDomain
{
    public class FifthMinigameScreen : Screen<FifthMinigameScreen>
    {
        private readonly IViewService _viewService;
        private IDisposableView<FifthMinigameView> _view;
        protected override string ScreenId => Id;

        public static string Id => "FifthMinigameScreen";
        public override bool IsDisposeOnSwitch => true;

        public FifthMinigameScreen(
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
            _view = await _viewService.CreateAsync<FifthMinigameView>(FifthMinigameScreenContentIds.AreaPrefabId);
        }

        protected override UniTask DisposeScreenAsync()
        {
            _view?.Dispose();
            _view = null;
            return UniTask.CompletedTask;
        }
    }
}