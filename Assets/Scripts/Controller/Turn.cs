using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct Turn
{
    public float speedTurn;

    public void CharacterTurn(Transform transform)
    {
        Debug.Log("Karakter Döner");
    }
}
