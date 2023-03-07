using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy Controller : MonoBehaviour 
{

    public float : look radius = 10f;

    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;

    private BaseEnemyAnimator BaseEnemyAnimator;

    private float wander speed = 2f;
    public float normal speed;
    public int roamRadius = 70;

    void Start
    {
       target = PlayerManager.instance.player.transform;
       agent = GetComponent<NavMeshAgent>();
       combat = GetComponent<CharacterCombat>();
       normalSpeed = agent.speed;
       baseEnemyAnimator = GetComponent<BaseEnemyAnimator>();
    }

    void Update 
    {
       // Distance to target.

       float Distance = Vector3.Distance( target.position, transform.position);

       // if not inside look radius.

       if (Distance >= lookRadius)
       {
        agent.speed = wanderSpeed;
        baseEnemyAnimator.IsWandering();
       }

       // if inside the look radius.

       if (Distance <= lookRadius)
       {

        // Move towards the target.
        agent.SetDestination = (target.position);
        agent.speed = normalSpeed;
        baseEnemyAnimator.IsNotWandering();

        // if wit$$anonymous$$n attacking distance.

        if (Distance <= agent.stoppingDistance)
        {
            CharacterStats targetStats = target.GetComponent<CharacterStats>();

            if (targetStats != null)
            {
                combat.Attack(targetStats);
            }

            FaceTarget(); // This is to make sure enemy faces towards the target.
        }
       }
    }

    //Rotate to face the target.

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion.lookRotation = Quaternion.LookRotation( new Vector3 (direction.x, 0, direction.z));

        transform.rotation = Quaternion.Slerp( transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // This will show look radius in editor.

    void OnDrawGizomsSelected()
    {
        Gizmos.color = Color.red
        Gizmos.DrawWireSphere(transform.postion, lookRadius);
    }

} 