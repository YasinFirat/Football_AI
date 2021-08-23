using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Movement movement;
    public Turn turn;
    public FindTargets findTargets;
    public Vector3 target;
    public PlayerSettings playerSettings;
    
    private void Start()
    {
        
        target = AIManager.Instance.placeRandomly.GetRandomPosition;
        playerSettings = AIManager.Instance.playerSettings;
        movement.speed = playerSettings.speed;
        transform.LookAt(target);
        transform.position = target;
       
    }

    private void Update()
    {
        if (findTargets.isFindTarget)
        {//hedef bulunduysa
            if (findTargets.GetClosestTarget().playerSettings.haveBall)
            { //en yakýn hedef topa sahip ise
                if (!playerSettings.haveBall)
                {//sen topa sahip deðilsen
                    Debug.Log("Hedefe odaklan ve Kovala");
                    target = findTargets.GetClosestTarget().transform.position;
                    return;
                }
            }
            else
            { // en yakýn hedef topa sahip deðilse
                if (playerSettings.haveBall)
                {//sen topa sahipsen
                    Debug.Log("Hedefe odaklan ve kaç");
                    SearchNewTarget();
                    return;
                }
            }
            
        }
        if (Vector3.Distance(transform.position, target) < 1)
        {
            SearchNewTarget();
        }
    }
    private void FixedUpdate()
    {
        movement.CharacterMove(transform,target,Time.fixedDeltaTime);
      
        
    }

    public void SearchNewTarget()
    {
        target = AIManager.Instance.placeRandomly.GetRandomPosition;
        transform.LookAt(target);
    }

}
