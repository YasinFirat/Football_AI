using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Ýstenilen hedefi bulur.
public class FindTargets : MonoBehaviour
{
    
   
    private List<float> distances;
    private float keep;
    private int keepId = 0;
    public List<Player> players;
    [Header("Events")]
    [Tooltip("Trigger enter olduðunda tetiklenir.")]
    public UnityEvent whenEnter;
    [Tooltip("Trigger exit olduðunda tetiklenir.")]
    public UnityEvent whenExit;

    private void OnEnable()
    {
        whenEnter.AddListener(CheckTargets);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        players.Add(other.GetComponent<Player>());
        whenExit?.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        players.Remove(other.GetComponent<Player>());
        whenExit?.Invoke();
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


}
