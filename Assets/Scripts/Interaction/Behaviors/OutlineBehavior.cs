using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.SpeedTree.Importer;
using UnityEngine;

public class OutlineBehavior : MonoBehaviour, IInteractable
{
    [SerializeField] public Material[][] mats;
    [SerializeField] private List<Renderer>  rend;
    [SerializeField] private float outlineIntensity;
    [SerializeField] private int outlineIndex = 1;
    void Start()
    {
        InitializeRend() ; 
        mats = new Material[rend.Count][];
        InitializeMats();
       // SetOutline(true);
    }

    void Update()
    {

    }
    public void SetOutline(bool isOutline)
    {
        if (isOutline)
        {
            TurnOnOutline();
        }
        else
        {
            TurnOffOutline();
        }
    }
    private void InitializeRend()
    {
        rend = GetComponentsInChildren<Renderer>().ToList() ;
    }
    private void InitializeMats()
    {
        for (int i = 0; i < rend.Count; i++)
        {
            mats[i] = rend[i].materials;
        }
    }
    private void TurnOnOutline()
    {
        for (int i = 0; i < rend.Count; i++)
        {
            mats[i][outlineIndex].SetFloat("_OutlineScale", outlineIntensity);
        }
    }
    private void TurnOffOutline()
    {
        for (int i = 0; i < rend.Count; i++)
        {
            mats[i][outlineIndex].SetFloat("_OutlineScale", 0f);
        }
    }

    public void HoverEnter()
    {
        TurnOnOutline();
    }

    public void HoverExit()
    {
        TurnOffOutline();
    }
}
