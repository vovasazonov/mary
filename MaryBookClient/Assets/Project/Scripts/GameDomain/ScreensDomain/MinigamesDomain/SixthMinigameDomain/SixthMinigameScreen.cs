using Cysharp.Threading.Tasks;
using Project.CoreDomain.Services.Screen;
using Project.CoreDomain.Services.View;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SixthMinigameDomain.Game;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SixthMinigameDomain
{
    public class SixthMinigameScreen : Screen<SixthMinigameScreen>
    {
        private readonly IViewService _viewService;
        private IDisposableView<SixthMinigameView> _view;
        protected override string ScreenId => Id;

        public static string Id => "SixthMinigameScreen";
        public override bool IsDisposeOnSwitch => true;

        public SixthMinigameScreen(
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
            _view = await _viewService.CreateAsync<SixthMinigameView>(SixthMinigameScreenContentIds.AreaPrefabId);
        }

        protected override UniTask DisposeScreenAsync()
        {
            _view?.Dispose();
            _view = null;
            return UniTask.CompletedTask;
        }
    }
}