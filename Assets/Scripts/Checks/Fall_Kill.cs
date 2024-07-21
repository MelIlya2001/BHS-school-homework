using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall_Kill : MonoBehaviour
{
    private int _player_layer;

    void Awake(){
        _player_layer = LayerMask.NameToLayer("Player");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == _player_layer)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
