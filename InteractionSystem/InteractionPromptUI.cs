using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera _mainCam;
    [SerializeField] private TextMeshProUGUI _promptText;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private GameObject receita;

    private bool _showReceita;

    private void Start()
    {
        _showReceita = true;
        _mainCam = Camera.main;
        _uiPanel.SetActive(false);
    }

    private void Update()
    {
        HideReceita();
    }

    private bool HideReceita()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_showReceita == false)
            {
                Debug.Log("EEEDDDD");
                receita.SetActive(true);
                _showReceita = true;
                return true;
            }
            if (_showReceita == true)
            {
                Debug.Log("EEE");
                receita.SetActive(false);
                _showReceita = false;
                return true;
            }
        }
        return true;
    }


    private void LateUpdate()
    {
        var rotation = _mainCam.transform.rotation;

        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public bool IsDisplayed = false;

    public void SetUp(string promptText)
    {
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        _uiPanel.SetActive(false);
        IsDisplayed = false;
    }
}
