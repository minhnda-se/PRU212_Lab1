using UnityEngine;

public class RobotCollision : MonoBehaviour
{
    
    [SerializeField] private int collisionThreshold = 5;
    private RobotController robotController;
    private int collisionCount = 0;

    void Start()
    {
        robotController = GetComponent<RobotController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Furniture"))
        {
            collisionCount += 1;
            Debug.Log("Va chạm với: " + collision.gameObject.name);
            Debug.Log("Count: " + collisionCount);
            if (collisionCount > collisionThreshold)
            {
                robotController.ReverseDirection();
                Debug.Log("Da chuyen huong nguoc liai");
                collisionCount = 0;
            }
            else
            {
                robotController.ChangeDirectionOnCollision();
            }
        }
    }
}
