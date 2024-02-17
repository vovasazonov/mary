using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FifthMinigameDomain
{
    public class FifthMinigameScreenInstaller : Installer<FifthMinigameScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<FifthMinigameScreen>().AsSingle();
        }
    }
}