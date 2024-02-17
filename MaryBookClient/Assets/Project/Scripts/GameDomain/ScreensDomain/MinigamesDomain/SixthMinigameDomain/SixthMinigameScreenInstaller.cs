using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SixthMinigameDomain.Game;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SixthMinigameDomain
{
    public class SixthMinigameScreenInstaller : Installer<SixthMinigameScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<SixthMinigameScreen>().AsSingle();
            Container.Bind<SixthMinigameProgress>().AsSingle();
        }
    }
}