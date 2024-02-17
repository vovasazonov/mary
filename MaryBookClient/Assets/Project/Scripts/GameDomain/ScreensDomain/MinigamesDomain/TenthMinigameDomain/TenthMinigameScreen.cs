using Cysharp.Threading.Tasks;
using Project.CoreDomain.Services.Screen;
using Project.CoreDomain.Services.View;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.TenthMinigameDomain.Game;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.TenthMinigameDomain
{
    public class TenthMinigameScreen : Screen<TenthMinigameScreen>
    {
        private readonly IViewService _viewService;
        private IDisposableView<TenthMinigameView> _view;
        protected override string ScreenId => Id;

        public static string Id => "TenthMinigameScreen";
        public override bool IsDisposeOnSwitch => true;

        public TenthMinigameScreen(
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
            _view = await _viewService.CreateAsync<TenthMinigameView>(TenthMinigameScreenContentIds.AreaPrefabId);
        }

        protected override UniTask DisposeScreenAsync()
        {
            _view?.Dispose();
            _view = null;
            return UniTask.CompletedTask;
        }
    }
}