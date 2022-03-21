using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public GameObject[] firstGroup;
    public GameObject[] secondGroup;
    public Activator button;
    public Material normal;
    public Material transparent;
    public bool canPush;

    private void OnTriggerEnter(Collider other)
    {
        if (canPush)
        {
            if (other.CompareTag("Cube") || other.CompareTag("Player"))
            {
                foreach (GameObject first in firstGroup)
                {
                    first.GetComponent<Renderer>().material = transparent;
                    first.GetComponent<Collider>().isTrigger = true;
                }
                foreach (GameObject second in secondGroup)
                {
                    second.GetComponent<Renderer>().material = normal;
                    second.GetComponent<Collider>().isTrigger = false;
                }
                GetComponent<Renderer>().material = transparent;
                if (button != null)
                {
                    button.GetComponent<Renderer>().material = normal;
                    button.canPush = true;
                }                
            }
        }
    }
}
