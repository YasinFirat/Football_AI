using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Movement movement;
    public Turn turn;

    private void Start()
    {
        transform.position = AIManager.Instance.placeRandomly.GetRandomPosition;
    }


}
