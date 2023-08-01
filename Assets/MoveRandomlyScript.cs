using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandomlyScript : MonoBehaviour
{

    public float timer;
    public int newTarget;
    public float speed;
    public NavMeshAgent nav;
    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= newTarget)
        {
            newTargetMove();
            timer = 0;
        }
    }

    void newTargetMove()
    {
        float myX = gameObject.transform.position.x;
        float myY = gameObject.transform.position.y;

        float xPos = myX + Random.Range(myX = 100, myX + 100);
        float yPos = myY + Random.Range(myY - 100, myY + 100);

        target = new Vector3(xPos, yPos, gameObject.transform.position.z);

        nav.SetDestination(target);
    }
}
