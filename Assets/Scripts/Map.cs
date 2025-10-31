using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject tilePF;
    private Vector2 pos = Vector2.zero;
    public int[,] map = {{1, 1, 1, 1, 1, 1, 1, 1},
                         {1, 0, 0, 1, 1, 0, 0, 1},
                         {1, 1, 1, 1, 1, 1, 1, 1},
                         {1, 0, 0, 1, 1, 0, 0, 1},
                         {1, 0, 0, 1, 1, 0, 0, 1},
                         {1, 1, 1, 1, 1, 1, 1, 1},
                         {1, 0, 0, 1, 1, 0, 0, 1},
                         {1, 1, 1, 1, 1, 1, 1, 1}};
    public Tile[,] SMap = new Tile[8, 8];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject tmp;
        for (int i = 0; i < map.GetLength(0); i++) {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i,j] == 1)
                {
                    pos.x = i;
                    pos.y = j;
                    tmp = Instantiate(tilePF, pos, Quaternion.identity, gameObject.transform);
                    SMap[i, j] = tmp.GetComponent<Tile>();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
