using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
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
    private float xOffset = 0.25f, zOffset = 0.25f;
    [SerializeField]
    private GameObject parentOfGenTile;  
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
                    (parentOfGenTile.transform.position.x - xOffset) * j, 
                    parentOfGenTile.transform.position.y,
                    (parentOfGenTile.transform.position.z - zOffset) * i  
                );
                GameObject tileSpawn = (i + j) % 2 == 0 ? blackTile : whiteTile;
                Instantiate(tileSpawn, pos, tileSpawn.transform.rotation).transform.SetParent(parentOfGenTile.transform); 
            }
        }
    }
}
