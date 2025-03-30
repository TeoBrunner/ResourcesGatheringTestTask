using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class CameraPointer : MonoBehaviour
{
    private InputManager inputManager;
    private Camera mainCamera;
    NavigationService navigationService;

    [Inject]
    private void Construct([Inject] InputManager inputManager,
                           [Inject(Id = "Main")] Camera mainCamera,
                           [Inject] NavigationService navigationService)
    {
        this.inputManager = inputManager;
        this.mainCamera = mainCamera;
        this.navigationService = navigationService;        
    }

    private void OnEnable()
    {
        inputManager.pointerPressed += HandleClick;
    }
    private void OnDisable()
    {
        inputManager.pointerPressed -= HandleClick;
    }

    private void HandleClick()
    {
        Vector2 mousePos = Pointer.current.position.ReadValue();
        Ray ray = mainCamera.ScreenPointToRay(mousePos);
        if(Physics.Raycast(ray, out var hit))
        {
            navigationService.SetDestination(hit.point);
        }
    }
}
