using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FootballAI
{
   
    //Ýstenilen hedefi bulur.
    public class FindTargets : MonoBehaviour
    {
        private List<float> distances = new List<float>();
        private float keep;
        private int keepId = 0;
       
        public List<Player> players;
        public List<Ball> balls;
        private Ball ball;
        private int ballId;
        private Player player;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                ball = other.GetComponent<Ball>();
                if (!balls.Contains(ball))
                {
                    balls.Add(ball);
                }
                return;
            }
              
           
            player = other.GetComponentInParent<Player>();
            if (!players.Contains(player))
            {
                players.Add(player);
            }
           
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                balls.Remove(other.GetComponent<Ball>());
                return;
            }
            players.Remove(other.GetComponentInParent<Player>());

          
        }
        public bool isFindBall
        {
            get
            {
                for (int i = 0; i < balls.Count; i++)
                {
                    if (balls[i].firstCreate)
                    {
                        ballId = i;
                        return true;
                    }
                }
                balls = new List<Ball>();
                return false;
            }
        }
        public Ball GetBall()
        {
            return balls[ballId];
        }

        /// <summary>
        /// Hedef bulundu mu? 
        /// </summary>
        public bool isFindTarget
        {
            get
            {
                return getTotalTarget > 0;
            }
        }
        /// <summary>
        /// Toplam bulunan hedef sayýsýný döndürür.
        /// </summary>
        public int getTotalTarget
        {
            get
            {
                return players.Count;
            }
        }
        public void CheckTargets()
        {
            if (!isFindTarget)
                return;
            GetClosestTarget();
        }
        /// <summary>
        /// En yakýn hedefi tespit eder.
        /// </summary>
        /// <returns></returns>
        public Player GetClosestTarget()
        {
            ClearDistance();
            for (int i = 0; i < players.Count; i++)
            {
                distances.Add(Vector3.Distance(transform.position, players[i].transform.position));
            }
            keepId = 0;
            keep = distances[0];
            for (int i = 0; i < distances.Count; i++)
            {
                if (distances[i] < keep)
                {
                    keep = distances[i];
                    keepId = i;
                }
            }
            return players[keepId];
        }
        public void ClearDistance()
        {
            distances = new List<float>();
        }
        public void ClearAllData()
        {
            ClearDistance();
            
        }
    }

}
