using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EighthMinigameDomain
{
    public class EighthMinigameScreenInstaller : Installer<EighthMinigameScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<EighthMinigameScreen>().AsSingle();
        }
    }
}