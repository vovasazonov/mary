using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Rule.Presenter;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Dialog.View
{
    public class DialogView : MonoBehaviour, IDialogView, IPointerClickHandler
    {
        [SerializeField] private List<DialogByLevel> _dialogs;
        [SerializeField] private Image _heroImage;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _letterAppearSeconds;
        [SerializeField] private GameObject _nextText;
        private int _currentIndexDialog;
        private DialogByLevel _currentDialog;
        private IRuleModel _ruleModel;
        private UniTask _textTask;
        private Coroutine _textCoroutine;
        
        public static IDialogView Instance { get; private set; }

        public bool IsActive { get; private set; }

        private void Awake()
        {
            Instance = this;
            Hide();
        }

        [Inject]
        private void Constructor(IRuleModel ruleModel)
        {
            _ruleModel = ruleModel;
        }

        public void Show()
        {
            _currentDialog = _dialogs.Find(i => i.LevelId == _ruleModel.CurrentLevel);
            _currentIndexDialog = -1;
            IsActive = true;
            gameObject.SetActive(true);
            Next();
        }

        public void Hide()
        {
            if (_textCoroutine != null)
            {
                StopCoroutine(_textCoroutine);
                _textCoroutine = null;
            }
            IsActive = false;
            gameObject.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Next();
        }

        private void Next()
        {
            _nextText.SetActive(false);
            
            if (_textCoroutine != null)
            {
                StopCoroutine(_textCoroutine);
                _textCoroutine = null;
            }
            
            _currentIndexDialog++;
            if (_currentDialog.Parts.Count > _currentIndexDialog)
            {
                var part = _currentDialog.Parts[_currentIndexDialog];
                _heroImage.sprite = part.HeroSprite;
                _textCoroutine = StartCoroutine(WatchText());
            }
            else
            {
                Hide();
            }
        }

        private IEnumerator WatchText()
        {
            var part = _currentDialog.Parts[_currentIndexDialog];
            _text.text = "";
            int currentIndex = 0;

            while (currentIndex < part.Text.Length)
            {
                _text.text = part.Text.Substring(0, currentIndex + 1);
                currentIndex++;
                yield return new WaitForSeconds(_letterAppearSeconds);
            }
            
            _nextText.SetActive(true);
        }
        
        [Serializable]
        private struct DialogByLevel
        {
            public int LevelId;
            public List<PartDialog> Parts;
            
            [Serializable]
            public struct PartDialog
            {
                public Sprite HeroSprite;
                public string Text;
            }
        }
    }
}