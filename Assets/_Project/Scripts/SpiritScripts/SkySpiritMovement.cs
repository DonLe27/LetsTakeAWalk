using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySpiritMovement : SpiritMovement
{
    private Vector3 currentDirection;
    protected void Wander()
    {
        Vector3 towardsOrigin = new Vector3(origin.position.x - transform.position.x, 0, origin.position.z - transform.position.z);
        Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-0.2f, 0.2f), Random.Range(-1f, 1f)); direction.Normalize();
        currentDirection += direction;
        currentDirection.Normalize();
        rb.velocity = currentDirection * speed;
    }
    override protected void Move()
    {
        Wander();
    }
}
