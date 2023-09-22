using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Invoker : MonoBehaviour
{
    private bool _isRecording;
    private bool _isReplaying;
    private float _replayTime;
    private float _recordingTime;
    public PlayerMovement playerMovement;
    public delegate void OnReplay();
    public static event OnReplay onReplay;
    private SortedList<float, Command> _recordedCommands = new();

    public void ExecuteCommand(Command command)
    {
        command.Execute();

        if (_isRecording && !_recordedCommands.ContainsKey(_recordingTime))
            _recordedCommands.Add(_recordingTime, command);
    }
    public void Record()
    {
        _recordingTime = 0f;
        _isRecording = true;
    }
    public void Replay()
    {
        _replayTime = 0f;
        _isReplaying = true;

        if (onReplay != null)
            onReplay();

        if (_recordedCommands.Count <= 0)
            Debug.LogError("No commands recorded");
        Obstacle[] obstacles = FindObjectsByType<Obstacle>(FindObjectsSortMode.None);
        foreach (Obstacle obstacle in obstacles)
        {
            obstacle.ResetLocation();
        }

        _recordedCommands.Reverse();
    }

    private void FixedUpdate()
    {
        if (_isRecording)
            _recordingTime += Time.fixedDeltaTime;
        if (_isReplaying)
        {
            _replayTime += Time.deltaTime;

            if (_recordedCommands.Any())
            {
                if (Mathf.Approximately(_replayTime, _recordedCommands.Keys[0]))
                {
                    _recordedCommands.Values[0].rb = playerMovement.rb;
                    _recordedCommands.Values[0].Execute();
                    _recordedCommands.RemoveAt(0);
                }
            }
            else
            {
                _isReplaying = false;
                FindFirstObjectByType<GameManager>().RestartLevel();
            }
        }
    }
}
