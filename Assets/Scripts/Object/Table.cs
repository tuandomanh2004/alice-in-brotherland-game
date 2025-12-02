using NUnit.Framework;
using TMPro;
using Unity.Cinemachine;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class Table : InteractionManager
{
    [SerializeField] private CameraSwitcher camSW;
    //  [SerializeField] private UnityEvent onInteraction; 
    [SerializeField] private bool isFocused = false;
    [SerializeField] private TextMeshProUGUI interactionUI;
    public override void Start()
    {
        //   onInteraction.Invoke();
        outline = GameObject.Find("Table").GetComponent<OutlineBehavior>();
        interactionUI.text = "Press [E] to interact" ;
    }

    void Update()
    {

    }
    public override void Interact() // Xử lí tương tác
    {
        isFocused = !isFocused;
    }
    public override void SetInteractPrompt() // Bật-tắt UI
    {
        if(!isFocused) // Chỉ hiển thị UI ở góc nhìn thứ 3
        {
            interactionUI.enabled = isDetected;
        }
        else
        {
            interactionUI.enabled = !isDetected;
        }
    }
}





