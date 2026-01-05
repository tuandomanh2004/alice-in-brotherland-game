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
        GameObject grid = new GameObject("Grid");
        maze = new MazeCell[mazeLength, mazeWidth];
        for (int z = 0; z < mazeLength; z++)
        {
            for (int x = 0; x < mazeWidth; x++)
            {
                maze[z, x] = Instantiate(mazeCell, new UnityEngine.Vector3(x, 0, z), UnityEngine.Quaternion.identity);
                maze[z, x].SetCoordinate(z, x);
                maze[z,x].transform.SetParent(grid.transform,true );
            }
        }
    }
    private IEnumerator GenMaze()
    {
        // Chọn 1 node bẩt kì và tiến bắt đầu gen
        int startX = Random.Range(0, mazeWidth);
        int startZ = Random.Range(0, mazeLength);
        var startCell = maze[startX,startZ];
        Stack<MazeCell> stack = new Stack<MazeCell>();
        stack.Push(startCell);
        startCell.isVisited = true;

        while (stack.Count > 0)
        {
            var currentCell = stack.Peek();
            currentCell.Visited();
            List<int> currentDirections = AvailablePath(currentCell); 

            if (currentDirections.Count > 0) // Check nếu còn đường đi ở node hiện tại
            {

                // Chọn random 1 hướng để rẽ nhánh đi tiếp dựa trên các đường đi hợp lệ của node hiện tại
                int randomIndex = Random.Range(0, currentDirections.Count); 
                int dir = currentDirections[randomIndex];
                int x = currentCell.GetXCoordinate() + directionX[dir];
                int z = currentCell.GetZCoordinate() + directionZ[dir];

                // Thêm node vào stack và tiếp tục đào sâu theo nhánh của node này
                var adjacentCell = maze[z, x];
                adjacentCell.isVisited = true;
                BreakWall(currentCell , adjacentCell) ; 
                stack.Push(adjacentCell);

            }
            else
            {
                stack.Pop(); // Node đã bí đường , loại khỏi stack và tiến hành backtracking
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
    private void BreakWall(MazeCell currentCell, MazeCell adjacentCell)
    {
        int zCurrent = currentCell.GetZCoordinate();
        int zAdjacent = adjacentCell.GetZCoordinate();
        int xCurrent = currentCell.GetXCoordinate();
        int xAdjacent = adjacentCell.GetXCoordinate() ; 
        bool isVertical = xCurrent == xAdjacent;  // Check if 2 wall là ngang hay dọc nhau

        // Nếu 2 tường dọc nhau thì xét phá trên dưới
        if (isVertical) 
        {  
            currentCell.BreakWall(zAdjacent > zCurrent ? MazeCell.Wall.Front : MazeCell.Wall.Back);
            adjacentCell.BreakWall(zAdjacent > zCurrent ? MazeCell.Wall.Back : MazeCell.Wall.Front);
        }

        // Nếu 2 tường ngang nhau thì xét phá trái phải 
        else
        {
            currentCell.BreakWall(xCurrent > xAdjacent ? MazeCell.Wall.Left : MazeCell.Wall.Right);
            adjacentCell.BreakWall(xCurrent > xAdjacent ?MazeCell.Wall.Right : MazeCell.Wall.Left ) ; 
        }
    }

}
