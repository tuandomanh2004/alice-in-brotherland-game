using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMNG : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreenUI;
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
        var uiController = loadingScreenUI.GetComponent<LoadingScreenUI>();
        loadingScreenUI.SetActive(true);
        StartCoroutine(LoadSceneAsync(sceneName, uiController));
    }
    IEnumerator LoadSceneAsync(string sceneName, LoadingScreenUI screenUI)
    {
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
        loadingScreenUI.SetActive(false);
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
