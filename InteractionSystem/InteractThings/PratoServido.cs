using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PratoServido : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject platePlace;
    [SerializeField] private GameObject Garcom;
    [SerializeField] private GameObject GameDesign;
    public string InteractionPrompt => _prompt;

    public bool isPlate;

    private void Start()
    {
        isPlate = false;    
    }

    public bool Interact(Interactor interactor)
    {
        return true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!isPlate)
        {
            if (GameDesign.GetComponent<DesignGame>().random == 1)
            {
                if (collision.gameObject.name == ("ovonoprato(Clone)"))
                {
                    collision.gameObject.tag = ("Untagged");
                    collision.transform.position = platePlace.transform.position;
                    collision.transform.rotation = platePlace.transform.rotation;
                    isPlate = true;
                    GameDesign.GetComponent<DesignGame>()._delivery = true;
                }
            }
            if (GameDesign.GetComponent<DesignGame>().random == 2)
            {
                if (collision.gameObject.name == ("prato_bolonhesa(Clone)"))
                {
                    collision.gameObject.tag = ("Untagged");
                    collision.transform.position = platePlace.transform.position;
                    collision.transform.rotation = platePlace.transform.rotation;
                    isPlate = true;
                    GameDesign.GetComponent<DesignGame>()._delivery = true;
                }
            }
            if (GameDesign.GetComponent<DesignGame>().random == 3)
            {
                if (collision.gameObject.name == ("prato_Salada(Clone)"))
                {
                    collision.gameObject.tag = ("Untagged");
                    collision.transform.position = platePlace.transform.position;
                    collision.transform.rotation = platePlace.transform.rotation;
                    isPlate = true;
                    GameDesign.GetComponent<DesignGame>()._delivery = true;
                }
            }
            if (GameDesign.GetComponent<DesignGame>().random == 4)
            {
                if (collision.gameObject.name == ("piça_cozinhada(Clone)"))
                {
                    collision.gameObject.tag = ("Untagged");
                    collision.transform.position = platePlace.transform.position;
                    collision.transform.rotation = platePlace.transform.rotation;
                    isPlate = true;
                    GameDesign.GetComponent<DesignGame>()._delivery = true;
                }
            }
        }
    }
}
