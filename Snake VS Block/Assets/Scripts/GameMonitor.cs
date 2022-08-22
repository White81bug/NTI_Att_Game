using UnityEngine;

public class GameMonitor : MonoBehaviour
{
    public SnakeMovementControls controls;

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
 

    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        controls.enabled = false;

    }
}
