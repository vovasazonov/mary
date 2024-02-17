using Cysharp.Threading.Tasks;
using Project.CoreDomain.Services.Screen;
using Project.CoreDomain.Services.View;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.ThirdMinigameDomain.Game;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.ThirdMinigameDomain
{
    public class ThirdMinigameScreen : Screen<ThirdMinigameScreen>
    {
        private readonly IViewService _viewService;
        private IDisposableView<ThirdMinigameView> _view;
        protected override string ScreenId => Id;

        public static string Id => "ThirdMinigameScreen";
        public override bool IsDisposeOnSwitch => true;

        public ThirdMinigameScreen(
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
            _view = await _viewService.CreateAsync<ThirdMinigameView>(ThirdMinigameScreenContentIds.AreaPrefabId);
        }

        protected override UniTask DisposeScreenAsync()
        {
            _view?.Dispose();
            _view = null;
            return UniTask.CompletedTask;
        }
    }
}