using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using Zenject;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Debug.View
{
    public class DebugPopupView : MonoBehaviour
    {
        private IRuleModel _ruleModel;

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }

        public void FinishMinigame(int level)
        {
            _ruleModel.CurrentLevel = level;
            _ruleModel.Finish();
        }
    }
}