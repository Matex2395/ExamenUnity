using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public LayerMask destroyableObjectsLayer; // Capa para objetos
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Destruir el objeto enemigo
            Destroy(gameObject); // Destruir la bala
        }
        else if(other.CompareTag("Ground") || other.CompareTag("Player"))
        {
            Destroy(gameObject); // Destruir la bala
        }
    }
}
