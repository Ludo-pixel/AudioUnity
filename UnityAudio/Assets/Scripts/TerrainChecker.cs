using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TerrainChecker : MonoBehaviour
{
    protected bool isWood = false;

    private void Start()
    {

    }

    private void Update()
    {
        
    }

    public String GetCurrentFootstepSound()
    {
        RaycastHit hit;
        float raycastDistance = 0.2f; 

        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Wood"))
            {
                isWood = true;
                return "Wood";
            }
        }

        isWood = false;
        return "Untagged";
    }
}
