using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpiritMovement : SpiritMovement
{
    protected void Spiral()
    {
        Vector3 towardsOrigin = new Vector3(origin.position.x - transform.position.x, 0, origin.position.z - transform.position.z);
        Vector3 direction = Vector3.Cross(towardsOrigin, Vector3.up);
        direction.Normalize();

        rb.velocity = direction * speed;
    }
    override protected void Move()
    {
        Spiral();
    }
}
