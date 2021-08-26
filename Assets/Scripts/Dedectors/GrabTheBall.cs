using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace FootballAI
{
    /// <summary>
    /// Topu alacak script
    /// </summary>
    public class GrabTheBall : MonoBehaviour
    {
        [SerializeField]private string tagOfAttackTrigger = "Attack";
        [SerializeField]private UnityEvent onEnter;

        /// <summary>
        /// Topa sahiplik durumu
        /// </summary>
        public bool haveBall
        {
            get
            {
                return transform.childCount > 0;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(tagOfAttackTrigger))
            {
                if (haveBall)//child dolu ise top  vardýr.
                    return;
                other.GetComponent<Ball>().firstCreate = false;
                other.transform.SetParent(transform);
                onEnter?.Invoke();
            }
        }
    }

}
