using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Movement movement;
    public PlayerSettings playerSettings;
    public FindTargets findTargets;
    public Vector3 target;

    public bool isFollowEnemy;
    
    
    private void Start()
    {
        
        playerSettings = AIManager.Instance.playerSettings;
        movement.speed = playerSettings.speed;
        SearchNewTarget();
        transform.position = target;
       
    }

    private void Update()
    {

        if (findTargets.isFindTarget)
        {
            target = findTargets.GetClosestTarget().transform.position;
            findTargets.ClearDistance();
            return;
        }
        if (Vector3.Distance(transform.position, target) < 1)
        { //hedef noktaya ulaþttýðýnda ve düþman kovalamýyorsa deðiþir.
            SearchNewTarget();
        }
    }
    private void FixedUpdate()
    {
        movement.CharacterMove(transform,target,Time.fixedDeltaTime);
        transform.LookAt(target);
    }
    /// <summary>
    /// Hareket edecek hedef noktasý oluþturur.
    /// </summary>
    public void SearchNewTarget()
    {
        target = AIManager.Instance.placeRandomly.GetRandomPosition;
        transform.LookAt(target);
    }
   
}
