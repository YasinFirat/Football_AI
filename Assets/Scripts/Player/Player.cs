using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Movement movement;
    public Turn turn;
    public Vector3 target;

    private void Start()
    {
        target = AIManager.Instance.placeRandomly.GetRandomPosition;
        transform.position = target;
        transform.LookAt(target);
    }

    private void FixedUpdate()
    {
        movement.CharacterMove(transform,target,Time.fixedDeltaTime);
        if (Vector3.Distance(transform.position, target) < 1)
        {
            target = AIManager.Instance.placeRandomly.GetRandomPosition;
            transform.LookAt(target);
        }
    }

}
