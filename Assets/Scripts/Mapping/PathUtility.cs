using UnityEngine;
using System.Collections.Generic;

public class PathUtility
{
    private static int[,] _map = new int[8, 8];
    public static int[,] Map{get{ return _map; } set{ _map = value; }}
    private static Tile[,] _smap = new Tile[8, 8];
    public static Tile[,] SMap { get { return _smap; } set { _smap = value; } }
    public static List<Vector2> test = new List<Vector2> { Vector2.up, Vector2.down };
    private static Vector2 _source;
    public static Vector2 Source { get { return _source; } set { _source = value; } }
    private static List<Vector2> _path = new List<Vector2>();
    public static List<Vector2> Path => _path;

    public static void CreatePath(Vector2 target)
    {
        Vector2 tmp = _source;

        _path.AddRange(AStarSearch.AStar(_map, _source, target));

        for (int v = 0; v < _path.Count; v++)
        {
            _smap[(int)_path[v].x, (int)_path[v].y].HighlightPathTile();
        }
    }
    
    public static void ErasePathHighlights()
    {
        for (int v = 0; v < _path.Count; v++)
        {
            _smap[(int)_path[v].x, (int)_path[v].y].DehighlightPathTile();
        }
        ClearPath();
    }
    
    public static void ClearPath()
    {
        _path.Clear();
    }
}
