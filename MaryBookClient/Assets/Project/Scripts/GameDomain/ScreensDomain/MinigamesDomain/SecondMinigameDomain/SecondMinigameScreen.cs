using Cysharp.Threading.Tasks;
using Project.CoreDomain.Services.Screen;
using Project.CoreDomain.Services.View;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SecondMinigameDomain.Game;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SecondMinigameDomain
{
    public class SecondMinigameScreen : Screen<SecondMinigameScreen>
    {
        private readonly IViewService _viewService;
        private IDisposableView<SecondMinigameView> _view;
        protected override string ScreenId => Id;

        public static string Id => "SecondMinigameScreen";
        public override bool IsDisposeOnSwitch => true;

        public SecondMinigameScreen(
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
            _view = await _viewService.CreateAsync<SecondMinigameView>(SecondMinigameScreenContentIds.AreaPrefabId);
        }

        protected override UniTask DisposeScreenAsync()
        {
            _view?.Dispose();
            _view = null;
            return UniTask.CompletedTask;
        }
    }
}