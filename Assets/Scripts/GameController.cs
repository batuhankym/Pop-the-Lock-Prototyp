using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    
    [SerializeField] private Transform pivotPoint;
    [SerializeField] private GameObject ballPrefab, panelPrefab;

    [SerializeField] private TMP_Text countText;
    public TMP_Text scoreText;


  [SerializeField] private int _count = 3;
   [SerializeField] private Camera mainCam;

   
   void Start()
   {
       scoreText.text = ScoreManager.Instance._score.ToString();
        mainCam = Camera.main;

        countText.GetComponent<TMP_Text>();
        countText.text = _count.ToString();
        InstantiateBall();
    }

    void Update()
    {
        
    }


    public void InstantiateBall()
    {
        GameObject tempBall = Instantiate(ballPrefab);
        tempBall.transform.position = new Vector3(tempBall.transform.position.x, tempBall.transform.position.y, 0.62f);
        tempBall.transform.RotateAround(pivotPoint.position,Vector3.forward, Random.Range(0f,360f));
    }
    

    public void DecreaseCount(int amountToDecrease)
    {
        _count = _count -= amountToDecrease;
        countText.text = _count.ToString();
       
    }

  

    public void LoseCondition()
    {
        panelPrefab.SetActive(true);
    }

    
}
