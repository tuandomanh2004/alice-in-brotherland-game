using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TeleportBehavior : MonoBehaviour
{
    [SerializeField] private string mapName;
    [SerializeField] private float effectSpeed, effectScale, delay, duration, startValue, endValue;
    [SerializeField] private BoxCollider objectBox;
    [SerializeField] private Material portalEffect;
    [SerializeField] private GameObject teleport;
    void Awake()
    {
        objectBox = GetComponent<BoxCollider>();
        //  portalEffect = GetComponent<Material>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OpenTeleport()
    {
        teleport.SetActive(true);

        StartCoroutine(Lerp(delay));
        objectBox.isTrigger = true;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CloseTeleport();
            MANAGER.Instance.sceneManager.LoadScene(mapName);
        }
    }
    public void CloseTeleport()
    {
        objectBox.isTrigger = false;
        teleport.SetActive(false);
    }
    IEnumerator Lerp(float delay)
    {
        portalEffect.SetFloat("_Scale", effectScale);
        yield return new WaitForSeconds(delay);
        var timeElapse = 0f;
        while (timeElapse < duration)
        {
            effectScale = Mathf.Lerp(startValue, endValue, timeElapse / duration);
            timeElapse += Time.deltaTime;
            portalEffect.SetFloat("_Scale", effectScale);
            yield return null;
        }
        effectScale = endValue;
        portalEffect.SetFloat("_Scale", effectScale);
        portalEffect.SetFloat("_Speed", effectSpeed);
    }
}
