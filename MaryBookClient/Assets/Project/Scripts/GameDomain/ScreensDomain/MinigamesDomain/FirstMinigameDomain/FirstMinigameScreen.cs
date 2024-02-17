using Cysharp.Threading.Tasks;
using Project.CoreDomain.Services.Screen;
using Project.CoreDomain.Services.View;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FirstMinigameDomain.Game;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FirstMinigameDomain
{
    public class FirstMinigameScreen : Screen<FirstMinigameScreen>
    {
        private readonly IViewService _viewService;
        private IDisposableView<FirstMinigameView> _view;
        protected override string ScreenId => Id;

        public static string Id => "FirstMinigameScreen";
        public override bool IsDisposeOnSwitch => true;

        public FirstMinigameScreen(
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
            _view = await _viewService.CreateAsync<FirstMinigameView>(FirstMinigameScreenContentIds.AreaPrefabId);
        }

        protected override UniTask DisposeScreenAsync()
        {
            _view?.Dispose();
            _view = null;
            return UniTask.CompletedTask;
        }
    }
}