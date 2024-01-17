using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Stove : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject panNot;
    [SerializeField] private GameObject panOn;
    [SerializeField] private GameObject panSpot;
    [SerializeField] private GameObject OmoleteDone;
    [SerializeField] private GameObject BolonhesaDone;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _panela;
    [SerializeField] private GameObject _panelaAlmondegas;
    [SerializeField] private AudioSource _panelaSound;
    [SerializeField] private AudioSource _frigideiraSound;

    public string InteractionPrompt => _prompt;

    private int panCount;

    private bool _isFrig;

    private bool _isPanela;

    private bool _hasSauce;

    private bool _Ready;

    private void Start()
    {
        panCount = 0;
        _isFrig = false;
        _isPanela = false;
        _hasSauce = false;
        _Ready = false;
    }

    public bool Interact(Interactor interactor)
    {
        if (_uiPanel.GetComponent<CountDown>().countdownText.text == ("Ready!") && (_camera.GetComponent<PickUp>().heldObj == null) && (_uiPanel.activeInHierarchy == true) && _isFrig)
        {
            _frigideiraSound.Stop();
            panOn.transform.position = new Vector3(0, 0, 0);
            GameObject Omolete1 = Instantiate(OmoleteDone, new Vector3(-1, -1, -1), OmoleteDone.transform.rotation);
            _camera.GetComponent<PickUp>().PickUpObject(Omolete1);
            _uiPanel.GetComponent<CountDown>().TurnOff();
            panCount--;
            _isFrig = false;
            return true;
        }
        if (_uiPanel.GetComponent<CountDown>().countdownText.text == ("Ready!") && (_camera.GetComponent<PickUp>().heldObj == null) && (_uiPanel.activeInHierarchy == true) && _Ready )
        {
            _panelaSound.Stop();
            _panelaAlmondegas.SetActive(false);
            GameObject bolonhesa1 = Instantiate(BolonhesaDone, new Vector3(-1, -1, -1), BolonhesaDone.transform.rotation);
            _camera.GetComponent<PickUp>().PickUpObject(bolonhesa1);
            _uiPanel.GetComponent<CountDown>().TurnOff();
            panCount--;
            _isPanela = false;
            _hasSauce = false;
            _Ready = false;
            return true;
        }
        return true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("PickPan(Clone)"))
        {
            if (panCount == 0)
            {
                _isFrig = true;
                PlacePan();
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.name == ("ovos_mexidos(Clone)") && _isFrig)
        {
            _frigideiraSound.Play();
            DoCookEgg();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == ("Panela(Clone)"))
        {
            if (panCount == 0)
            {
                _isPanela = true;
                PlacePanela();
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.name == ("frasco_tomate(Clone)") && _isPanela)
        {
            _panelaSound.Play();
            DoStartSauce();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == ("almondegas(Clone)") && _isPanela && _hasSauce && (_uiPanel.GetComponent<CountDown>().countdownText.text == ("Ready!")))
        {
            DoStartCookMitoball();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == ("esparguete(Clone)") && _isPanela && _Ready && (_uiPanel.GetComponent<CountDown>().countdownText.text == ("Ready!")))
        {
            DoCookMitoballs();
            Destroy(collision.gameObject);
        }
    }

    private void PlacePan()
    {
        panNot.transform.position = panSpot.transform.position;
        panCount++;
    }

    private void PlacePanela()
    {
        _panela.SetActive(true);
        panCount++;
    }

    private void DoStartSauce()
    {
        _uiPanel.GetComponent<CountDown>()._startingTime = 5;
        _uiPanel.GetComponent<CountDown>().Countdown();
        _hasSauce = true;
    }

    private void DoCookEgg()
    {
        if (panNot.transform.position == panSpot.transform.position)
        {
            _uiPanel.GetComponent<CountDown>()._startingTime = 15;
            panNot.transform.position = new Vector3(1, 1, 1);
            panOn.transform.position = panSpot.transform.position;
            _uiPanel.GetComponent<CountDown>().Countdown();
        }
    }

    private void DoStartCookMitoball()
    {
        _uiPanel.GetComponent<CountDown>()._startingTime = 10;
        _uiPanel.GetComponent<CountDown>().Countdown();
        _Ready = true;
        _panela.SetActive(false);
        _panelaAlmondegas.SetActive(true);
    }

    private void DoCookMitoballs()
    {
        _uiPanel.GetComponent<CountDown>()._startingTime = 5;
        _uiPanel.GetComponent<CountDown>().Countdown();
    }
}
