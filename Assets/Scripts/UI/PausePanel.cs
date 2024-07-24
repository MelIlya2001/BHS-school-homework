using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _settings;
    
    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            GameManager.Instance.PauseGame();

            bool pauseStatus = _pausePanel.activeSelf;
            _pausePanel.SetActive(!pauseStatus);
            if (pauseStatus)
                _settings.SetActive(false);
        }
    }

    public void OnPlayClick()
    {
        GameManager.Instance.PauseGame();
        _pausePanel.SetActive(false);
    }
}
