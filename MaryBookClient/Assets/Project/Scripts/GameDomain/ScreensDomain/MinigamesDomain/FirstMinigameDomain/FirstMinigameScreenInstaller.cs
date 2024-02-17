using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FirstMinigameDomain
{
    public class FirstMinigameScreenInstaller : Installer<FirstMinigameScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<FirstMinigameScreen>().AsSingle();
        }
    }
}