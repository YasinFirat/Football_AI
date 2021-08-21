using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerSettings
{
    public int PlayerId;
   
}
public class AIManager : MonoBehaviour
{
    public static AIManager Instance { get; private set; }

    public PlaceRandomly placeRandomly;
    
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
