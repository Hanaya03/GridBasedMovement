using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject _highLight;
    [SerializeField] private GameObject _pathHighLight;
    [SerializeField] private GameObject _unitHighLight;

    public void HighlightTile()
    {
        _highLight.SetActive(true);
    }

    public void DeHighlightTile()
    {
        _highLight.SetActive(false);
    }

    public void HighlightPathTile()
    {
        _pathHighLight.SetActive(true);
    }

    public void DehighlightPathTile()
    {
        _pathHighLight.SetActive(false);
    }

    public void HighlightUnit()
    {
        _unitHighLight.SetActive(true);
    }

    public void DeHighlightUnit()
    {
        _unitHighLight.SetActive(false);
    }
}
