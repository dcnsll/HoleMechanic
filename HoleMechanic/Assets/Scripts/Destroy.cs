using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private float value;


    private void Start()
    {
        value = 100f / GameObject.FindGameObjectsWithTag("Fallen").Length;
    }

    private void OnTriggerEnter(Collider other)

    {
        if (other.transform.gameObject.layer == LayerMask.NameToLayer("Fallen"))
        {
            Destroy(other.gameObject);

            slider.value += value;
        }
        //Add whatever you want to 
    }
}
