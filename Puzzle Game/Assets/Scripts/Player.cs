using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{  

    [SerializeField] public KeyCode keyOne;
    [SerializeField] public KeyCode keyTwo;
    [SerializeField] public Vector3 moveDirection;
    private float speed = 0.75f;

    private void FixedUpdate()
    {
        if (Input.GetKey(keyOne)) GetComponent<Rigidbody>().velocity += moveDirection * speed;
        if (Input.GetKey(keyTwo)) GetComponent<Rigidbody>().velocity -= moveDirection * speed;
        if (Input.GetKey(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Input.GetKey(KeyCode.M)) SceneManager.LoadScene("Menu");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (this.CompareTag("Cube") && other.CompareTag("Cube"))
        {
            foreach(Activator button in FindObjectsOfType<Activator>())
            {
                button.canPush = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        foreach (Activator button in FindObjectsOfType<Activator>())
        {
            button.canPush = true;
        }
    }

}
