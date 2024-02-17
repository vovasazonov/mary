using Cysharp.Threading.Tasks;
using Project.CoreDomain.Services.Screen;
using Project.CoreDomain.Services.View;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EighthMinigameDomain.Game;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EighthMinigameDomain
{
    public class EighthMinigameScreen : Screen<EighthMinigameScreen>
    {
        private readonly IViewService _viewService;
        private IDisposableView<EighthMinigameView> _view;
        protected override string ScreenId => Id;

        public static string Id => "EighthMinigameScreen";
        public override bool IsDisposeOnSwitch => true;

        public EighthMinigameScreen(
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
            _view = await _viewService.CreateAsync<EighthMinigameView>(EighthMinigameScreenContentIds.AreaPrefabId);
        }

        protected override UniTask DisposeScreenAsync()
        {
            _view?.Dispose();
            _view = null;
            return UniTask.CompletedTask;
        }
    }
}