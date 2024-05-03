using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainChecker : MonoBehaviour
{
    [HideInInspector]
    public string terrainType;
    public bool isGrounded;
    public Color rayColor = Color.green;

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f))
        {
            if (hit.collider.CompareTag("Wood"))
            {
                terrainType = "Wood";
            }
            else
            {
                terrainType = "Concrete";
            }

            isGrounded = true;
        }
        else
        {
            terrainType = "None";
            isGrounded = false;
        }

        Debug.DrawRay(transform.position, Vector3.down * 1.0f, rayColor);
    }
}
