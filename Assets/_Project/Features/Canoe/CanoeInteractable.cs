using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CanoeInteractable : NetworkBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float torque = 8;
    [SerializeField] private float rowForce = 2;
    [SerializeField] Transform boatTransform;
    [SyncVar]
    public int canoeCount = 0;
    [Server]
    public void RespondToInteraction(int delta)
    {
        canoeCount += delta;
    }


    public int GetCanoeCount()
    {
        return canoeCount;
    }
    float GetDragValue()
    {
        Vector3 dir = (-boatTransform.forward);
        float angle = Vector2.Angle(new Vector2(rb.velocity.x, rb.velocity.z), new Vector2(dir.x, dir.z));
        return -Mathf.Abs((angle - 90) / 90) + 1;
    }
    // Use NetworkTransform component to sync
    public void RowForward(GameObject player)
    {
        Vector3 dir = (-boatTransform.forward);
        rb.AddForce(dir.normalized * rowForce, ForceMode.VelocityChange);
        rb.drag = GetDragValue();
    }
    public void RowLeft(GameObject player)
    {
        float turn = Input.GetAxis("Horizontal");
        rb.AddRelativeTorque(0, torque, 0, ForceMode.Impulse);
        rb.drag = GetDragValue();
    }

    public void RowRight(GameObject player)
    {
        float turn = Input.GetAxis("Horizontal");
        rb.AddRelativeTorque(0, -torque, 0, ForceMode.Impulse);
        rb.drag = GetDragValue();
    }

    // Can also use ClientRpc to broadcast changes to clients
    /*
           [ClientRpc]
    private void RpcRespond(GameObject player)
    {
        Vector3 velocity = gameObject.transform.position - player.transform.position;
        GetComponent<Rigidbody>().AddForce(velocity.normalized, ForceMode.Impulse);
    }

    */
}
