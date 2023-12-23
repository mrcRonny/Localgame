using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Example : NetworkBehaviour
{

    void Update()
    {
        if (isLocalPlayer)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 playerMovement = new Vector3(h, v, 0);
            transform.position = transform.position + playerMovement;
        }
    }
}
