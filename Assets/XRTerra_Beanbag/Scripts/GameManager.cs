using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public GameObject gameUI;

    public Button anchorBoard;
    void Awake()
    {
        
        base.Awake();
        
        //refer to 1:21:40 for why it is written this way
        ARController.OnARRunning.AddListener(ARListener);
    }

    public void ARListener(bool ar)
    {
        ScreenLog.Log("ARListener: " + ar);

        if (ar)
        {
            Place_Bord();
        }
        else
        {
            gameUI.SetActive(true);
        }
        ResetGame();
    }

    public void Place_Bord()
    {
        ScreenLog.Log("Placing Board");
        StartCoroutine(PlaceBoardRoutine());
    }

    private IEnumerator PlaceBoardRoutine()
    {
        gameUI.SetActive(false);

        yield return null;
        
        PlaceBoard.Instance.startPlacingBoard();

        while (PlaceBoard.Instance.isPlacing)
        {
            yield return null;
        }
        
        gameUI.SetActive(true);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame()
    {
        ScoreController.Instance.ResetScore();
    }
    
    
}
