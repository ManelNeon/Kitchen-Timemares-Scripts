using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour , IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject onEggs;
    [SerializeField] private GameObject onTomatoes;
    [SerializeField] private GameObject off;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private GameObject Smasheduabo;
    [SerializeField] private GameObject TomatoSauce;
    [SerializeField] private GameObject _camera;
    [SerializeField] private AudioSource _blendin;

    bool _isOn;

    bool tomato;
    public string InteractionPrompt => _prompt;

    private void Start()
    {
        _blendin.Stop();
        _isOn = false;
        tomato = false;
    }

    public bool Interact(Interactor interactor)
    {
        if (_isOn)
        {
            if (_uiPanel.GetComponent<CountDown>().countdownText.text == ("Ready!") && (_camera.GetComponent<PickUp>().heldObj == null))
            {
                if (!tomato)
                {
                    OffEggs();
                    GameObject uabo1 = Instantiate(Smasheduabo, new Vector3(-1, -1, -1), Smasheduabo.transform.rotation);
                    _camera.GetComponent<PickUp>().PickUpObject(uabo1);
                    _uiPanel.GetComponent<CountDown>().TurnOff();
                    return true;
                }
                if (tomato)
                {
                    OffTomatoes();
                    GameObject tomatosouce = Instantiate(TomatoSauce, new Vector3(-1, -1, -1), TomatoSauce.transform.rotation);
                    _camera.GetComponent<PickUp>().PickUpObject(tomatosouce);
                    _uiPanel.GetComponent<CountDown>().TurnOff();
                    tomato = false;
                    return true;
                }
            }
        }
        return true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("uabo(Clone)") && (!_isOn))
        {
            Destroy (collision.gameObject);
            _blendin.Stop();
            _blendin.Play();
            OnEggs();
        }
        if (collision.gameObject.name == ("Tomate(Clone)") && (!_isOn))
        {
            tomato = true;
            _blendin.Stop();
            _blendin.Play();
            Destroy (collision.gameObject);
            OnTomatoes();
        }
    }

    private void OnTomatoes()
    {
        onTomatoes.transform.position = off.transform.position;
        off.transform.position = new Vector3(0, 0, 0);
        _isOn = true;
        _uiPanel.GetComponent<CountDown>().Countdown();
    }

    private void OnEggs()
    {
        Debug.Log("EEEE");
        onEggs.transform.position = off.transform.position;
        off.transform.position = new Vector3(0, 0, 0);
        _isOn = true;
        _uiPanel.GetComponent<CountDown>().Countdown();
    }

    private void OffEggs()
    {
        
        Debug.Log("RRR");
        off.transform.position = onEggs.transform.position;
        onEggs.transform.position = new Vector3(0, 0, 0);
        _isOn = false;
    }

    private void OffTomatoes()
    {
        off.transform.position = onTomatoes.transform.position;
        onTomatoes.transform.position = new Vector3(0, 0, 0);
        _isOn = false;
    }
}
