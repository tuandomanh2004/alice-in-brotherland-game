using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMNG : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName , LoadSceneMode.Single);
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded ; 
    }
    void OnSceneLoaded(Scene sceneName, LoadSceneMode loadMode)
    {
        MANAGER.Instance.spawnManager.SpawnPlayer(sceneName.name) ; 
        MANAGER.Instance.camManager.InitializeCameras() ; 
    }
}
