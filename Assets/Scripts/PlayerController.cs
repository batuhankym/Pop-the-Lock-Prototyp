using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
   public LevelManagement _levelManagement;
    
    
    [SerializeField] private Transform pivotPoint;


    [SerializeField] private Animator shakeAnim;
    [SerializeField] private Animator winAnim;


    public GameController gameController;

    [SerializeField] private float playerAngleSpeed; 
    [SerializeField] private float currentBallCount = 0;
    [SerializeField] private float maxBallCount = 3;
    [SerializeField] private int decreaseCount = 1;



    private float _currentClick = 0f;
    private float _maxClick = 1f;

    private bool _isPlayerCollide;
    private bool _isGameStart = false;
    private bool _switchPlayer;
    private bool _isGameOver;
    private static readonly int İsWin = Animator.StringToHash("isWin");

    void Start()
    {

        winAnim.GetComponent<Animator>();
        shakeAnim.GetComponent<Animator>();
        gameController.GetComponent<GameController>();
        _levelManagement.GetComponent<LevelManagement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CountClick();
            if (_currentClick == _maxClick)
            {
                _isGameStart = true;

            }

            if (_isPlayerCollide)
            {
                _isGameStart = false;
                _switchPlayer = !_switchPlayer;

                _isPlayerCollide = false;
                DestroyBall();
                SpawnController();
                ScoreManager.Instance.IncreaseScore(10);

            }
            else
            {
                shakeAnim.SetTrigger("Shake");
                gameController.LoseCondition();
                playerAngleSpeed = 0;
                _isGameOver = true;
            }
            if (_isGameOver)
            {

                Invoke("RestartCurrentLevel",1f);
            }
        }
        
        if (_isGameStart)
        {
            MovePlayerForward();
        }
        else if(_switchPlayer)
        {
            MovePlayerBackward();
        }
        else
        {
            MovePlayerForward();
        }

      
        
       
    }


    


private void MovePlayerForward()
    {
        transform.RotateAround(pivotPoint.position, Vector3.forward, playerAngleSpeed * Time.deltaTime);

    }

    private void MovePlayerBackward()
    {
        transform.RotateAround(pivotPoint.position, Vector3.back, playerAngleSpeed * Time.deltaTime);

    }

    private void DestroyBall()
    {
        Destroy(GameObject.FindWithTag("Ball"));
        currentBallCount = currentBallCount + 1;
        gameController.DecreaseCount(decreaseCount);


    }

    private void SpawnController()
    {
        if (currentBallCount < maxBallCount)
        {
            gameController.InstantiateBall();

        }
        else
        {
            currentBallCount = 0;
            winAnim.SetTrigger("Win");
            playerAngleSpeed = 0;
            _levelManagement.Invoke(nameof(LevelManagement.WinCondition),1f);
            Debug.Log("You win!");
            
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {

            _isPlayerCollide = true;

        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        _isPlayerCollide = false;
    }

    private void CountClick()
    {
        _currentClick++;
        if (_currentClick >= _maxClick)
        {
            _currentClick = 2;
        }
    }

    private void RestartCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
   
}



