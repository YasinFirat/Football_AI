using UnityEngine;


namespace FootballAI
{
    public class AIManager : MonoBehaviour
    {
        public static AIManager Instance { get; private set; }
        [Header("Random Create Points")]
        [Tooltip("Rastgele bir alanda konum belirler.")]
        public PlaceRandomly placeRandomly;

        [Header("PLAYER SETTINGS")]
        public Movement movement;
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }
    }
}

