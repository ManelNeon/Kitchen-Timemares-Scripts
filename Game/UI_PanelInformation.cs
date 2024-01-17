using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PanelInformation : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelUI;
    public void OnClick()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        panel.SetActive(false);
        panelUI.SetActive(true);
        Time.timeScale = 1;
    }
}

