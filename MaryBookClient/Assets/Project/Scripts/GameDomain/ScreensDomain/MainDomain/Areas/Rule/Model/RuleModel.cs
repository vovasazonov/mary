using System;
using Project.CoreDomain.Services.Data;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter
{
    public class RuleModel : IRuleModel
    {
        public event Action Finishing;
        public event Action Finished;
        public event Action Started;
        public event Action<int> LevelRequested;
        public event Action FullProgressed;

        private readonly IDataStorageService _dataStorageService;
        private const string _levelDataKey = "level";
        private const string _isAllLevelsPassedDataKey = "is_all_levels_passed";
        private const string _higherPassLevelDataKey = "higher_passed_level";
        private int _maxLevel = 10;

        public RuleModel(IDataStorageService dataStorageService)
        {
            _dataStorageService = dataStorageService;
        }

        public int CurrentLevel
        {
            get 
		{
return (_dataStorageService.Contains(_levelDataKey) ? _dataStorageService.Get<PrimitiveData<int>>(_levelDataKey) : _dataStorageService.Create<PrimitiveData<int>>(_levelDataKey)).Value;


		}
            set
            {
                if (value <= _maxLevel)
                {
                    if (value == _maxLevel)
                    {
                        IsPassAllLevels = true;
                    }

                    (_dataStorageService.Contains(_levelDataKey) ? _dataStorageService.Get<PrimitiveData<int>>(_levelDataKey) : _dataStorageService.Create<PrimitiveData<int>>(_levelDataKey)).Value =
                        value;

                    if (value > HigherPassedLevel)
                    {
                        HigherPassedLevel = value;
                    }
                    
                    _dataStorageService.Save();
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int HigherPassedLevel
        {
            get {
var dat =  (_dataStorageService.Contains(_higherPassLevelDataKey)
                ? _dataStorageService.Get<PrimitiveData<int>>(_higherPassLevelDataKey)
                : _dataStorageService.Create<PrimitiveData<int>>(_higherPassLevelDataKey)).Value;
return dat > 2 ? dat : 2;  
}

            private set => _dataStorageService.Get<PrimitiveData<int>>(_higherPassLevelDataKey).Value = value;
        }

        public bool IsMaxLevel => CurrentLevel == _maxLevel;

        public bool IsPassAllLevels
        {
            get => (_dataStorageService.Contains(_isAllLevelsPassedDataKey)
                ? _dataStorageService.Get<PrimitiveData<bool>>(_isAllLevelsPassedDataKey)
                : _dataStorageService.Create<PrimitiveData<bool>>(_isAllLevelsPassedDataKey)).Value;
            private set
            {
                (_dataStorageService.Contains(_isAllLevelsPassedDataKey)
                    ? _dataStorageService.Get<PrimitiveData<bool>>(_isAllLevelsPassedDataKey)
                    : _dataStorageService.Create<PrimitiveData<bool>>(_isAllLevelsPassedDataKey)).Value = value;
            }
        }

        public void Finish()
        {
            Finishing?.Invoke();
            Finished?.Invoke();
        }

        public void FullProgress()
        {
            FullProgressed?.Invoke();
        }

        public void Start()
        {
            Started?.Invoke();
        }

        public void RequestLevel(int level)
        {
            LevelRequested?.Invoke(level);
        }

        public void ResetData()
        {
            CurrentLevel = 0;
            IsPassAllLevels = false;
            HigherPassedLevel = 0;
            _dataStorageService.Save();
        }
    }
}