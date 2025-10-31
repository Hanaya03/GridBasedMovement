using UnityEngine;
using System.Collections.Generic;

public class PathUtility
{
    public int[,] _map = new int[8, 8];
    public Tile[,] _smap = new Tile[8, 8];
    private Vector2 _source;
    public Vector2 Source { get { return _source; } set { _source = value; } }
    private int _pidx = 0;
    private List<Vector2> _path = new List<Vector2>();
    public List<Vector2> Path => _path;

    public void AddToPath(Vector2 target)
    {
        Debug.Log($"_source is {_source}, pidx = {_pidx}");
        Vector2 tmp = _source;

        _path = AStarSearch.AStar(_map, _source, target);

        for (int v = 0; v < _path.Count; v++)
        {
            _smap[(int)_path[v].x, (int)_path[v].y].HighlightPathTile();
        }
    }
    
    public void ErasePathHighlights()
    {
        for (int v = 0; v < _path.Count; v++)
        {
            _smap[(int)_path[v].x, (int)_path[v].y].DehighlightPathTile();
        }
    }
    
    public void ClearPath()
    {
        _pidx = 0;
    }
}
