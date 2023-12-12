using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBob : MonoBehaviour
{
    public GameObject bobCube;
    public GameObject temporaryBob;
    public GameObject spawnLocation;

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            temporaryBob = Instantiate(bobCube, spawnLocation.transform.position, spawnLocation.transform.rotation);

            Invoke(nameof(TurnOffObject), 5.0f); //1f is 1 sec

        }
    }
    public void TurnOffObject()
    {
        temporaryBob.SetActive(false);
    }
}
