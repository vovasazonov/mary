using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.ThirdMinigameDomain
{
    public class ThirdMinigameScreenInstaller : Installer<ThirdMinigameScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ThirdMinigameScreen>().AsSingle();
        }
    }
}