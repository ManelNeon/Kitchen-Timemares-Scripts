using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChange : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _receitaOG;
    [SerializeField] private TextMeshProUGUI _receitaNow;
    private void Update()
    {
        if(_receitaNow.text != _receitaOG.text)
        {
            _receitaNow.text = _receitaOG.text;
        }
    }
}
