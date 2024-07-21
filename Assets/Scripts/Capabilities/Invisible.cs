using UnityEngine;

public class Invisible : MonoBehaviour
{
    [SerializeField] private LayerMask skip_layers;
    private LayerMask _playerLayer;
    private Color _playerColor;

    private void Start()
    {
        _playerLayer = gameObject.layer;
        _playerColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    public void GetInvise()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        gameObject.GetComponent<BoxCollider2D>().excludeLayers = skip_layers;
        gameObject.layer = 0;
    }

    public void LeaveInvise()
    {
        gameObject.GetComponent<SpriteRenderer>().color = _playerColor;
        gameObject.layer = _playerLayer;
        gameObject.GetComponent<BoxCollider2D>().excludeLayers = new LayerMask();
    }
}
