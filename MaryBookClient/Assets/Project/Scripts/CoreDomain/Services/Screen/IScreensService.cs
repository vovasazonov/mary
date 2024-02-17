using Cysharp.Threading.Tasks;

namespace Project.CoreDomain.Services.Screen
{
    public interface IScreensService
    {
        string Current { get; }
        
        UniTask SwitchAsync(string screenId);
    }
}