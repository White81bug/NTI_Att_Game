using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMonitor : MonoBehaviour
{
    public SnakeMovementControls controls;
    private const string LevelIndexKey = "LevelIndex";

    public GameObject LossScreen;
    public GameObject WonScreen;
    public GameObject InGameUI;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        controls.enabled = false;
        InGameUI.SetActive(false);
        LossScreen.SetActive(true);
 

    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        LevelIndex++;
        controls.enabled = false;
        InGameUI.SetActive(false);
        WonScreen.SetActive(true);
        

    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
