using Cysharp.Threading.Tasks;
using Project.CoreDomain.Services.Screen;
using Project.CoreDomain.Services.View;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FourthMinigameDomain.Game;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FourthMinigameDomain
{
    public class FourthMinigameScreen : Screen<FourthMinigameScreen>
    {
        private readonly IViewService _viewService;
        private IDisposableView<FourthMinigameView> _view;
        protected override string ScreenId => Id;

        public static string Id => "FourthMinigameScreen";
        public override bool IsDisposeOnSwitch => true;

        public FourthMinigameScreen(
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
            _view = await _viewService.CreateAsync<FourthMinigameView>(FourthMinigameScreenContentIds.AreaPrefabId);
        }

        protected override UniTask DisposeScreenAsync()
        {
            _view?.Dispose();
            _view = null;
            return UniTask.CompletedTask;
        }
    }
}