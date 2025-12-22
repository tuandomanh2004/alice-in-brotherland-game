using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}
    public GameState state ; 
    public enum GameState
    {
       Playing,
       Paused,
       Loading
     }
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject) ; 
        }
        else
        {
            Instance = this ; 
            state = GameState.Playing ;
            DontDestroyOnLoad(gameObject) ; 
        }
    }
}
