using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FootballAI
{
    [System.Serializable]
    public struct Movement
    {
        [Range(0, 20)]
        public float speed;
        public Turbo turbo;

        public void CharacterMove(Transform transform, Vector3 target, float frameTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, SpeedWithTurbo * frameTime);
        }

        #region Turbo
        
        private float SpeedWithTurbo
        {
            get
            {
                return speed + turbo.keepSpeed;
            }
        }
        /// <summary>
        /// E�er turbo calisiyorsa true d�nd�r.
        /// </summary>
        
        #endregion
    }

    [System.Serializable]
    public struct Turbo
    {
        [Range(1, 10)]
        public float speed;
        public float keepSpeed;
        #region Turbo
        /// <summary>
        /// Turbo ba�lat�r.
        /// </summary>
        /// <returns></returns>
        public Turbo StartTurbo()
        {
            keepSpeed = speed;
            return this;
        }
        /// <summary>
        /// Turbo durumunu kontrol eder.
        /// </summary>
        /// <param name="frameTime">saniye ba�� frame say�s�</param>
        /// <returns></returns>
        public Turbo CheckTurbo(float frameTime)
        {
            keepSpeed -= frameTime;
            if (isWorkingTurbo)
            {
                return this;
            }
            keepSpeed = 0;
            return this;
        }
        private float SpeedWithTurbo
        {
            get
            {
                return speed + keepSpeed;
            }
        }
        /// <summary>
        /// E�er turbo calisiyorsa true d�nd�r.
        /// </summary>
        public bool isWorkingTurbo
        {
            get
            {
                return keepSpeed > 0;
            }
        }
        #endregion
    }
}

