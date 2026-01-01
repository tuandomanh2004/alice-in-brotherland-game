using System.Collections;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMNG : MonoBehaviour
{
    [SerializeField] private LoadingScreenUI loadingScreenUI;
    [SerializeField] private SceneTransition sceneTransition ; 
    [SerializeField] private float delayBetweenScenes;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadScene(string sceneName)
    {
        sceneTransition.SetUpTransitionUI(true) ;
        StartCoroutine(LoadSceneAsync(sceneName, loadingScreenUI));
    }
    IEnumerator LoadSceneAsync(string sceneName, LoadingScreenUI screenUI)
    { 
        yield return StartCoroutine(sceneTransition.Fade(true)) ; // Fade out 
        loadingScreenUI.SetUpUI(true) ; //  Bật Loading screen
        AsyncOperation sceneOperation = SceneManager.LoadSceneAsync(sceneName);
        sceneOperation.allowSceneActivation = false;
        while (sceneOperation.progress < 0.9f)
        {
            //Debug.Log($" Loading Progress : {sceneOperation.progress * 100}%");
            float lerpProgress = Mathf.Clamp01(sceneOperation.progress / 0.9f); // Chuẩn hóa thanh giá trị load tiến trình trong phạm vi [0;1]
            screenUI.UpdateSlider(lerpProgress);
            yield return null;
        }
        screenUI.UpdateSlider(1f); // full-fill progress bar
        yield return new WaitForSeconds(delayBetweenScenes);
        sceneOperation.allowSceneActivation = true;
        loadingScreenUI.SetUpUI(false) ;
        StartCoroutine(sceneTransition.Fade(false)) ;  
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene sceneName, LoadSceneMode loadMode)
    {
        MANAGER.Instance.spawnManager.SpawnPlayer(sceneName.name);
        MANAGER.Instance.camManager.InitializeCameras();
    }
}
