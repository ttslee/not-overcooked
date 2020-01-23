using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public List<Transform> players;
    public float moveSpd = 1f;
    public float stoppingDistance;
    public bool isWandering = false;


    void Update()
    {
        if (players.Count == 0) return;
        if (isWandering)
        {
            Wander();
        }
        else Move();
    }

    void Wander()
    {
        Transform target = GetClosestTarget(players[0], players[1]);
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpd * Time.deltaTime);
        } //else shoot projectile or something
    }

    void Move()
    {
        Transform target = GetClosestTarget(players[0], players[1]);
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpd * Time.deltaTime);
        } //else shoot projectile or something
    }

    Transform GetClosestTarget(Transform object1, Transform object2)
    {
        float target1 = GetDistance(gameObject.transform, object1);
        float target2 = GetDistance(gameObject.transform, object2);
        if (target1 <= target2) return object1;
        else return object2;
    }

    float GetDistance(Transform object1, Transform object2)
    {
        return Vector3.Distance(object1.transform.position, object2.transform.position); ;
    }


}
