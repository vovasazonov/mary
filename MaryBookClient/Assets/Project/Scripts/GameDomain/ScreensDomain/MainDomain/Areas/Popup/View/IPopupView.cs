namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Popup.View
{
    public interface IPopupView
    {
        string Id { get; }
        void Open();
        void Close();
    }
}