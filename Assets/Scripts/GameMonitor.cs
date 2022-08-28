using UnityEngine;

public class GameMonitor : MonoBehaviour
{
    public SnakeMovementControls controls;
    private const string LevelIndexKey = "LevelIndex";

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
        Debug.Log("Dead");
 

    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        LevelIndex++;
        controls.enabled = false;
        Debug.Log("Won");
        

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
   
}
