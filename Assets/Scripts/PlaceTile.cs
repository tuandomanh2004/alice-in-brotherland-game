using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
public class PlaceTile : MonoBehaviour
{
    [SerializeField]
    private GameObject blackTile;
    [SerializeField]
    private GameObject whiteTile;
    [SerializeField]
    private int row = 8;
    [SerializeField]
    private int col = 8;
    [SerializeField]
    private UnityEngine.Vector3 startPos = new UnityEngine.Vector3(1 , 0.05f ,1);
    private float xOffset = 0.25f ,  zOffset = 0.25f; 
    void Start()
    {
        GenerateFloor();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void GenerateFloor()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                UnityEngine.Vector3 pos = new UnityEngine.Vector3(
                    (startPos.x - xOffset) * j,
                    startPos.y,
                    (startPos.z - zOffset) * i
                );
                GameObject tileSpawn = (i + j) % 2 == 0 ? blackTile : whiteTile;
                Instantiate(tileSpawn,pos,tileSpawn.transform.rotation);  
            }
        }
    }
}
