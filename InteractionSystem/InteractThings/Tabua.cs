using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabua : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    [SerializeField] private GameObject _almondegasSpot;

    [SerializeField] private GameObject _carneSpot;

    [SerializeField] private GameObject _tomatoSpot;

    [SerializeField] private GameObject _tomatoSliceSpot;

    [SerializeField] private GameObject _alfaceSpot;

    [SerializeField] private GameObject _almondegas;

    [SerializeField] private GameObject _salad;

    [SerializeField] private GameObject _camera;

    [SerializeField] private GameObject _uiPanel;

    [SerializeField] private AudioSource _chopping;
    public string InteractionPrompt => _prompt;

    private bool _isOccupied;

    private bool _isMeat;

    private bool _isSalad;

    private bool _isDone;

    private void Start()
    {
        _isOccupied = false;
        _isMeat = false;
        _isSalad = false;
        _isDone = false;
    }

    private void Update()
    {
        if (_uiPanel.GetComponent<CountDown>().countdownText.text == ("Ready!") && _isOccupied == true && _isMeat == true)
        {
            _carneSpot.SetActive(false);
            _almondegasSpot.SetActive(true);   
        }
        if (_uiPanel.GetComponent<CountDown>().countdownText.text == ("Ready!") && _isOccupied == true && _isSalad == true)
        {
            _tomatoSpot.SetActive(false);
            _tomatoSliceSpot.SetActive(true);
        }
    }

    public bool Interact(Interactor interactor)
    {
        if (_camera.GetComponent<PickUp>().heldObj == null && _uiPanel.GetComponent<CountDown>().countdownText.text == ("Ready!"))
        {
            if (_isMeat == true)
            {
                _uiPanel.GetComponent<CountDown>().TurnOff();
                _isOccupied = false;
                _isMeat = false;
                _almondegasSpot.SetActive(false);
                GameObject almondegas1 = Instantiate(_almondegas, new Vector3(0, 0, 0), _almondegas.transform.rotation);
                _camera.GetComponent<PickUp>().PickUpObject(almondegas1);
                return true;
            }
            if (_isSalad == true)
            {
                if (_isDone)
                {
                    _uiPanel.GetComponent<CountDown>().TurnOff();
                    _isOccupied = false;
                    _isSalad = false;
                    _isDone = false;
                    _tomatoSliceSpot.SetActive(false);
                    _alfaceSpot.SetActive(false);
                    GameObject salada1 = Instantiate(_salad, new Vector3(0, 0, 0), _salad.transform.rotation);
                    _camera.GetComponent<PickUp>().PickUpObject(salada1);
                    return true;
                }
            }
        }
         return true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("carne(Clone)") && !_isOccupied)
        {
            _chopping.Play();
            _isMeat = true;
            _isOccupied = true;
            Destroy(collision.gameObject);
            _carneSpot.SetActive(true);
            _uiPanel.GetComponent<CountDown>().Countdown();
        }
        if (collision.gameObject.name == ("Tomate(Clone)") && !_isOccupied)
        {
            _chopping.Play();
            _isSalad = true;
            _isOccupied = true;
            Destroy(collision.gameObject);
            _tomatoSpot.SetActive(true);
            _uiPanel.GetComponent<CountDown>().Countdown();
        }
        if (collision.gameObject.name == ("alface(Clone)") && _isDone == false && _isSalad == true && _uiPanel.GetComponent<CountDown>().countdownText.text == ("Ready!"))
        {
            _chopping.Play();
            _isDone = true;
            Destroy(collision.gameObject);
            _alfaceSpot.SetActive(true);
            _uiPanel.GetComponent<CountDown>().Countdown();
        }
    }
}
