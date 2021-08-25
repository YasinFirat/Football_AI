using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Movement movement;
    public PlayerStatues playerStatues;
    public PlayerSettings playerSettings;
    
    public FindTargets findTargets;
    public Vector3 target;

    public bool isFollowEnemy;
    public Player enemy;
    
    private MeshRenderer meshRenderer;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>(); 
   
        movement = AIManager.Instance.movement;
        SearchNewTarget();
        transform.position = target;
        ChangeStatues();
        
    }
    public void ChangeStatues()
    {
        Debug.Log("CHANGESTATUES");
        playerStatues.ChangeBallStatue();
        if (playerStatues.haveBall)
        {
            movement.StartTurbo();
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.layer= LayerMask.NameToLayer(playerStatues.getLayer);
        }
       
        meshRenderer.material = playerStatues.getMaterial;
    }
    private void Update()
    {
        movement.CheckTurbo(Time.deltaTime);
        if (findTargets.isFindTarget)
        {//d��man tespit edildiyse
            enemy = findTargets.GetClosestTarget();
            if (enemy.playerStatues.haveBall&&!playerStatues.haveBall)
            {//d��manda top varsa ve sende yoksa kovala.
                target = enemy.transform.position;
                return;
            }else if (!enemy.playerStatues.haveBall && playerStatues.haveBall&&!isFollowEnemy)
            {//d��manda top yoksa ve sende top varsa ka�
                SearchNewTarget();
                isFollowEnemy = true;
                return;
            }
           
        }
        if (Vector3.Distance(transform.position, target) < 1||AIManager.Instance.placeRandomly.Over(transform.position))
        { //hedef noktaya ula�tt���nda ve alan d���nda ise
            SearchNewTarget();
        }
    }
    private void FixedUpdate()
    {
        movement.CharacterMove(transform,target,Time.fixedDeltaTime);
        transform.LookAt(target);
    }
    /// <summary>
    /// Hareket edecek hedef noktas� olu�turur.
    /// </summary>
    public void SearchNewTarget()
    {
        target = AIManager.Instance.placeRandomly.GetRandomPosition;
        transform.LookAt(target);
    }
   
}
