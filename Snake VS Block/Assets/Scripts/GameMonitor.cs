using UnityEngine;

public class GameMonitor : MonoBehaviour
{
    public SnakeController Controls;

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
        Controls.enabled = false;
 

    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        Controls.enabled = false;
    }
}
