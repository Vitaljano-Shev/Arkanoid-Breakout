using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    [SerializeField] float speed;
    float moveX = 0f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float positionX = rigidbody2D.position.x + moveX * speed * Time.fixedDeltaTime;

        rigidbody2D.MovePosition(new Vector2(positionX, rigidbody2D.position.y));
    }
    private void OnEnable()
    {
        PlayerInput.OnMove += Move;
    }
    private void OnDisable()
    {
        PlayerInput.OnMove -= Move;
    }
    void Move(float xMove)
    {
        moveX = xMove;
    }
}
