using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ClassGameScript : MonoBehaviour
{
    private GameObject clickToPlayText;
    private Bird bird;
    private GameObject losemenu;
    private PipeSpawner pipeSpawner;
    // Start is called before the first frame update
    void Start()
    {
        clickToPlayText = GameObject.Find("Canvas").transform.Find("ClickToPlay").gameObject;
        clickToPlayText.SetActive(true);
        bird = GameObject.Find("FlappyBird").GetComponent<Bird>();
        losemenu = GameObject.Find("Canvas1").transform.Find("LoseMenu").gameObject;
        losemenu.SetActive(false);
        pipeSpawner = GameObject.Find("PipeSpawner").GetComponent<PipeSpawner>();
    }

    private void FromClickToPlay()
    {
        bird.SetUpBird();
        clickToPlayText.SetActive(false);
        _currentGame = GameState.Playing;
    }

    private void updatePlaying()
    {
        bird.UpdateBird();
        pipeSpawner.UpdatePipeSpawner();
    }

    public void FromPlayToLose(int j)
    {
        _currentGame = GameState.Lostmenu;

        losemenu.SetActive(true);
    }

    public void Replay()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Quit()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private enum GameState
    {
        WaitingToClick,
        Playing,
        Lostmenu,
    }
    private GameState _currentGame = GameState.WaitingToClick;

    private void WaitingToClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FromClickToPlay();
        }
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        switch (_currentGame)
        {
            case GameState.WaitingToClick:
                WaitingToClick();
                break;
            
                break;
            case GameState.Lostmenu:
                break;
              
        }
    }
    
}
