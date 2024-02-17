using Cysharp.Threading.Tasks;
using Project.CoreDomain.Services.Screen;
using Project.CoreDomain.Services.View;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.TwelfthMinigameDomain.Game;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.TwelfthMinigameDomain
{
    public class TwelfthMinigameScreen : Screen<TwelfthMinigameScreen>
    {
        private readonly IViewService _viewService;
        private IDisposableView<TwelfthMinigameView> _view;
        protected override string ScreenId => Id;

        public static string Id => "TwelfthMinigameScreen";
        public override bool IsDisposeOnSwitch => true;

        public TwelfthMinigameScreen(
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
            _view = await _viewService.CreateAsync<TwelfthMinigameView>(TwelfthMinigameScreenContentIds.AreaPrefabId);
        }

        protected override UniTask DisposeScreenAsync()
        {
            _view?.Dispose();
            _view = null;
            return UniTask.CompletedTask;
        }
    }
}