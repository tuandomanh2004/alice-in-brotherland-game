using Unity.VisualScripting;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField] private GameObject leftWall ; 
    [SerializeField] private GameObject rightWall ; 
    [SerializeField] private GameObject frontWall ; 
    [SerializeField] private GameObject backWall ; 
    [SerializeField] private GameObject visited ;
    public bool isVisited = false ; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Visited()
    {
        isVisited = true ; 
        visited.SetActive(false) ; 
    }
}
