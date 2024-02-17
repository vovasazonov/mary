using UnityEngine;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Debug.View
{
    public class DebugButtonView : MonoBehaviour
    {
        private void Awake()
        {
#if UNITY_EDITOR
            gameObject.SetActive(true);
#else
            gameObject.SetActive(false);
#endif
        }
    }
}