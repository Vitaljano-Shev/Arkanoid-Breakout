using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    string currentScheme;
    Vector2 movementPosition;
    Vector3 newPosition;
    SpriteRenderer spriteRenderer;

    float clampedX;
    const float borderPosition = 2.8f;

    [SerializeField] Camera mainCamera;
    [SerializeField] float playerSpeed;



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMove (InputValue inputValue)
    {
        movementPosition = inputValue.Get<Vector2>();
    }

    void Update()
    {
        currentScheme = GetComponent<PlayerInput>().currentControlScheme;
        switch (currentScheme)
        {
            case "Keyboard":

                clampedX = Mathf.Clamp(transform.position.x + movementPosition[0] * Time.deltaTime * playerSpeed, -borderPosition + (spriteRenderer.size.x / 2), borderPosition - (spriteRenderer.size.x / 2));
                transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
                break;

            case "Touch":

                newPosition = mainCamera.ScreenToWorldPoint(movementPosition);

                newPosition.y = transform.position.y;
                newPosition.z = transform.position.z;

                clampedX = Mathf.Clamp(newPosition.x, -borderPosition + (spriteRenderer.size.x/2), borderPosition - (spriteRenderer.size.x/2));
                transform.position = Vector3.MoveTowards(transform.position, new Vector2(clampedX,newPosition.y), Time.deltaTime * playerSpeed);

                break;
            default:
                Debug.LogError("Missing Scheme");
                break;
        }
    }
}
