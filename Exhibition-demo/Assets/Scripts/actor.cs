using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;

public class actor : MonoBehaviour
{
    //public Transform goal;
    public NavMeshAgent _agent;
    public float speed = 3f;
    public float waitTime = 0.5f;
    //public float waitTime2 = 10f;
    private float patroTimer = 0f;
    public int pointIndex = 0;
    private GameObject targets;
    public Transform fatherTar;
    
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        pointIndex =Random.Range(0, fatherTar.childCount - 1);
        //_agent.destination = goal.position;
        //targets = GameObject.FindWithTag("target");
        //fatherTar = targets.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Patrolling();
    }

    void Patrolling()
    {
        _agent.isStopped = false;
        _agent.speed = speed;
        if (_agent.remainingDistance < _agent.stoppingDistance)
        {
            //Debug.Log("------STOP!!!------");
            patroTimer += Time.deltaTime;
            //int flag = Random.Range(0, 4);
            
            if (patroTimer > waitTime)
            {
                pointIndex =Random.Range(0, fatherTar.childCount - 1);
                patroTimer = 0;
                waitTime = Random.Range(1, 30);
            }
        }
        else
        {
            patroTimer = 0;
        }

        _agent.destination = fatherTar.GetChild(pointIndex).position;
        
    }
}