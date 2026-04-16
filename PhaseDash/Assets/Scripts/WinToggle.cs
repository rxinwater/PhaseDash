using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinToggle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    void Start()
    {

    }

    void Update()
    {
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Win")) //if tag is win, u win!
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Win condition met!");
            }
        }

    }

