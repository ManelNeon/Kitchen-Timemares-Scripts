using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class CountDown : MonoBehaviour
{
    public float _currentTime = 0;

    [SerializeField] public float _startingTime;

    public TextMeshProUGUI countdownText;

    [SerializeField] private GameObject _uipanel;

    private void Start()
    {   
        _uipanel.SetActive(false);
    }
    private void Update()
    {
        if (_uipanel != null)
        {
            if (_currentTime < 1)
            {
                countdownText.text = ("Ready!");
            }
            else
            {
                _currentTime -= 1 * Time.deltaTime;
                countdownText.text = _currentTime.ToString("0");
            }
        }
    }
    public void Countdown()
    {
        _currentTime = _startingTime;
        _uipanel.SetActive(true);  
    }

    public void TurnOff()
    {
        _uipanel.SetActive(false);
    }
}
