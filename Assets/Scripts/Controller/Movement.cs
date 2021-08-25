using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Movement
{
    [Range(0,20)]
    public float speed;
    [Range(1, 10)]
    public float turboSpeed;
    private float keepTurboSpeed;

    public void CharacterMove(Transform transform,Vector3 target,float frameTime)
    {
        transform.position= Vector3.MoveTowards(transform.position,target,SpeedWithTurbo*frameTime);
    }

    #region Turbo
    /// <summary>
    /// Turbo baþlatýr.
    /// </summary>
    /// <returns></returns>
    public Movement StartTurbo()
    {
        keepTurboSpeed = turboSpeed;
        return this;
    }
    /// <summary>
    /// Turbo durumunu kontrol eder.
    /// </summary>
    /// <param name="frameTime">saniye baþý frame sayýsý</param>
    /// <returns></returns>
    public Movement CheckTurbo(float frameTime)
    {
        keepTurboSpeed -= frameTime;
        if (keepTurboSpeed <= 0)
        {
            keepTurboSpeed = 0;
            return this;
        }
        
        return this;
    }
   private float SpeedWithTurbo
    {
        get
        {
            return speed + keepTurboSpeed;
        }
    }
    #endregion
}
