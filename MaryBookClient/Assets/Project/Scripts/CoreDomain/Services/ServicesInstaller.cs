using Project.CoreDomain.Services.Audio;
using Project.CoreDomain.Services.Camera;
using Project.CoreDomain.Services.Content;
using Project.CoreDomain.Services.Data;
using Project.CoreDomain.Services.Di;
using Project.CoreDomain.Services.Engine;
using Project.CoreDomain.Services.FileLoader;
using Project.CoreDomain.Services.Logger;
using Project.CoreDomain.Services.Screen;
using Project.CoreDomain.Services.Serialization;
using Project.CoreDomain.Services.Time;
using Project.CoreDomain.Services.View;
using Zenject;

namespace Project.CoreDomain.Services
{
    public class ServicesInstaller : Installer<ServicesInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LoggerService>().AsSingle().NonLazy();
            Container.BindInterfacesTo<DataStorageService>().AsSingle();
            Container.BindInterfacesTo<FileLoaderService>().AsSingle();
            Container.BindInterfacesTo<AudioService>().AsSingle();
            Container.BindInterfacesTo<SerializerService>().AsSingle();
            Container.BindInterfacesTo<ContentService>().AsSingle();
            Container.BindInterfacesTo<ScreensService>().AsSingle();
            Container.BindInterfacesTo<EngineService>().AsSingle();
            Container.BindInterfacesTo<CameraService>().AsSingle();
            Container.BindInterfacesTo<DiService>().AsSingle();
            Container.BindInterfacesTo<ViewService>().AsSingle();
            Container.BindInterfacesTo<TimeService>().AsSingle();
        }
    }
}