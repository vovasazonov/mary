using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SeventhMinigameDomain.Game;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SeventhMinigameDomain
{
    public class SeventhMinigameScreenInstaller : Installer<SeventhMinigameScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<SeventhMinigameScreen>().AsSingle();
        }
    }
}