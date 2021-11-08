using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollison : MonoBehaviour
{
    public SignalSent Signal;
    public GameObject parentObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Signal.Raise();
            parentObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Limit"))
        {
            parentObject.SetActive(false);
        }
    }
}
