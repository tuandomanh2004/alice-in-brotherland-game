using Unity.VisualScripting;
using UnityEditor.SpeedTree.Importer;
using UnityEngine;

public class OutlineBehavior : MonoBehaviour
{
    [SerializeField]public Material[][] mats;
    [SerializeField] private Renderer[] rend;
    [SerializeField] private float outlineIntensity;
    [SerializeField] private Material OutlineMat ; 
    //[SerializeField] private bool isOutline = false ; 
    void Start()
    {
        rend = GetComponentsInChildren<Renderer>();
        mats = new Material[rend.Length][] ; 
        InitializeMats();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetOutline(bool isOutline)
    {
        if (isOutline)
        {
            TurnOnOutline() ; 
        }
        else
        {
            TurnOffOutline() ; 
        }
    }
    private void InitializeMats()
    {
        for (int i = 0; i < rend.Length; i++)
        {
            mats[i] = rend[i].materials;
        }
    }
    private void TurnOnOutline()
    {
        for (int i = 0; i < rend.Length; i++)
        {
            mats[i][1].SetFloat("_OutlineScale" , outlineIntensity) ; 
        }
    }
    private void TurnOffOutline() 
    {
        for (int i = 0; i < rend.Length; i++)
        {
            mats[i][1].SetFloat("_OutlineScale" ,0f) ; 
        }
        }
    } 
