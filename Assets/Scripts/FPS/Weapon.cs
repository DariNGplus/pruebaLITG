using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{

    public Transform spawnPoint;

    public GameObject bullet;

    public float shotForce = 1500f;
    public float shotRate = 0.5f;

    private float shotRateTime = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(InputAction.CallbackContext context) {
        if (Time.time > shotRateTime)
        {
            GameObject newBullet;

            newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

            shotRateTime = Time.time + shotRate;

            Debug.Log("Fired");
        }
        else {
            Debug.Log("Cooldown");
        }
    
    }

}
