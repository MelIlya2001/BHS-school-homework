 using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FinishZone : MonoBehaviour
{
    [SerializeField] private GameObject _panelFinishLevel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        _panelFinishLevel.SetActive(true);
        GameManager.Instance.PauseGame();
    }

    public void OnNextlevelButtonClick()
    {
        GameManager.Instance.LoadNextLevel();
    }

    public void OnExitMainMenuClick()
    {
        GameManager.Instance.FinishCurrentLevel();
    }
}
