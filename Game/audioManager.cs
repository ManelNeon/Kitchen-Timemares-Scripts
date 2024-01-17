using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _walking;


    public bool isMoving = false;
    void Update()
    {
        _walking.Stop();
        CheckWalk();
        WalkSound();
    }

    void CheckWalk()
    {
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            isMoving = false;
        }
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            isMoving = true;
        }
    }

    void WalkSound()
    {
        if (isMoving)
        {
            if (!_walking.isPlaying)
            {
                _walking.Play();
            }
        }
        if (!isMoving)
        {
            if (_walking.isPlaying)
            {
                _walking.Stop();
            }
        }
    }
}
