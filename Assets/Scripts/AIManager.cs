using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerSettings
{
    [Tooltip("Oyuncularýn Hýzlarý")]
    [Range(0,20)]
    public float speed;
   
    [Tooltip("Oyuncunun dönme hýzý")]
    [Range(0, 20)]
    public float turnSpeed;

    [Tooltip("Eðer bir topa/nesneye sahip ise true döndürür")]
    public bool haveBall;
    
   
}
public class AIManager : MonoBehaviour
{
    public static AIManager Instance { get; private set; }

    public PlaceRandomly placeRandomly;
    [Space(10)]
    [Header("\t\t\t PLAYER SETTINGS")]
    public PlayerSettings playerSettings;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
}
