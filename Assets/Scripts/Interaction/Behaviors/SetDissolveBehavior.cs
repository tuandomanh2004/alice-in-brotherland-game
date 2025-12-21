using System;
using System.Collections;
using NUnit.Framework.Internal;
using UnityEngine;

public class SetDissolveBehavior : MonoBehaviour
{
    [SerializeField] private Material dissolveMaterial;
    [SerializeField] private float dissolveStrength;
    [SerializeField] private float duration, delay ,  startValue = 0f, endValue = 1f;
    void Awake()
    {
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Reset();
    }
    public void ApplyDissolve()
    {
        Debug.Log("OK");
        StartCoroutine(Lerp(delay));
    }
    IEnumerator Lerp(float delay)
    {
        yield return new WaitForSeconds(delay);
        float timeElapse = 0f;
        while (timeElapse < duration)
        {
            dissolveStrength = Mathf.Lerp(startValue, endValue, timeElapse / duration);
            timeElapse += Time.deltaTime;
            dissolveMaterial.SetFloat("_DissolveStrength", dissolveStrength);
            // Debug.Log(dissolveStrength) ; 
            yield return null; // Đảm bảo mỗi vòng lặp chạy trong 1 frame
        }
        dissolveStrength = endValue;
        dissolveMaterial.SetFloat("_DissolveStrength", dissolveStrength);
    }
    void Reset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            dissolveMaterial.SetFloat("_DissolveStrength", startValue);
        }
    }
}
