using UnityEngine;
using Zenject;

public class CameraMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    private InputManager inputManager;
    private Camera mainCamera;

    [Inject]
    private void Construct([Inject] InputManager inputManager, 
                           [Inject(Id = "Main")]Camera mainCamera)
    {
        this.inputManager = inputManager;
        this.mainCamera = mainCamera;
    }

    private void OnEnable()
    {
        inputManager.pointerDragged += MoveCamera;
    }

    private void OnDisable()
    {
        inputManager.pointerDragged -= MoveCamera;
    }

    private void MoveCamera(Vector2 delta)
    {
        Vector3 relativeForward = mainCamera.transform.forward;
        relativeForward.y = 0;
        relativeForward = relativeForward.normalized;

        Vector3 relativeRight = mainCamera.transform.right;
        relativeRight.y = 0;
        relativeRight = relativeRight.normalized;



        mainCamera.transform.position -= relativeForward * delta.y * Time.fixedDeltaTime * moveSpeed;
        mainCamera.transform.position -= relativeRight * delta.x * Time.fixedDeltaTime * moveSpeed;

    }
}
