using UnityEngine;
using System.Collections.Generic;

public class PathUtility
{
    public int[,] _map = new int[8,8];
    private Vector2 _source;
    public Vector2 Source { set { _source = value; } }
    private int _pidx = 0;
    private Vector2[] _path = new Vector2[5];
    public (Vector2[], int) Path => (_path, _pidx);

    public void AddToPath(Vector2 target)
    {
        Debug.Log($"_source is {_source}, pidx = {_pidx}");
        Vector2 tmp = _source;
        if(_pidx != 0 && _pidx != _path.Length){ tmp = _path[_pidx - 1]; }
        if ((tmp.x != target.x && tmp.y != target.y) || (tmp == target))
        {
            Debug.Log("invalid target");
            return;
        }

        if(tmp.x == target.x)
        {
            if (tmp.y < target.y) { DrawLine(Vector2.up, (int)(target.y- tmp.y)); }
            else{ DrawLine(Vector2.down, (int)( tmp.y - target.y)); }
        }
        else
        {
            if (tmp.x < target.x) { DrawLine(Vector2.right, (int)(target.x- tmp.x)); }
            else{ DrawLine(Vector2.left, (int)( tmp.x - target.x)); }
        }
    }

    private void DrawLine(Vector2 dir, int steps)
    {
        Vector2 _step = _source + dir;
        for (int i = 0; i < steps; i++)
        {
            if (_pidx == _path.Length)
                return;
            

            if (_pidx == 0)
            {
                if(_map[(int)_step.x,(int)_step.y] == 0){ return; }
                _path[_pidx] = _step; 
            }else
            {
                _step = _path[_pidx - 1] + dir;
                if(_map[(int)_step.x,(int)_step.y] == 0){ return; }
                _path[_pidx] = _step;
            }
            _pidx++;
        }
    }
    
    public void ClearPath()
    {
        _pidx = 0;
    }
}
