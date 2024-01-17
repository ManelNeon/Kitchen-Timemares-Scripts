using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject loading;
    public void play()
    {
        mainMenu.SetActive(false);
        controls.SetActive(true);   
    }

    public void exit()
    {
        Application.Quit();
    }

    public void playplay()
    {
        controls.SetActive(false);
        loading.SetActive(true);
    }

    public void okControls()
    {
        controls.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
