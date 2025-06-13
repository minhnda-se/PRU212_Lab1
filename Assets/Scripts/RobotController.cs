using UnityEngine;

public class RobotController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float changeDirectionTime = 5f;

    private Vector2 moveDirection;
    private float timer;

    void Start()
    {
        ChangeDirection(); // hướng random ban đầu
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        timer += Time.deltaTime;
        if (timer >= changeDirectionTime)
        {
            ChangeDirection();
            timer = 0f;
        }
    }

    public void ChangeDirection()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        moveDirection = new Vector2(x, y).normalized;
    }

    public void ChangeDirectionOnCollision()
    {
        if (Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y))
        {
            // Đang đi ngang (theo trục X) → chuyển sang đi theo trục Y
            float newY = Random.Range(-1f, 1f);
            moveDirection = new Vector2(-moveDirection.x, newY).normalized;
        }
        else
        {
            // Đang đi dọc (theo trục Y) → chuyển sang đi theo trục X
            float newX = Random.Range(-1f, 1f);
            moveDirection = new Vector2(newX, -moveDirection.y).normalized;
        }
    }
    public void IncreaseSpeed()
    {
        moveSpeed = Mathf.Min(moveSpeed + 1f, 20f);
        Debug.Log("Tăng tốc độ: " + moveSpeed);
    }


    public void DecreaseSpeed()
    {
        moveSpeed = Mathf.Max(0f, moveSpeed - 1f);
        Debug.Log("Giảm tốc độ: " + moveSpeed);
    }

    public void ReverseDirection()
    {
        Vector2 newDirection;

        if (Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y))
        {
           
            float signY = (Random.value > 0.5f) ? 1f : -1f;
            newDirection = new Vector2(-moveDirection.x, signY * Mathf.Abs(moveDirection.x));
        }
        else
        {
            
            float signX = (Random.value > 0.5f) ? 1f : -1f; 
            newDirection = new Vector2(signX * Mathf.Abs(moveDirection.y), -moveDirection.y);
        }

        moveDirection = newDirection.normalized;
    }


}
