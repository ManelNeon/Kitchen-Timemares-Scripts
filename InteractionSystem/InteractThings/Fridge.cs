using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private Animator _doorAnim;
    public string InteractionPrompt => _prompt;
    private bool _isOpen;

    private void Start()
    {
        _isOpen = false;
    }

    public bool Interact(Interactor interactor)
    {
        if (_isOpen)
        {
            Close();
            return true;
        }
        if (!_isOpen)
        {
            Open();
            return true;
        }
        else return true;
    }

    private void Open()
    {
        _doorAnim.SetTrigger("OpenDoor");
        _prompt = ("Close");
        _isOpen = true;
    }

    private void Close()
    {
        Debug.Log("EEE");
        _doorAnim.ResetTrigger("OpenDoor");
        _prompt = ("Open");
        _isOpen = false;
    }
}
