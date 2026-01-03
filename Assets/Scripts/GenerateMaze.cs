using System.Numerics;
using UnityEngine;

public class GenerateMaze : MonoBehaviour
{
    [SerializeField] private MazeCell mazeCell ; 
    [SerializeField] private MazeCell[,] maze ; 
    [SerializeField] private int mazeLength , mazeWidth ; 
    void Start()
    {
        maze = new MazeCell[mazeLength , mazeWidth ];
        for(int z = 0 ; z < mazeLength ; z++)
        {
            for(int x = 0 ; x < mazeWidth ; x++)
            {
                maze[z,x] = Instantiate(mazeCell , new UnityEngine.Vector3(x , 0  ,z) , UnityEngine.Quaternion.identity) ; 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
