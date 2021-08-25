using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootballAI
{
    [System.Serializable]
    public class PlayerStatues
    {
        [Header("Ka�an Karakter �zellikleri")]
        [Tooltip("Firari i�in collider")]
        public Material fugitive;
        public string fugitiveLayer;
        [Header("Kovalayan Karakter �zellikleri")]
        [Tooltip("Kovalayan i�in collider")]
        public Material chaser;
        public string chaserLayer;

        [Header("Topa sahiplik durumu")]
        [Space(50)]
        public bool haveBall;
        /// <summary>
        /// Duruma g�re material get edilir
        /// </summary>
        /// <returns></returns>
        public Material getMaterial
        {
            get
            {
                if (haveBall)
                {
                    return fugitive;
                }
                return chaser;
            }

        }
        /// <summary>
        /// Duruma g�re layer get eder.
        /// </summary>
        /// <returns></returns>
        public string getLayer
        {
            get
            {

                if (haveBall)
                {
                    return fugitiveLayer;
                }
                return chaserLayer;
            }

        }
        /// <summary>
        /// Her �a�r�ld���nda top tutma durumunu de�i�tirir.
        /// </summary>
        public PlayerStatues ChangeBallStatue()
        {
            haveBall = !haveBall;
            return this;
        }
        /// <summary>
        /// Top tutma durumunu de�i�tirir.
        /// </summary>
        /// <param name="haveBall"></param>
        public void ChangeBallStatue(bool haveBall)
        {
            this.haveBall = haveBall;
        }
    }

}
