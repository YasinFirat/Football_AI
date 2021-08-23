using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerSettings
{
    [Tooltip("Oyuncular�n H�zlar�")]
    [Range(0,20)]
    public float speed;
   
    [Tooltip("Oyuncunun d�nme h�z�")]
    [Range(0, 20)]
    public float turnSpeed;

    [Tooltip("E�er bir topa/nesneye sahip ise true d�nd�r�r")]
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
