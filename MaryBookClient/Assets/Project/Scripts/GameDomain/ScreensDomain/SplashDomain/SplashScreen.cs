using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Project.CoreDomain;
using Project.CoreDomain.Services.Screen;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.SplashDomain
{
    public class SplashScreen : Screen<SplashScreen>
    {
        private readonly List<ITaskAsyncInitializable> _initializables;

        protected override string ScreenId => Id;

        public static string Id => "SplashScreen";
        public override bool IsDisposeOnSwitch => true;

        public SplashScreen(List<ITaskAsyncInitializable> initializables)
        {
            _initializables = initializables;
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
            Application.targetFrameRate = 120;
            
            foreach (var initializable in _initializables)
            {
                await initializable.InitializeAsync();
            }
        }

        protected override UniTask DisposeScreenAsync()
        {
            return UniTask.CompletedTask;
        }
    }
}