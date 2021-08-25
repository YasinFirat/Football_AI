using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Axis durumu belirtirlir.(Y_Axis se�ilirse y ekseni �zerinde random de�er verilir)
/// </summary>
public enum Axis
{
    [Tooltip("X ekseni �zerinde dizilir")]
    X_Axis,
    [Tooltip("Y ekseni �zerinde dizilir")]
    Y_Axis,
    [Tooltip("Z ekseni �zerinde dizilir")]
    Z_Axis,
    [Tooltip("3 boyutlu eksende dizilir")]
    nothing

}
/// <summary>
///  Bir alanda rastgele konum belirler.
/// </summary>
[System.Serializable]
public class PlaceRandomly
{
    [Tooltip("orgin noktas� (orta nokta olarak se�ilmeli)")]
    public Vector3 orgin;
   
    [Tooltip("Sapma durumuna kar�� (objelerin konumu orta noktalar�ndan referans al�nd���ndan dolay� birazc�k yukar� �ekmek isteyebilirsiniz :) )")]
    public Vector3 offset;
    [Tooltip("Uzunluk de�erleri( Plane �zerinde olu�turmak i�in plane scale de�erinin 10 kat�n� giriniz.)")]
    public float radius;
    [Tooltip("Hangi d�zlemde rastgele de�er �retilmesini istiyorsan�z o d�zlemi se�iniz.")]

    public Axis ignoreAxis;
    private Vector3 keepRandomPlace;
    private PlaceRandomly() { }
    public PlaceRandomly(Vector3 orgin, float radius, Vector3 offset, Axis ignoreAxis)
    {
        this.orgin = orgin;
        this.radius = radius;
        this.offset = offset;
        this.ignoreAxis = ignoreAxis;
    }
   
    /// <summary>
    /// E�er orgin ve scale de�eri girildiyse rastgele konum olu�turur.
    /// </summary>
    public Vector3 GetRandomPosition
    {
        get
        {
            Calculate();
            while (Vector3.Distance(keepRandomPlace,orgin+offset)>radius/2)
            {
                Calculate();
            }
                     
            return keepRandomPlace;
        }
    }
    /// <summary>
    /// E�er girilen de�er alan d���nda ise false d�nd�r�r.
    /// </summary>
    /// <returns></returns>
    public bool Over(Vector3 transformPosition)
    {
        return Vector3.Distance(transformPosition, orgin + offset) > radius / 2;
    }
    private void Calculate()
    {
        keepRandomPlace = new Vector3(GetRandom(orgin.x, radius), GetRandom(orgin.y, radius), GetRandom(orgin.z, radius));
        //istenilen d�zlemde da��l�m yap�labilir.
        switch (ignoreAxis)
        {
            case Axis.X_Axis:
                keepRandomPlace.x = orgin.x + offset.x;
                break;
            case Axis.Y_Axis:
                keepRandomPlace.y = orgin.y + offset.y;
                break;
            case Axis.Z_Axis:
                keepRandomPlace.z = orgin.z + offset.z;
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// �stenilen axis i�in random de�er �retir.
    /// </summary>
    /// <param name="orginAxis">��lem yapmak istedi�iniz eksenin orgin de�erini giriniz. �rn; x i�in orgin.x</param>
    /// <param name="scaleAxis">i�lem yapmak istedi�iniz eksenin scale de�erini giriniz.</param>
    /// <returns></returns>
    private float GetRandom(float orginAxis, float scaleAxis)
    {//Bir alan i�erisinde rastgele de�erler atanmas�n� istedi�inizde koordinat sisteminde
        // ba�lang�� noktas� ile uzunlu�un yar�s�n� toplaman�z veya ��karman�z yeterli olacakt�r.
        // 2.5 ile b�lme nedenim da��l�m�n tam s�n�r noktas�na eri�imini engellemektir.

        return Random.Range(orginAxis - scaleAxis / 2.5f, orginAxis + scaleAxis / 2.5f);
    }

}