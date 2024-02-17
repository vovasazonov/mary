using Cysharp.Threading.Tasks;
using Project.CoreDomain.Services.Screen;
using Project.CoreDomain.Services.View;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EleventhMinigameDomain.Game;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EleventhMinigameDomain
{
    public class EleventhMinigameScreen : Screen<EleventhMinigameScreen>
    {
        private readonly IViewService _viewService;
        private IDisposableView<EleventhMinigameView> _view;
        protected override string ScreenId => Id;

        public static string Id => "EleventhMinigameScreen";
        public override bool IsDisposeOnSwitch => true;

        public EleventhMinigameScreen(
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
            _view = await _viewService.CreateAsync<EleventhMinigameView>(EleventhMinigameScreenContentIds.AreaPrefabId);
        }

        protected override UniTask DisposeScreenAsync()
        {
            _view?.Dispose();
            _view = null;
            return UniTask.CompletedTask;
        }
    }
}