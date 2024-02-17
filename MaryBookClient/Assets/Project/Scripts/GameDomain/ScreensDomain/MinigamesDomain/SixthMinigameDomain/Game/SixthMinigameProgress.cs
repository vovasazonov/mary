namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SixthMinigameDomain.Game
{
    public class SixthMinigameProgress
    {
        private float _progress;
        
        public float Progress
        {
            get => _progress;
            set
            {
                if (value < 0)
                {
                    _progress = 0;
                }
                else
                {
                    _progress = value;
                }
            }
        }
    }
}