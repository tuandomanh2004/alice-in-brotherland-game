using Unity.VisualScripting;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    public struct Coordinate
    {
        public int xCoordinate  ; 
        public int zCoordinate;
    }
    [SerializeField] private Coordinate cellCoordinates;
    [SerializeField] private GameObject leftWall;
    [SerializeField] private GameObject rightWall;
    [SerializeField] private GameObject frontWall;
    [SerializeField] private GameObject backWall;
    [SerializeField] private GameObject visited;
    public bool isVisited = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Visited()
    {
        visited.SetActive(false);
    }
    public void SetCoordinate(int z, int x)
    {
        cellCoordinates.zCoordinate = z;
        cellCoordinates.xCoordinate = x;
    }
    public int GetXCoordinate() => cellCoordinates.xCoordinate;
    public int GetZCoordinate() => cellCoordinates.zCoordinate ; 
}
