using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class AgentPlayerController : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private GameObject playerParticle;
    public Vector3 startPos;
    //public Transform finish;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = movePositionTransform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Vector3 particleSpawnPos = transform.position + new Vector3(0, 2, 0);
            GameObject particle = Instantiate(playerParticle, particleSpawnPos, Quaternion.identity);
            transform.DOMove(startPos, 1f);
        }
        if (other.CompareTag("AgentFinish"))
        {
            transform.DOMove(movePositionTransform.position, 1f);
        }
    }
}
