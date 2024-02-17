namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Dialog.View
{
    public interface IDialogView
    {
        bool IsActive { get; }
        void Show();
        void Hide();
    }
}