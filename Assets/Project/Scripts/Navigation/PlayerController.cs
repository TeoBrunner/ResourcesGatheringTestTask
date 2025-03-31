using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    private NavigationService navService;

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
}
