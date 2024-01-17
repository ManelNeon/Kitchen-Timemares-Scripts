using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] private GameObject Animation;
    [SerializeField] private Image LoadingBar;

    float maxAmount = 100;

    bool time;

    float currentAmount;
    void Awake()
    {
        currentAmount = 0;
        time = false;
        Animation.GetComponent<SpriteAnimation>().Func_PlayUIAnim();
    }

    void Update()
    {
        if (!time)
        {
            StartCoroutine(load());
        }
        LoadingBar.fillAmount = currentAmount / maxAmount;

        if (currentAmount == maxAmount)
        {
            SceneManager.LoadScene("Kitchen");
        }
    }

    IEnumerator load()
    {
        time = true;
        yield return new WaitForSecondsRealtime(.1f);
        currentAmount++;
        time = false;
    }
}
