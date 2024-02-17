using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using Zenject;

namespace Project.GameDomain.ScreensDomain
{
    public class AreasInstaller : Installer<AreasInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<RuleModel>().AsSingle();
        }
    }
}