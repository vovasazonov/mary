using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.NinthMinigameDomain
{
    public class NinthMinigameScreenInstaller : Installer<NinthMinigameScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<NinthMinigameScreen>().AsSingle();
        }
    }
}