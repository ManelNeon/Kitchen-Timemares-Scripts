using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Oven : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    [SerializeField] private GameObject pizzaDone;

    [SerializeField] private GameObject _camera;

    [SerializeField] private GameObject _uiPanel;

    [SerializeField] private AudioSource _cooking;
    public string InteractionPrompt => _prompt;

    private bool _isOcupied;

    public bool Interact(Interactor interactor)
    {
        if (_uiPanel.GetComponent<CountDown>().countdownText.text == ("Ready!"))
        {
            _cooking.Stop();
            GameObject pizzaDone1 = Instantiate(pizzaDone, this.transform.position, pizzaDone.transform.rotation);
            _camera.GetComponent<PickUp>().PickUpObject(pizzaDone1);
            _uiPanel.GetComponent<CountDown>().TurnOff();
            _isOcupied = false;
            return true;
        }
        return true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == ("piça(Clone)") && !_isOcupied)
        {
            _cooking.Play();
            _isOcupied = true;
            Destroy(collision.gameObject);
            _uiPanel.GetComponent<CountDown>().Countdown();
        }
    }
}
