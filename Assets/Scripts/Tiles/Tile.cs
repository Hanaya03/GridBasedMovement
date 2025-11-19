using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private GameObject _highLight;
    [SerializeField] private GameObject _pathHighLight;
    [SerializeField] private GameObject _unitHighLight;

    private SpriteRenderer _sp;

    void Start()
    {
        _sp = _pathHighLight.GetComponent<SpriteRenderer>();
    }

    public void TargetTile()
    {
        _sp.color = new Color32(0x64, 0x00, 0x00, 0xFF);
    }

    public void DeTargetTile()
    {
        _sp.color = new Color32(0xFF, 0x00, 0x00, 0xA4);
    }

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
