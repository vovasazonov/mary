using System;
using UnityEngine;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.TenthMinigameDomain.Game
{
    public class FallObjectTreeView : MonoBehaviour
    {
        [SerializeField] private GameObject _sunGameObject;
        [SerializeField] private GameObject _tipaGameObject;
        
        public event Action Gotted;

        private bool _isSun;

        public bool IsSun
        {
            get => _isSun;
            set
            {
                _isSun = value;
                _sunGameObject.SetActive(_isSun);
                _tipaGameObject.SetActive(!_isSun);
            }
        }

        public void GotIt()
        {
            Gotted?.Invoke();
        }
    }
}