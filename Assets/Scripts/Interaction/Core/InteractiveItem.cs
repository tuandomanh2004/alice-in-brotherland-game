    using UnityEngine;

    public class InteractiveItem : MonoBehaviour
    {
        public bool isDetected = false;
       // public Tooltip itemTooltip ;
        public virtual void Interact()
        {

        }

        public virtual void ItemDetected(bool condition)
        {
            isDetected = condition;
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
