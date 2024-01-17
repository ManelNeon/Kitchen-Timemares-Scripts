using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timesy : MonoBehaviour
{
    public bool isAwake;

    [SerializeField] private float speed;
    [SerializeField] private float maxhealth = 100;
    [SerializeField] public float currenthealth;
    [SerializeField] private GameObject spot1;
    [SerializeField] private GameObject spotog;
    [SerializeField] private GameObject spotTalk;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject GameDesign;
    [SerializeField] private GameObject bossSpot1;
    [SerializeField] private GameObject bossSpot2;
    [SerializeField] private GameObject bossSpot3;
    [SerializeField] private GameObject bossSpot4;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private GameObject _uiPanelInformation;
    [SerializeField] private GameObject _uiWin;
    [SerializeField] private GameObject _uiLose;
    [SerializeField] private GameObject _uiPlay;

    public bool lastLife;
    public bool _talk;
    private bool _walk;
    public bool _isback;

    bool has1 = false;
    bool has2 = false;
    bool has3 = false;
    bool has4 = false;

    void Start()
    {
        _talk = true;
        _walk = false;
        lastLife = false;
        isAwake = false;
        _isback = false;
        currenthealth = maxhealth;

        _healthBar.UpdateHealthBar(maxhealth,currenthealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAwake && lastLife)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, spotog.transform.position, speed * Time.deltaTime);
            _isback = false;
        }

        TalkScene();

        if (isAwake)
        {
            if (lastLife)
            {
                _camera.GetComponent<PickUp>().fight = true;
                if (!has1)
                {
                    bossFight();
                }
                if (has1 && !has2)
                {
                    bossFight2();
                }
                if (has2 && !has3)
                {
                    bossFight3();
                }
                if (has3 && !has4)
                {
                    bossFIght4();
                }
                if (has4)
                {
                    bossFight5();
                }
            }
            if (!lastLife)
            {
                GameDesign.GetComponent<DesignGame>().scripted = 4;
                GameDesign.GetComponent<DesignGame>()._currentTime = 60;
                
                currenthealth = maxhealth;
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, spot1.transform.position, speed * Time.deltaTime);
                if (this.gameObject.transform.position == spot1.transform.position)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    _uiPanel.SetActive(false);
                    _uiPanelInformation.SetActive(true);
                    Time.timeScale = 0;
                    isAwake = false;
                    lastLife = true;
                    _isback = true;
                    _camera.GetComponent<PickUp>().fight = false;
                    Player.GetComponent<PlayerMovement>().enabled = true;
                    GameDesign.GetComponent<DesignGame>().ChangeReceita();
                    Destroy(_camera.GetComponent<PickUp>().heldObj);
                }
            }
        }
    }
    void bossFight()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, bossSpot1.transform.position, speed * Time.deltaTime);
        if (this.gameObject.transform.position == bossSpot1.transform.position)
        {
            has1 = true;
        }
    }

    void bossFight2()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, bossSpot2.transform.position, speed * Time.deltaTime);
        if (this.gameObject.transform.position == bossSpot2.transform.position)
        {
            has2 = true;
        }
    }

    void bossFight3()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, bossSpot3.transform.position, speed * Time.deltaTime);
        if (this.gameObject.transform.position == bossSpot3.transform.position)
        {
            has3 = true;
        }
    }

    void bossFIght4()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, bossSpot4.transform.position, speed * Time.deltaTime);
        if (this.gameObject.transform.position == bossSpot4.transform.position)
        {
            has4 = true;
        }
    }

    void bossFight5()
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, spot1.transform.position, speed * Time.deltaTime);
        if (this.gameObject.transform.position == spot1.transform.position)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _uiPanel.SetActive(false);
            _uiLose.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void TalkScene()
    {
        if (_talk)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, spotTalk.transform.position, speed * Time.deltaTime);
            if (this.transform.position == spotTalk.transform.position)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                _uiPanel.SetActive(false);
                _uiPlay.SetActive(true);
                Time.timeScale = 0;
                _talk = false;
                Player.GetComponent<PlayerMovement>().enabled = true;
            }
        }
        if (!_talk && !_walk)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, spotog.transform.position, speed * Time.deltaTime);
        }
        if (!_talk && !_walk && this.transform.position == spotog.transform.position)
        {
            _walk = true;
        }
    }

    void Damage(float damage)
    {
        if ((currenthealth - damage) > 0)
        {
            currenthealth =  currenthealth - damage;
            _healthBar.UpdateHealthBar(maxhealth, currenthealth);
        }
        if ((currenthealth - damage) <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _uiPanel.SetActive(false);
            _uiWin.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == ("pickable"))
        {
            Debug.Log("DANO");
            Damage(GameDesign.GetComponent<DesignGame>().getValueDamage);
            Destroy(other.gameObject);
        }
    }
}
