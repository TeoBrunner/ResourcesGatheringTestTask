using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float interactCooldownTime = 1;
    private bool canInteract = true;

    private NavigationService navService;

    private NavMeshAgent navMeshAgent;
    private Animator animator;


    [Inject] 
    private void Construct([Inject] NavigationService navService)
    {
        this.navService = navService;
    }
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        navService.DestinationChanged += MoveTo;
    }
    private void OnDisable()
    {
        navService.DestinationChanged -= MoveTo;
    }
    private void FixedUpdate()
    {
        HandleAnimations();
    }
    private void MoveTo(Vector3 targetPos)
    {
        navMeshAgent.SetDestination(targetPos);
    }
    private void HandleAnimations()
    {
        bool isMoving = navMeshAgent.velocity.magnitude > 0.5f;
        animator.SetBool("Walk",isMoving);
    }

    private void OnTriggerStay(Collider other)
    {   
        if(!canInteract)
        {
            return;
        }

        if(other.TryGetComponent<IInteractable>(out var interactable))
        {
            print("aboba");
            interactable.Interact();
            animator.SetTrigger("Interact");
            StartCoroutine(CooldownInteract());
        }
    }

    private IEnumerator CooldownInteract()
    {
        canInteract = false;
        yield return new WaitForSeconds(interactCooldownTime);
        canInteract = true;
    }
}
