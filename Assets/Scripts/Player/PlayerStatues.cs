using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FootballAI
{
    [System.Serializable]
    public class PlayerStatues
    {
        [Header("Kaçan Karakter Özellikleri")]
        [Tooltip("Firari için collider")]
        public Material fugitive;
        public string fugitiveLayer;
        [Header("Kovalayan Karakter Özellikleri")]
        [Tooltip("Kovalayan için collider")]
        public Material chaser;
        public string chaserLayer;

        [Header("Topa sahiplik durumu")]
        [Space(50)]
        public bool haveBall;
        /// <summary>
        /// Duruma göre material get edilir
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
        /// Duruma göre layer get eder.
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
        /// Her çaðrýldýðýnda top tutma durumunu deðiþtirir.
        /// </summary>
        public PlayerStatues ChangeBallStatue()
        {
            haveBall = !haveBall;
            return this;
        }
        /// <summary>
        /// Top tutma durumunu deðiþtirir.
        /// </summary>
        /// <param name="haveBall"></param>
        public void ChangeBallStatue(bool haveBall)
        {
            this.haveBall = haveBall;
        }
    }

}
