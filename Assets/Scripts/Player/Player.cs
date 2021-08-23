using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Movement movement;
    public Turn turn;
    public FindTargets findTargets;
    public Vector3 target;
    private PlayerSettings playerSettings;
    
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
        if (Vector3.Distance(transform.position, target) < 1)
        {
            SearchNewTarget();
        }
    }
    private void FixedUpdate()
    {
        movement.CharacterMove(transform,target,Time.fixedDeltaTime);
        if (!playerSettings.haveBall)
        {
            
        }
        
    }

    public void SearchNewTarget()
    {
        target = AIManager.Instance.placeRandomly.GetRandomPosition;
        transform.LookAt(target);
    }

}
