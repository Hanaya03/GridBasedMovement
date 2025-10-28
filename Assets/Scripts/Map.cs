using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject tilePF;
    private Vector3 pos = Vector3.zero;
    public int[,] map = {{1, 1, 1, 1, 1, 1, 1, 1},
                         {1, 0, 0, 1, 1, 0, 0, 1},
                         {1, 1, 1, 1, 1, 1, 1, 1},
                         {1, 0, 0, 1, 1, 0, 0, 1},
                         {1, 0, 0, 1, 1, 0, 0, 1},
                         {1, 1, 1, 1, 1, 1, 1, 1},
                         {1, 0, 0, 1, 1, 0, 0, 1},
                         {1, 1, 1, 1, 1, 1, 1, 1}};
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i,j] == 1)
                {
                    pos.x = i;
                    pos.z = j;
                    Instantiate(tilePF, pos, Quaternion.identity, gameObject.transform);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
