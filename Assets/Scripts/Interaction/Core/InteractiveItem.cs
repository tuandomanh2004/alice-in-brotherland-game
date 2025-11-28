    using UnityEngine;

    public class InteractiveItem : MonoBehaviour
    {
        public bool isDetected = false;
        public virtual void Interact()
        {

        }

        public virtual void ItemDetected(bool condition)
        {
            isDetected = condition;
        }
        void Start()
        {
            
        }
        void Update()
        {

        }
    }
