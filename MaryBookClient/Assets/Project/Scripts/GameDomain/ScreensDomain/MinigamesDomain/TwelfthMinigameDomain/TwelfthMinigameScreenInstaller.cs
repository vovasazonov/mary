using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.TwelfthMinigameDomain
{
    public class TwelfthMinigameScreenInstaller : Installer<TwelfthMinigameScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<TwelfthMinigameScreen>().AsSingle();
        }
    }
}