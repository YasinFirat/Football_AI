using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Axis durumu belirtirlir.(Y_Axis seçilirse y ekseni üzerinde random deðer verilir)
/// </summary>
public enum Axis
{
    [Tooltip("X ekseni üzerinde dizilir")]
    X_Axis,
    [Tooltip("Y ekseni üzerinde dizilir")]
    Y_Axis,
    [Tooltip("Z ekseni üzerinde dizilir")]
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
    [Tooltip("orgin noktasý (orta nokta olarak seçilmeli)")]
    public Vector3 orgin;
    [Tooltip("Uzunluk deðerleri( Plane üzerinde oluþturmak için plane scale deðerinin 10 katýný giriniz.)")]
    public Vector3 scale;
    [Tooltip("Sapma durumuna karþý (objelerin konumu orta noktalarýndan referans alýndýðýndan dolayý birazcýk yukarý çekmek isteyebilirsiniz :) )")]
    public Vector3 offset;
    [Tooltip("Hangi düzlemde rastgele deðer üretilmesini istiyorsanýz o düzlemi seçiniz.")]
    public Axis ignoreAxis;
    private Vector3 keepRandomPlace;
    private PlaceRandomly() { }
    public PlaceRandomly(Vector3 orgin, Vector3 scale, Vector3 offset, Axis ignoreAxis)
    {
        this.orgin = orgin;
        this.scale = scale;
        this.offset = offset;
        this.ignoreAxis = ignoreAxis;
    }
    public PlaceRandomly(Transform _transform, Vector3 offset, Axis ignoreAxis)
    {
        this.orgin = _transform.position;
        this.scale = _transform.localScale;
        this.offset = offset;
        this.ignoreAxis = ignoreAxis;
    }
    /// <summary>
    /// Eðer orgin ve scale deðeri girildiyse rastgele konum oluþturur.
    /// </summary>
    public Vector3 GetRandomPosition
    {
        get
        {
            Calculate();
            while (Vector3.Distance(keepRandomPlace,orgin+offset)>scale.x/2)
            {
                Calculate();
            }
            Debug.Log("Distanceee : "+ Vector3.Distance(keepRandomPlace, new Vector3(scale.x,0,0)));
            
            return keepRandomPlace;
        }
    }

    private void Calculate()
    {
        keepRandomPlace = new Vector3(GetRandom(orgin.x, scale.x), GetRandom(orgin.y, scale.y), GetRandom(orgin.z, scale.z));
        //istenilen düzlemde daðýlým yapýlabilir.
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
    /// Ýstenilen axis için random deðer üretir.
    /// </summary>
    /// <param name="orginAxis">Ýþlem yapmak istediðiniz eksenin orgin deðerini giriniz. örn; x için orgin.x</param>
    /// <param name="scaleAxis">iþlem yapmak istediðiniz eksenin scale deðerini giriniz.</param>
    /// <returns></returns>
    private float GetRandom(float orginAxis, float scaleAxis)
    {//Bir alan içerisinde rastgele deðerler atanmasýný istediðinizde koordinat sisteminde
        // baþlangýç noktasý ile uzunluðun yarýsýný toplamanýz veya çýkarmanýz yeterli olacaktýr.
        // 2.5 ile bölme nedenim daðýlýmýn tam sýnýr noktasýna eriþimini engellemektir.

        return Random.Range(orginAxis - scaleAxis / 2.5f, orginAxis + scaleAxis / 2.5f);
    }

}