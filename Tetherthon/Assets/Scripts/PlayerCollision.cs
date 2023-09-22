using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            //if (movement != null)
            //    movement.enabled = false;
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (!gameManager.gameHasEnded)
            {
                gameManager.gameHasEnded = true;
                gameManager.Invoke("EndGame", gameManager.restartDelay);
            }
        }
    }
}
