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
        // Bắt đầu fade out
        yield return StartCoroutine(sceneTransition.Fade(true)) ;

        // Set up Loading screen
        loadingScreenUI.SetUpUI(true) ; 
        AsyncOperation sceneOperation = SceneManager.LoadSceneAsync(sceneName);
        sceneOperation.allowSceneActivation = false;

        // Chạy loading và update thanh tiến trình 
        while (sceneOperation.progress < 0.9f)
        {
            //Debug.Log($" Loading Progress : {sceneOperation.progress * 100}%");
            float lerpProgress = Mathf.Clamp01(sceneOperation.progress / 0.9f); // Chuẩn hóa thanh giá trị load tiến trình trong phạm vi [0;1]
            screenUI.UpdateSlider(lerpProgress);
            yield return null;
        }
        // Load data thành công và thực hiện chuyển scene
        screenUI.UpdateSlider(1f); 
        yield return new WaitForSeconds(delayBetweenScenes);
        sceneOperation.allowSceneActivation = true;
        loadingScreenUI.SetUpUI(false) ;
        StartCoroutine(sceneTransition.Fade(false)) ; // Fade in sau khi load scene mới
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
