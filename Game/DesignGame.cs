using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using TMPro;
using UnityEngine;

public class DesignGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Timer;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Stop;
    [SerializeField] private GameObject knife;
    [SerializeField] private GameObject Timesy;
    [SerializeField] private TextMeshProUGUI Receita;
    [SerializeField] private GameObject Receita__;
    [SerializeField] private GameObject pratoServido;
    [SerializeField] private GameObject _uiPanelPause;
    [SerializeField] private GameObject _uiPanelGameplay;
    [SerializeField] private GameObject _uiPanelWin;
    [SerializeField] private GameObject _uiPanelLose;
    [SerializeField] private GameObject _camera;
    [SerializeField] private AudioSource _level1;
    [SerializeField] private AudioSource _level2;
    [SerializeField] private AudioSource _level3;
    [SerializeField] private AudioSource _win;
    [SerializeField] private AudioSource _lose;
    [SerializeField] private AudioSource _bell;
    [SerializeField] private AudioSource _finalBoss;

    public float getValueDamage;

    public int random;

    private int rM;

    public int scripted;

    public float _currentTime = 0;

    public bool _delivery;

    private bool _hasKnife;

    [SerializeField] float _startingTime;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rM = 3;
        scripted = 1;
        getValueDamage = 0;
        random = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _currentTime = _startingTime;
        _delivery = false;
        _level1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (_uiPanelWin.activeInHierarchy == true)
        {
            if (!_win.isPlaying)
            {
                _finalBoss.Stop();
                _level1.Stop();
                _level2.Stop();
                _level3.Stop();
                _win.Play();
            }
        }
        if (_uiPanelLose.activeInHierarchy == true)
        {
            if (!_lose.isPlaying)
            {
                _finalBoss.Stop();
                _level1.Stop();
                _level2.Stop();
                _level3.Stop();
                _lose.Play();
            }
        }
        if (Timesy.GetComponent<Timesy>().lastLife == true && Timesy.GetComponent<Timesy>().isAwake == true && _uiPanelLose.activeInHierarchy == false && _uiPanelWin.activeInHierarchy == false)
        {
            if (!_finalBoss.isPlaying)
            {  
                _level1.Stop();
                _level2.Stop();
                _level3.Stop();
                _lose.Stop();
                _finalBoss.Play();
            }
        }

        Pause();
        if (Timesy.GetComponent<Timesy>()._talk == true)
        {
            Player.GetComponent<PlayerMovement>().enabled = false;
        }
        GiveReceita();
        Delivery();
        
        if (_camera.GetComponent<PickUp>().fight == true && (_camera.GetComponent<PickUp>().heldObj == null))
        {
            _hasKnife = false;
            StartCoroutine(GiveKnife());
        }
    }

    bool Pause()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_uiPanelPause.activeInHierarchy == false)
                {
                    Time.timeScale = 0;
                    _uiPanelGameplay.SetActive(false);
                    _uiPanelPause.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    return true;
                }
            }
        }
        return true;
    }

    void Delivery()
    {
        if (_currentTime <= 0 && _delivery == false)
        {
            _camera.GetComponent<PickUp>().fight = true;
            Player.GetComponent<PlayerMovement>().enabled = false;
            if (_camera.GetComponent<PickUp>().heldObj != null && _camera.GetComponent<PickUp>().heldObj.name != ("faca (1)(Clone)"))
            {
                Destroy(_camera.GetComponent<PickUp>().heldObj);
            }
            Player.transform.position = Stop.transform.position;
            if (Timesy != null)
            {
                Timesy.GetComponent<Timesy>().isAwake = true;
            }
        }
        if (_currentTime > 0 && _delivery == false && Timesy.GetComponent<Timesy>()._talk == false && Timesy.GetComponent<Timesy>()._isback == false)
        {
            _currentTime -= 1 * Time.deltaTime;
            Timer.text = _currentTime.ToString("0");
        }
    }
    IEnumerator GiveKnife()
    {
        yield return new WaitForSeconds(1);
        if (!_hasKnife)
        {   
            GameObject knife1 = Instantiate(knife, new Vector3(0, 0, 0), knife.transform.rotation);
            _camera.GetComponent<PickUp>().PickUpObject(knife1);
            _hasKnife = true;
        } 
    }

    void GiveReceita()
    {
        if (random == 1)
        {
            Receita.text = ("To do:\r\n- Get eggs in the fridge\r\n- Put Eggs on Blender\r\n- Get a pan and put it on the stove\r\n- Get Scrambled Eggs from Blender\r\n- Put Scrambled Eggs on stove\r\n- Deliver Food");
        }
        if (random == 2)
        {
            Receita.text = ("To do:\r\n- Get Meat, Tomatoes and Pasta from Fridge\r\n- Blend Tomatoes\r\n- Cut Meat\r\n- Get a pot and put it on stove\r\n- Get Tomato Sauce and put it on pot\r\n- Get Meatballs and put it on pot\r\n- Put past on pot\r\n- Deliver Food");
        }
        if (random == 4)
        {
            Receita.text = ("To do:\r\n- Get Cheese, Tomatoes and Flour from Fridge\r\n- Blend Tomatoes\r\n- Roll Flour\r\n- Put Tomato Sauce on empty pizza\r\n- Put Cheese on pizza\r\n- Get Pizza and put it on the oven\r\n- Deliver Food");
        }
        if (random == 3)
        {
            Receita.text = ("To do:\r\n- Get Tomatoes and Lettuce from Fridge\r\n- Cut Tomatoes\r\n- Cut Lettuce\r\n- Deliver Food");
        }
    }

    void changeMusic()
    {
        if (rM == 1)
        {
            _level1.Stop();
            _level2.Play();
            _level3.Stop();
        }
        if (rM == 2)
        {
            _level2.Stop();
            _level3.Play();
            _level1.Stop();
        }
        if (rM == 3)
        {
            _level2.Stop();
            _level1.Play();
            _level3.Stop();
        }
    }

    public void ChangeReceita()
    {
        if (scripted >= 3)
        {
            _bell.Stop();
            _bell.Play();
            int randomM = Random.Range(1,4);
            while (randomM == rM)
            {
                randomM = Random.Range(1,4);
            }
            rM = random;
            changeMusic();
            getValueDamage += 5;
            _delivery = false;
            if (getValueDamage > 45)
            {
                if (getValueDamage % 10 != 0)
                {
                    _currentTime = 45 - (getValueDamage / 10) - (1/2);
                }
                if (getValueDamage % 10 == 0)
                {
                    _currentTime = 45 - (getValueDamage / 10);
                }
            }
            if (getValueDamage < 45)
            {
                _currentTime = 60;
            }
            int random2 = Random.Range(1, 5);
            while (random2 == random)
            {
                random2 = Random.Range(1, 5);
            }
            random = random2;
        }
        if (scripted == 2)
        {
            _bell.Stop();
            _bell.Play();
            _level2.Stop();
            _level3.Play();
            getValueDamage += 5;
            _delivery = false;
            _currentTime = 5;
            random = 4;
            scripted++;
        }
        if (scripted == 1)
        {
            _bell.Stop();
            _bell.Play();
            _level1.Stop();
            _level2.Play();
            getValueDamage += 5;
            _delivery = false;
            _currentTime = 80;
            random = 2;
            scripted++;
        }   
    }
}
