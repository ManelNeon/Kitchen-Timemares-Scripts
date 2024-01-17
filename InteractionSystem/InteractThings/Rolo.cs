using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Rolo : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    [SerializeField] private GameObject pizza;

    [SerializeField] private GameObject _camera;

    [SerializeField] private GameObject _uiPanel;

    [SerializeField] private GameObject _emptyPizza;

    [SerializeField] private GameObject _pizzaTomato;

    [SerializeField] private GameObject _pizzaCheese;

    [SerializeField] Animator _RollAnim;
    public string InteractionPrompt => _prompt;

    private bool _isReady;

    private bool _hasFarinha;

    private bool _hasTomate;

    private void Start()
    {
        _isReady = false;
        _hasFarinha = false;
        _hasTomate = false;
    }
    private void Update()
    {
        if (_uiPanel.GetComponent<CountDown>().countdownText.text == ("Ready!") && _hasFarinha)
        {
            _RollAnim.ResetTrigger("IsRoll");
            _emptyPizza.SetActive(true);
        }
        if (_uiPanel.GetComponent<CountDown>().countdownText.text == ("Ready!") && _hasTomate)
        {
            _emptyPizza.SetActive(false);
            _pizzaTomato.SetActive(true);
        }
        if (_uiPanel.GetComponent<CountDown>().countdownText.text == ("Ready!") && _isReady)
        {
            _pizzaTomato.SetActive(false);
            _pizzaCheese.SetActive(true);
        }
    }
    public bool Interact(Interactor interactor)
    {
        if (_camera.GetComponent<PickUp>().heldObj == null && _isReady)
        {
            _pizzaCheese.SetActive(false);
            GameObject pizza1 = Instantiate(pizza, this.transform.position, pizza.transform.rotation);
            _camera.GetComponent<PickUp>().PickUpObject(pizza1);
            _uiPanel.GetComponent<CountDown>().TurnOff();
            _hasFarinha = false;
            _hasTomate = false;
            _isReady = false;
            return true;
        }
        return true;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("farinha(Clone)"))
        {
            Destroy(collision.gameObject);
            _RollAnim.SetTrigger("IsRoll");
            _hasFarinha = true;
            _uiPanel.GetComponent<CountDown>().Countdown();
        }
        if (collision.gameObject.name == ("frasco_tomate(Clone)") && _hasFarinha)
        {
            Destroy(collision.gameObject);
            _hasTomate = true;
            _uiPanel.GetComponent<CountDown>()._startingTime = 1;
            _uiPanel.GetComponent<CountDown>().Countdown();
        }
        if (collision.gameObject.name == ("queijo(Clone)") && _hasTomate)
        {
            Destroy(collision.gameObject);
            _isReady = true;
            _uiPanel.GetComponent<CountDown>()._startingTime = 1;
            _uiPanel.GetComponent<CountDown>().Countdown();
        }
    }
}

