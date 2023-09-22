using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 tailStartPosition;
    public Transform tailTransform;
    public Rigidbody tailRb;
    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    private void OnEnable()
    {
        SpeedBoost.OnPickUpEvent += Boost;
    }
    private void OnDisable()
    {
        SpeedBoost.OnPickUpEvent -= Boost;
    }
    private void Awake()
    {
        startPos = transform.position;
        tailStartPosition = tailTransform.position;
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.Acceleration);

        if (rb.position.y < -1f)
            FindAnyObjectByType<GameManager>().EndGame();
    }
    void Boost ()
    {
        forwardForce *= 3;
    }
}
