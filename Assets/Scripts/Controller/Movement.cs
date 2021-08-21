using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Movement
{
    public float speed;
    [Range(0,10)]
    public float speedJump;

    public void CharacterMove(Transform transform,float frameTime)
    {
        transform.position += Vector3.forward*10* frameTime;
    }

   
}
