using UnityEngine;
using System.Collections.Generic;

public class PathUtility
{
    private Coords _source;
    public Coords Source{set{ _source = value; }}
    private int[] _path;
    public int[] Path => _path;

    public void AddToPath(Coords target)
    {
        if(_source.X != target.X && _source.Y != target.Y)
        {
            Debug.Log("invalid target");
            return;
        }
    }
}
