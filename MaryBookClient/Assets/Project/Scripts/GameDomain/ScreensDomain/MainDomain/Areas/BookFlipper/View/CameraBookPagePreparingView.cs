using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using UnityEngine;
using Zenject;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.BookFlipper.View
{
    public class CameraBookPagePreparingView : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        private IRuleModel _ruleModel;

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }

        private void OnEnable()
        {
            _ruleModel.Finishing += OnMinigameFinished;
        }

        private void OnDisable()
        {
            _ruleModel.Finishing -= OnMinigameFinished;
        }

        private void OnMinigameFinished()
        {
            BookView.Instance.SetFirstPage(RTImage());
        }

        private Texture2D RTImage()
        {
            var mWidth = Screen.width;
            var mHeight = Screen.height;
            Rect rect = new Rect(0, 0, mWidth, mHeight);
            RenderTexture renderTexture = new RenderTexture(mWidth, mHeight, 24);
            Texture2D screenShot = new Texture2D(mWidth, mHeight, TextureFormat.RGBA32, false);

            _camera.targetTexture = renderTexture;
            _camera.Render();

            RenderTexture.active = renderTexture;
            screenShot.ReadPixels(rect, 0, 0);
            screenShot.Apply();
            _camera.targetTexture = null;
            RenderTexture.active = null;

            Destroy(renderTexture);

            return screenShot;
        }
    }
}