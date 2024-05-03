using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstepsSound, sprintSound, woodFootsteps, woodRunFootsteps;
    private TerrainChecker terrain;

    private void Start()
    {
        terrain = GetComponent<TerrainChecker>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            Debug.Log("Terrain Type: " +  terrain.terrainType);

            if(terrain.terrainType == "Concrete")
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    footstepsSound.enabled = false;
                    sprintSound.enabled = true;

                    woodFootsteps.enabled = false;
                    woodRunFootsteps.enabled = false;
                }
                else
                {
                    footstepsSound.enabled = true;
                    sprintSound.enabled = false;

                    woodFootsteps.enabled = false;
                    woodRunFootsteps.enabled = false;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    footstepsSound.enabled = false;
                    sprintSound.enabled = false;

                    woodFootsteps.enabled = false;
                    woodRunFootsteps.enabled = true;
                }
                else
                {
                    footstepsSound.enabled = false;
                    sprintSound.enabled = false;

                    woodFootsteps.enabled = true;
                    woodRunFootsteps.enabled = false;
                }
            }
        }
        else
        {
            woodRunFootsteps.enabled = false;
            woodFootsteps.enabled = false;
            footstepsSound.enabled = false;
            sprintSound.enabled = false;
        }
    }
}