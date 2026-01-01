using System.Diagnostics;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenUI : MonoBehaviour
{
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private Image spinner;
    [SerializeField] private Image spinnerImage;
    [SerializeField] private float rotationSpeed ; 
    void Start()
    {

    }
    void Update()
    {
       UpdateSpinner() ;  
    }
    public void UpdateSlider(float progress)
    {
        loadingSlider.value = progress ; 
    }
    public void UpdateSpinner()
    {
        spinner.transform.eulerAngles -= new UnityEngine.Vector3(0f,0f , Time.deltaTime * rotationSpeed) ;
    }
    public void SetUpUI(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
