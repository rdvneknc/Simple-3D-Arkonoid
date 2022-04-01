using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject playerPrefab;

    public Text scoreText;
    public Text ballsText;
    public Text levelText;
    bool isSwitchingState;

    public GameObject panelMenu;
    public GameObject panelPlay;
    public GameObject panelLvlCompleted;
    public GameObject panelGameOver;

    public GameObject[] levels;

    GameObject currentBall;
    GameObject currentLevel;

    public static GameManager Instance{ get; private set; }

    public enum State {MENU, INIT, PLAY, LEVELCOMPLETED, LOADLEVEL, GAMEOVER}
    public State _state;

    private int _score;

    public int Score
    {
        get { return _score; }
        set { _score = value;
            scoreText.text = "SCORE: " + _score;
        }
        
    }

    private int _level;

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    private int _balls;

    public int Balls
    {
        get { return _balls; }
        set { _balls = value; }
    }




    public void PlayClicked()
    {
        SwitchState(State.INIT);
    }

    void Start()
    {
        Instance = this;
        SwitchState(State.MENU);
    }


    public void SwitchState (State newState, float delay = 0)
    {
        StartCoroutine(SwitchDelay(newState, delay));

    }

    IEnumerator SwitchDelay(State newState, float delay)
    {
        isSwitchingState = true;
        yield return new WaitForSeconds(delay);
        EndState();
        _state = newState;
        BeginState(newState);
        isSwitchingState = false;
    }

    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.MENU:
                panelMenu.SetActive(true);
                break;
            case State.INIT:
                panelPlay.SetActive(true);
                Score = 0;
                Level = 0;
                Balls = 3;
                Instantiate(playerPrefab);
                SwitchState(State.LOADLEVEL);
                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                panelLvlCompleted.SetActive(true);
                break;
            case State.LOADLEVEL:
                if(Level >= levels.Length)
                {
                    SwitchState(State.GAMEOVER);
                }
                else
                {
                    currentLevel = Instantiate(levels[Level]);
                    SwitchState(State.PLAY);
                }
                break;
            case State.GAMEOVER:
                panelGameOver.SetActive(true);
                break;
        }
    }

    void Update()
    {
        switch (_state)
        {
            case State.MENU:
                break;
            case State.INIT:
                break;
            case State.PLAY:
                if(currentBall == null)
                {
                    if(Balls > 0)
                    {
                        currentBall = Instantiate(ballPrefab);
                    }

                    else
                    {
                        SwitchState(State.GAMEOVER);
                    }
                }
                break;
            case State.LEVELCOMPLETED:
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                break;
        }
    }

    void EndState()
    {
        switch (_state)
        {
            case State.MENU:
                panelMenu.SetActive(false);
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                panelLvlCompleted.SetActive(false);
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                panelPlay.SetActive(false);
                panelGameOver.SetActive(false);
                break;
        }
    }

}
