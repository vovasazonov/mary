using System;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Main.View
{
    public interface IMainView
    {
        event Action PlayClicked;
        void ShowMenu();
        void HideMenu();
    }
}