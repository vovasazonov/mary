using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SecondMinigameDomain
{
    public class SecondMinigameScreenInstaller : Installer<SecondMinigameScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<SecondMinigameScreen>().AsSingle();
        }
    }
}