
using UnityEngine;


public class RespawnBehaviour : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        Respawn();
    }
    public void Respawn()
    {
        if (transform.position.y <= 33f)
        {
            transform.position = new Vector3(9.08f, 40.6f, 0f);
        }
    }
}
