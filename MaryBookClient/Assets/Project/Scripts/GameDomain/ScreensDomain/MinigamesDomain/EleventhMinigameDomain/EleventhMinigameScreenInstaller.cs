using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EleventhMinigameDomain.Game;
using Zenject;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EleventhMinigameDomain
{
    public class EleventhMinigameScreenInstaller : Installer<EleventhMinigameScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<EleventhMinigameScreen>().AsSingle();
            Container.Bind<EleventhProgress>().AsSingle();
        }
    }
}