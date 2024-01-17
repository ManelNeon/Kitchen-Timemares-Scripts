using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uabo : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    [SerializeField] private GameObject uabo;

    [SerializeField] private GameObject _camera;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (_camera.GetComponent<PickUp>().heldObj == null)
        {
            GameObject uabo1 = Instantiate(uabo, this.transform.position, uabo.transform.rotation);
            _camera.GetComponent<PickUp>().PickUpObject(uabo1);
            Debug.Log("Got Eggs");

            return true;
        }
        else
        {
            return true;
        }
    }
}