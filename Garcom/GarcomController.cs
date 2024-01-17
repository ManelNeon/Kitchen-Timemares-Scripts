using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GarcomController : MonoBehaviour
{
    [SerializeField] private GameObject spot1;
    [SerializeField] private GameObject spot2;
    [SerializeField] private GameObject PlateServed;
    [SerializeField] private GameObject GameDesign;
    [SerializeField] private float speed;

    public bool _hasPlate;
    private void Update()
    {
        if (PlateServed.GetComponent<PratoServido>().isPlate == true)
        {
            GoGrabPlate();
        }
        if (PlateServed.GetComponent<PratoServido>().isPlate == false && _hasPlate)
        {
            GoBackWithPlate();
        }
    }

    private void GoGrabPlate()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, spot1.transform.position, speed * Time.deltaTime);

        if (this.gameObject.transform.position == spot1.transform.position)
        {
            PlateServed.GetComponent<PratoServido>().isPlate = false;
            Destroy(GameObject.Find("ovonoprato(Clone)"));
            Destroy(GameObject.Find("prato_bolonhesa(Clone)"));
            Destroy(GameObject.Find("prato_Salada(Clone)"));
            Destroy(GameObject.Find("piça_cozinhada(Clone)"));
            GameDesign.GetComponent<DesignGame>().ChangeReceita();
            _hasPlate = true;
        }
    }

    public void GoBackWithPlate()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, spot2.transform.position, speed * Time.deltaTime);
    }
}
