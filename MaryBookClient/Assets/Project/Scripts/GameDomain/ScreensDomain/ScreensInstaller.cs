using Project.GameDomain.ScreensDomain.LoadingDomain;
using Project.GameDomain.ScreensDomain.MainDomain;
using Project.GameDomain.ScreensDomain.SplashDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EighthMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EleventhMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FifthMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FirstMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FourthMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.NinthMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SecondMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SeventhMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SixthMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.TenthMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.ThirdMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.TwelfthMinigameDomain;
using Zenject;

namespace Project.GameDomain.ScreensDomain
{
    public class ScreensInstaller : Installer<ScreensInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindFactory<SplashScreen, SplashScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<SplashScreenInstaller>().WithGameObjectName(SplashScreen.Id + SplashScreen.ContextPostfix);
            Container.BindInterfacesTo<SplashScreen.Factory>().AsSingle();
            Container.BindInstance(SplashScreen.Id).WhenInjectedInto<SplashScreen.Factory>();
            
            Container.BindFactory<LoadingScreen, LoadingScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<LoadingScreenInstaller>().WithGameObjectName(LoadingScreen.Id + LoadingScreen.ContextPostfix);
            Container.BindInterfacesTo<LoadingScreen.Factory>().AsSingle();
            Container.BindInstance(LoadingScreen.Id).WhenInjectedInto<LoadingScreen.Factory>();

            Container.BindFactory<MainScreen, MainScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<MainScreenInstaller>().WithGameObjectName(MainScreen.Id + MainScreen.ContextPostfix);
            Container.BindInterfacesTo<MainScreen.Factory>().AsSingle();
            Container.BindInstance(MainScreen.Id).WhenInjectedInto<MainScreen.Factory>();
            
            Container.BindFactory<FirstMinigameScreen, FirstMinigameScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<FirstMinigameScreenInstaller>().WithGameObjectName(FirstMinigameScreen.Id + FirstMinigameScreen.ContextPostfix);
            Container.BindInterfacesTo<FirstMinigameScreen.Factory>().AsSingle();
            Container.BindInstance(FirstMinigameScreen.Id).WhenInjectedInto<FirstMinigameScreen.Factory>();
            
            Container.BindFactory<SecondMinigameScreen, SecondMinigameScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<SecondMinigameScreenInstaller>().WithGameObjectName(SecondMinigameScreen.Id + SecondMinigameScreen.ContextPostfix);
            Container.BindInterfacesTo<SecondMinigameScreen.Factory>().AsSingle();
            Container.BindInstance(SecondMinigameScreen.Id).WhenInjectedInto<SecondMinigameScreen.Factory>();
            
            Container.BindFactory<ThirdMinigameScreen, ThirdMinigameScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<ThirdMinigameScreenInstaller>().WithGameObjectName(ThirdMinigameScreen.Id + ThirdMinigameScreen.ContextPostfix);
            Container.BindInterfacesTo<ThirdMinigameScreen.Factory>().AsSingle();
            Container.BindInstance(ThirdMinigameScreen.Id).WhenInjectedInto<ThirdMinigameScreen.Factory>();
            
            Container.BindFactory<FourthMinigameScreen, FourthMinigameScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<FourthMinigameScreenInstaller>().WithGameObjectName(FourthMinigameScreen.Id + FourthMinigameScreen.ContextPostfix);
            Container.BindInterfacesTo<FourthMinigameScreen.Factory>().AsSingle();
            Container.BindInstance(FourthMinigameScreen.Id).WhenInjectedInto<FourthMinigameScreen.Factory>();
            
            Container.BindFactory<FifthMinigameScreen, FifthMinigameScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<FifthMinigameScreenInstaller>().WithGameObjectName(FifthMinigameScreen.Id + FifthMinigameScreen.ContextPostfix);
            Container.BindInterfacesTo<FifthMinigameScreen.Factory>().AsSingle();
            Container.BindInstance(FifthMinigameScreen.Id).WhenInjectedInto<FifthMinigameScreen.Factory>();
            
            Container.BindFactory<SixthMinigameScreen, SixthMinigameScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<SixthMinigameScreenInstaller>().WithGameObjectName(SixthMinigameScreen.Id + SixthMinigameScreen.ContextPostfix);
            Container.BindInterfacesTo<SixthMinigameScreen.Factory>().AsSingle();
            Container.BindInstance(SixthMinigameScreen.Id).WhenInjectedInto<SixthMinigameScreen.Factory>();
            
            Container.BindFactory<SeventhMinigameScreen, SeventhMinigameScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<SeventhMinigameScreenInstaller>().WithGameObjectName(SeventhMinigameScreen.Id + SeventhMinigameScreen.ContextPostfix);
            Container.BindInterfacesTo<SeventhMinigameScreen.Factory>().AsSingle();
            Container.BindInstance(SeventhMinigameScreen.Id).WhenInjectedInto<SeventhMinigameScreen.Factory>();
            
            Container.BindFactory<EighthMinigameScreen, EighthMinigameScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<EighthMinigameScreenInstaller>().WithGameObjectName(EighthMinigameScreen.Id + EighthMinigameScreen.ContextPostfix);
            Container.BindInterfacesTo<EighthMinigameScreen.Factory>().AsSingle();
            Container.BindInstance(EighthMinigameScreen.Id).WhenInjectedInto<EighthMinigameScreen.Factory>();
            
            Container.BindFactory<NinthMinigameScreen, NinthMinigameScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<NinthMinigameScreenInstaller>().WithGameObjectName(NinthMinigameScreen.Id + NinthMinigameScreen.ContextPostfix);
            Container.BindInterfacesTo<NinthMinigameScreen.Factory>().AsSingle();
            Container.BindInstance(NinthMinigameScreen.Id).WhenInjectedInto<NinthMinigameScreen.Factory>();
            
            Container.BindFactory<TenthMinigameScreen, TenthMinigameScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<TenthMinigameScreenInstaller>().WithGameObjectName(TenthMinigameScreen.Id + TenthMinigameScreen.ContextPostfix);
            Container.BindInterfacesTo<TenthMinigameScreen.Factory>().AsSingle();
            Container.BindInstance(TenthMinigameScreen.Id).WhenInjectedInto<TenthMinigameScreen.Factory>();
            
            Container.BindFactory<EleventhMinigameScreen, EleventhMinigameScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<EleventhMinigameScreenInstaller>().WithGameObjectName(EleventhMinigameScreen.Id + EleventhMinigameScreen.ContextPostfix);
            Container.BindInterfacesTo<EleventhMinigameScreen.Factory>().AsSingle();
            Container.BindInstance(EleventhMinigameScreen.Id).WhenInjectedInto<EleventhMinigameScreen.Factory>();
            
            Container.BindFactory<TwelfthMinigameScreen, TwelfthMinigameScreen.ZenjectFactory>().FromSubContainerResolve().ByNewGameObjectInstaller<TwelfthMinigameScreenInstaller>().WithGameObjectName(TwelfthMinigameScreen.Id + TwelfthMinigameScreen.ContextPostfix);
            Container.BindInterfacesTo<TwelfthMinigameScreen.Factory>().AsSingle();
            Container.BindInstance(TwelfthMinigameScreen.Id).WhenInjectedInto<TwelfthMinigameScreen.Factory>();
        }
    }}