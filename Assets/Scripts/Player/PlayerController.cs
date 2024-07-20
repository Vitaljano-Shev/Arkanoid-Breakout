using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    string currentScheme;
    Vector2 movementPosition;
    Vector3 newPosition;

    [SerializeField]Camera mainCamera;
    [SerializeField] float playerSpeed;

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
                transform.Translate(Vector3.right * movementPosition[0] * Time.deltaTime * playerSpeed);
                break;
            case "Touch":

                newPosition = mainCamera.ScreenToWorldPoint(movementPosition);

                newPosition.y = transform.position.y;
                newPosition.z = transform.position.z;

                transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * playerSpeed);

                break;
            default:
                Debug.LogError("Missing Scheme");
                break;
        }
    }
}
