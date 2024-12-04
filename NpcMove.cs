using UnityEngine.AI;
using UnityEngine;

//NPC�̵� �ڵ�
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPCAi : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public PlayerMove playerMove;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        if (playerMove != null)
        {
            StartCoroutine(UpdatePath());
        }
        else
        {
            Debug.LogError("�÷��̾� ����");
        }
    }

    private IEnumerator UpdatePath()
    {
        float rndx = Random.Range(0, 100);
        float rndz = Random.Range(0, 100);
        Vector3 rndPlace = new Vector3(rndx, 0, rndz);
        while (true)
        {
            if (playerMove != null)
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(rndPlace);
            }
            else
            {
                navMeshAgent.isStopped = true;
            }
            yield return new WaitForSeconds(0.25f);
        }
    }
}