using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using Unity.VisualScripting;
using System.Data.Common;
using UnityEngine.SceneManagement;
public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private SpawnBasedScene[] spawnDataContainer;
    [SerializeField] private Dictionary<string, SpawnObjectData> spawner;
    public static SpawnManager Instance { get; private set; }
    void Awake()
    {
        spawner = new Dictionary<string, SpawnObjectData>();
        InitializeDictionary();
    }
    void OnEnable()
    {

    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void InitializeDictionary()
    {
        foreach (var spawnData in spawnDataContainer)
        {
            Debug.Log(spawnData.sceneName);
            Debug.Log(spawnData.objectData);
            spawner.Add(spawnData.sceneName, spawnData.objectData);
        }
    }
    public void SpawnPlayer(string sceneName)
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Instantiate(playerPrefab, spawner[sceneName].spawnPos, transform.rotation);
        }

    }
}