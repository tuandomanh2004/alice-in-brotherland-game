using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Image fade ;
    [SerializeField] private float fadeDuration ;
    [SerializeField] 
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void SetUpTransitionUI(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
    public IEnumerator Fade(bool isFadeOut)
    { 
        float timer = 0f , fadeAlpha ;
            while(timer < fadeDuration)
            {
                fadeAlpha = isFadeOut ? Mathf.Lerp(0 , 1 , timer/fadeDuration) : Mathf.Lerp(1 , 0 , timer/fadeDuration) ; // Tính alpha dựa theo fade in/out 
                timer += Time.deltaTime ;
                fade.color = new Color( 0 , 0 , 0 , fadeAlpha) ; 
                Debug.Log(fadeAlpha) ; 
                yield return null ;
            } 
        fadeAlpha = isFadeOut ? 1f : 0f ; 
        fade.color = new Color(0 , 0 , 0 ,fadeAlpha ) ;       
    }
}
