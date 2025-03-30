using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class NavigationAgent : MonoBehaviour
{
    private NavMeshAgent meshAgent;
    private NavigationService navService;

    [Inject] 
    private void Construct([Inject] NavigationService navService)
    {
        this.navService = navService;
    }
    private void Awake()
    {
        meshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        navService.DestinationChanged += MoveTo;
    }
    private void OnDisable()
    {
        navService.DestinationChanged -= MoveTo;
    }

    private void MoveTo(Vector3 targetPos)
    {
        meshAgent.SetDestination(targetPos);
    }
}
