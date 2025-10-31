using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject _highLight;
    [SerializeField] private GameObject _pathHighLight;

    public void HighlightTile()
    {
        _highLight.SetActive(true);
    }

    public void HighlightPathTile()
    {
        _pathHighLight.SetActive(true);
    }

    public void DehighlightPathTile()
    {
        _pathHighLight.SetActive(false);
    }
}
