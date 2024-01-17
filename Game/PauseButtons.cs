using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{
    [SerializeField] private GameObject _uiPanelGameplay;
    [SerializeField] private GameObject _uiPanelPause;
    [SerializeField] private GameObject _controls;

    public void GobackGame()
    {
        Time.timeScale = 1;
        _uiPanelGameplay.SetActive(true);     
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _uiPanelPause.SetActive(false);
    }
    public void GoBackMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Controls()
    {
        _uiPanelPause.SetActive(false);
        _controls.SetActive(true);
    }
}
