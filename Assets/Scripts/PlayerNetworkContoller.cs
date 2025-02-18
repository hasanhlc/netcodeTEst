using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetworkContoller : NetworkBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        if(!IsOwner) { return; }

        Vector3 moveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) moveDir.z = +1f;
        if (Input.GetKey(KeyCode.S)) moveDir.z = -1f;
        if (Input.GetKey(KeyCode.A)) moveDir.x = +1f;
        if (Input.GetKey(KeyCode.D)) moveDir.x = -1f;

        transform.position = moveDir * moveSpeed * Time.deltaTime;

    }
}
