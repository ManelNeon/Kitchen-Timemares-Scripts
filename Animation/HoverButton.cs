using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private GameObject Animation;
    [SerializeField] private GameObject Animation2;


    public void OnPointerEnter(PointerEventData eventData)
    {
        Animation.GetComponent<SpriteAnimation>().Func_PlayUIAnim();
        Animation2.GetComponent<SpriteAnimation>().Func_PlayUIAnim();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Animation.GetComponent<SpriteAnimation>().Func_StopUIAnim();
        Animation2.GetComponent<SpriteAnimation>().Func_StopUIAnim();
    }
}
