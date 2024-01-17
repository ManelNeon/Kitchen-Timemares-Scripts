using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frigideiras : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    [SerializeField] private GameObject pan;

    [SerializeField] private GameObject _camera;
    public string InteractionPrompt => _prompt;

    public bool Interact(Interactor interactor)
    {
        if (_camera.GetComponent<PickUp>().heldObj != null)
        {
            Debug.Log("ss");
            return true;
        }
        else
        {
            GameObject pan1 = Instantiate(pan, new Vector3(0, 0, 0), pan.transform.rotation);
            _camera.GetComponent<PickUp>().PickUpObject(pan1);
            Debug.Log("Got Pan");

            return true;
        }
    }
}
