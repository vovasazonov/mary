using System;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter
{
    public interface IRuleModel
    {
        event Action Finished;
        event Action Finishing;
        event Action Started;
        event Action<int> LevelRequested;
        event Action FullProgressed;

        int CurrentLevel { get; set; }
        int HigherPassedLevel { get; }
        bool IsMaxLevel { get; }
        bool IsPassAllLevels { get; }

        void Finish();
        void FullProgress();
        void Start();
        void RequestLevel(int level);

        void ResetData();
    }
}