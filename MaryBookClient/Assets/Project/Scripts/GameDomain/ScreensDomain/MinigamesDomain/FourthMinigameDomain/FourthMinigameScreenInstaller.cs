using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FourthMinigameDomain
{
    public class FourthMinigameScreenInstaller : Installer<FourthMinigameScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<FourthMinigameScreen>().AsSingle();
        }
    }
}