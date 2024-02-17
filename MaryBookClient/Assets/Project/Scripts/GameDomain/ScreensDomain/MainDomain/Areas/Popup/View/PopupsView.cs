using System;
using System.Collections.Generic;
using Project.CoreDomain.Services.Engine;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Popup.View
{
    public class PopupsView : MonoBehaviour, IPopupsView
    {
        [SerializeField] private List<PopupView> _popups;

        public PopupsView(IEngineService engineService)
        {
            engineService.Updating += () =>
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    CloseAll();
                }
            };
        }

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Open(string id)
        {
            gameObject.SetActive(true);
            
            foreach (var popup in _popups)
            {
                if (popup.Id == id)
                {
                    popup.Open();
                }
                else
                {
                    popup.Close();
                }
            }
        }

        public void CloseAll()
        {
            gameObject.SetActive(false);

            foreach (var popup in _popups)
            {
                popup.Close();
            }
        }
    }
}