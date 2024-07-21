using UnityEngine;

public class Gem : MonoBehaviour, IPowerUp
{

    [SerializeField] private int _scoreAdd;
    public void Apply(GameObject target)
    {
        GameManager.Instance.AddScore(_scoreAdd);
    }
}
