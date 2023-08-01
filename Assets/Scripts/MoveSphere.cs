using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MoveSphere : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public float timeForNewPath;
    bool inCoRoutine;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Find a valid position on the NavMesh
        NavMeshHit hit;
        if (NavMesh.SamplePosition(transform.position, out hit, 1.0f, NavMesh.AllAreas))
        {
            // If a valid position was found, move the agent to that position
            navMeshAgent.Warp(hit.position);
        }
        else
        {
            Debug.LogError("No valid position on the NavMesh found close to the agent's starting position");
        }
    }

    void Update()
    {
        if (!inCoRoutine)
            StartCoroutine(DoSomething());
    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-20, 20);
        float y = Random.Range(-20, 20);

        Vector3 pos = new Vector3(x, y, 0);
        return pos;
    }

    IEnumerator DoSomething()
    {
        inCoRoutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        GetNewPath();
        inCoRoutine = false;
    }

    void GetNewPath()
    {
        navMeshAgent.SetDestination(getNewRandomPosition());
    }





}