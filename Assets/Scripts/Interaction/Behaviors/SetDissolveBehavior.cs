using System;
using System.Collections;
using NUnit.Framework.Internal;
using UnityEngine;

public class SetDissolveBehavior : MonoBehaviour
{
    [SerializeField] private Material dissolveMaterial;
    [SerializeField] private float dissolveStrength ;
    [SerializeField] private float duration , startValue = 0f , endValue = 1f ;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    public void Dissolve()
    {
        StartCoroutine(Lerp()) ;
    }
    IEnumerator Lerp()
    {
        float timeElapse = 0f ; 
        while(timeElapse < duration)
        {
            dissolveStrength = Mathf.Lerp(startValue,endValue,timeElapse/duration) ;
            timeElapse += Time.deltaTime ;
            dissolveMaterial.SetFloat("_DissolveStrength",dissolveStrength) ; 
            Debug.Log(dissolveStrength) ; 
            yield return null ; // Đảm bảo mỗi vòng lặp chạy trong 1 frame
        }
        dissolveStrength = endValue ;
        dissolveMaterial.SetFloat("_DissolveStrength",dissolveStrength) ; 
    }
}
