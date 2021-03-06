using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    private UIManager UImanager;
    private ManagerController managerCon;

    private float _speed = 5.0f;
    private float _gravity = -1f;
    private float _heightJump = 20.0f;
    private float _yVel = 0.0f;
    private bool _doubleJump = true;

    private int _coinNumber;
    private int _lives = 3;
    [SerializeField]
    private GameObject respawnPoint;

    // Start is called before the first frame update
    void Start()
    {

        _controller = GetComponent<CharacterController>();

        UImanager = GameObject.Find("UIManager").GetComponent<UIManager>();

        if (UImanager == null)
        {
            Debug.LogError("UImanager:: is NULL");
        }

        managerCon = GameObject.Find("ManagerController").GetComponent<ManagerController>();

        if (managerCon == null)
        {
            Debug.LogError("managerCon:: is NULL");
        }

        UImanager.UpdateCoinsText(_coinNumber);
        UImanager.UpdateLivesText(_lives);

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector3 MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 Velocity = MoveDir * _speed;


        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yVel = _heightJump;
                _doubleJump = true;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) & _doubleJump)
            {
                _yVel = _heightJump;
                _doubleJump = false;
            }

            _yVel += _gravity;
        }

        Velocity.y = _yVel;
        _controller.Move(Velocity * Time.deltaTime);
    }

    public void CoinCollected(int coin)
    {
        _coinNumber += coin;
        UImanager.UpdateCoinsText(_coinNumber);
    }

    public void LivesManager()
    {
        _lives--;        
        UImanager.UpdateLivesText(_lives);

        if(_lives <= 0)
        {
            managerCon.RestartGame();
        }

        _controller.enabled = false;
        transform.position = respawnPoint.transform.position;

        StartCoroutine(RespawnCoroutine());
    }

    IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        _controller.enabled = true;
    }

}
