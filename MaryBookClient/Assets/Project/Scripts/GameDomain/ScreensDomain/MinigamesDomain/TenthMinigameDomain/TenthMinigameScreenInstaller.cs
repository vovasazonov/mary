using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.TenthMinigameDomain.Game;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.TenthMinigameDomain
{
    public class TenthMinigameScreenInstaller : Installer<TenthMinigameScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<TenthMinigameScreen>().AsSingle();
            Container.Bind<TenthProgress>().AsSingle();
        }
    }
}