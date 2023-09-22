using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Invoker _invoker;
    private bool _isReplaying;
    private bool _isRecording;
    private PlayerMovement _playerMovement;
    private Command _buttonA, _buttonD;
    public bool gameHasEnded = false;
    public GameObject playerObject;

    public float restartDelay = 2f;

    public GameObject completeLevelUI;

    public void CompleteLevel () {
        completeLevelUI.SetActive(true);
    }

    public void EndGame () {
        _isRecording = false;
        _isReplaying = true;
        SpawnPlayer();
        _invoker.Replay();
    }

    public void SpawnPlayer()
    {
        if (_playerMovement != null)
            DestroyPlayer();
        _playerMovement = Instantiate(playerObject).GetComponentInChildren<PlayerMovement>();
        _invoker.playerMovement = _playerMovement;
        FindAnyObjectByType<Score>().player = _playerMovement.transform;
    }

    public void DestroyPlayer()
    {
        Destroy(_playerMovement.transform.parent.gameObject);
        _playerMovement = null;
        _invoker.playerMovement = null;
    }

    public void RestartLevel ()
    {
        Invoke("Restart", restartDelay);
    }

    void Restart () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Start()
    {
        _invoker = gameObject.AddComponent<Invoker>();
        SpawnPlayer();
        _buttonA = new MoveLeft(_playerMovement);
        _buttonD = new MoveRight(_playerMovement);
        _isRecording = true;
        _invoker.Record();
    }

    private void Update()
    {
        if (!_isReplaying && _isRecording)
        {
            if (Input.GetKey(KeyCode.A))
                _invoker.ExecuteCommand(_buttonA);
            if (Input.GetKey(KeyCode.D))
                _invoker.ExecuteCommand(_buttonD);
        }
    }
}
