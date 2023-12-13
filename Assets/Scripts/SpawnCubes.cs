using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject[] spawnObject;
    private GameObject tempObject;
    public int selectedSpawnIndex = 0;
    private GameObject collidingObject;

    public AudioSource errorSound;
    public AudioSource placementSound;
    public AudioSource moveSound;
    public AudioSource deleteSound;
    public AudioSource changeSound;

    public bool isColliding;

    void Update()
    {
        MoveSpawnCube();
        SpawnAnObject();
        ChangeSpawnType();
        DeleteObject();
    }

    private void MoveSpawnCube()
    {
        //move forward
        if (Input.GetKeyDown(KeyCode.W) && transform.position.z < 4)
        {
            transform.Translate(new Vector3(0, 0, 1));
            moveSound.Play();
        }
        //move backward
        if (Input.GetKeyDown(KeyCode.S) && transform.position.z > -4)
        {
            transform.Translate(new Vector3(0, 0, -1));
            moveSound.Play();
        }
        //move right
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 4)
        {
            transform.Translate(new Vector3(1, 0, 0));
            moveSound.Play();
        }
        //move left
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -4)
        {
            transform.Translate(new Vector3(-1, 0, 0));
            moveSound.Play();
        }
        //move upwards
        if (Input.GetKeyDown(KeyCode.Q) && transform.position.y < 4)
        {
            transform.Translate(new Vector3(0, 1, 0));
            moveSound.Play();
        }
        //move downwards
        if (Input.GetKeyDown(KeyCode.E) && transform.position.y > 0)
        {
            transform.Translate(new Vector3(0, -1, 0));
            moveSound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            isColliding = true;
            collidingObject = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            isColliding = false;
            collidingObject = null;
        }
    }

    private void SpawnAnObject()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isColliding)
            {
                tempObject = Instantiate(spawnObject[selectedSpawnIndex], transform.position, transform.rotation);
                placementSound.Play();

            }
            else if (isColliding)
            {
                errorSound.Play();
            }
        }
    }

    
    private void ChangeSpawnType()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            changeSound.Play();
            iterateSpawnObjectIndex();
            updateSpawnCubeMaterial();
        }
    }
    private void updateSpawnCubeMaterial()
    {
        GetComponent<MeshRenderer>().sharedMaterial = spawnObject[selectedSpawnIndex].GetComponent<MeshRenderer>().sharedMaterial;
    }

    private void iterateSpawnObjectIndex()
    {
        selectedSpawnIndex = (selectedSpawnIndex + 1) % spawnObject.Length;
    }


private void DeleteObject()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (isColliding)
            {
                Destroy(collidingObject);
                isColliding = false;
                deleteSound.Play();
            }

            else if (!isColliding)
            {
                errorSound.Play();
            }
        }
    }


}