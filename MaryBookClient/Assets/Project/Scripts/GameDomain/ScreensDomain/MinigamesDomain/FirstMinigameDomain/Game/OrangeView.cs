using UnityEngine;

namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FirstMinigameDomain.Game
{
    public class OrangeView : MonoBehaviour
    {
        [SerializeField] private Animator _orangeAnimator;
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            var tuci = other.gameObject.GetComponent<TuciFlyView>();
            if (tuci != null)
            {
                tuci.SetOrangeParent(this);
                _orangeAnimator.Play("OrangeCatchedByTuci");
            }
        }
    }
}