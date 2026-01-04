using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Schema;
using Mono.Cecil.Cil;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateMaze : MonoBehaviour
{
    [SerializeField] private MazeCell mazeCell;
    [SerializeField] private MazeCell[,] maze;
    [SerializeField] private int mazeLength, mazeWidth;
    [SerializeField] private int[] directionX = { -1, 1, 0, 0 };
    [SerializeField] private int[] directionZ = { 0, 0, 1, -1 };
    void Start()
    {
        InitializeGrid();
        StartCoroutine(GenMaze());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void InitializeGrid()
    {
        maze = new MazeCell[mazeLength, mazeWidth];
        for (int z = 0; z < mazeLength; z++)
        {
            for (int x = 0; x < mazeWidth; x++)
            {
                maze[z, x] = Instantiate(mazeCell, new UnityEngine.Vector3(x, 0, z), UnityEngine.Quaternion.identity);
                maze[z, x].SetCoordinate(z, x);
            }
        }
    }
    private IEnumerator GenMaze()
    {
        int startX = Random.Range(0 , mazeWidth) ; 
        int startZ = Random.Range(0 , mazeLength) ; 
        var startCell = maze[startZ, startX];
        Stack<MazeCell> stack = new Stack<MazeCell>();
        stack.Push(startCell);
        startCell.isVisited = true ; 
        while (stack.Count > 0)
        {
            var currentCell = stack.Peek();
            currentCell.Visited();
            List<int> directions = AvailablePath(currentCell);
            if (directions.Count > 0) // Check nếu còn đường đi ở node hiện tại
            {
                Debug.Log($"current cell : {currentCell.GetZCoordinate()},{currentCell.GetXCoordinate()}") ; 
                int randomIndex = Random.Range(0, directions.Count); // Chọn random 1 node để rẽ nhánh đi tiếp 
                Debug.Log($"random index : {randomIndex}") ; 
                int x = currentCell.GetXCoordinate() + directionX[directions[randomIndex]];
                int z = currentCell.GetZCoordinate() + directionZ[directions[randomIndex]];
                Debug.Log($"directionX : {directionX[randomIndex]} , directionZ = {directionZ[randomIndex]}") ;
                var adjacentCell = maze[z, x];
                adjacentCell.isVisited = true;
                stack.Push(adjacentCell);

            }
            else
            {
                stack.Pop();
            }
            yield return null;
        }
    }
    private List<int> AvailablePath(MazeCell currentCell)
    {
        List<int> path = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            int moveX = currentCell.GetXCoordinate() + directionX[i];
            int moveZ = currentCell.GetZCoordinate() + directionZ[i];
            if (moveX >= mazeWidth || moveX < 0) continue;
            if (moveZ >= mazeLength || moveZ < 0) continue;
            var adjacentCell = maze[moveZ, moveX];
            if (!adjacentCell.isVisited) path.Add(i);
        }
        return path;
    }

}
