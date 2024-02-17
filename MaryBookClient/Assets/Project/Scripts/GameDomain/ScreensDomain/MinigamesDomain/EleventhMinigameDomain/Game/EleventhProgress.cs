namespace Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EleventhMinigameDomain.Game
{
    public class EleventhProgress
    {
        private int _progress;
        
        public int Progress
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
        
        public int MaxProgress { get; set; }
    }
}