using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject BulletOrigin; // Punto de inicio de la Instancia
    public GameObject BulletPrefab; // Prefab de la Bala
    public float BulletSpeed; // Velocidad de Bala

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Instanciar el Prefab de la Bala en BulletOrigin
            GameObject TempBullet = Instantiate(BulletPrefab, BulletOrigin.transform.position, BulletOrigin.transform.rotation) as GameObject;
            //Obtener Rigidbody para agregar fuerza
            Rigidbody rb = TempBullet.GetComponent<Rigidbody>();
            //Agregar fuerza a la bala
            rb.AddForce(transform.right * BulletSpeed);
            //Destruir bala después de un tiempo
            Destroy(TempBullet, 5.0f);
        }
    }

    
}
