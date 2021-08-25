using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace FootballAI
{
    /// <summary>
    /// Ýki farklý grup temas ederse yapýlacaklar burada belirlenir.
    /// </summary>
    public class AttackDedector : MonoBehaviour
    {
        [SerializeField]private string tagOfAttackTrigger = "Attack";
        [SerializeField]private UnityEvent onEnter;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(tagOfAttackTrigger))
            {
                other.transform.SetParent(transform);
               // onEnter?.Invoke();
            }
        }
    }

}
