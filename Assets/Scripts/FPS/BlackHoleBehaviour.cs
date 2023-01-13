using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleBehaviour : MonoBehaviour
{
    [SerializeField]
    public float intensity = 5f;

    public List<Rigidbody> attractees = new List<Rigidbody>();

    private Rigidbody ownRB;


    private void Start()
    {
        ownRB = GetComponent<Rigidbody>();
        Destroy(gameObject, 5);
    }

    public void Attract(Rigidbody objToAttract) {
        Vector3 direction = ownRB.position - objToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = intensity * (ownRB.mass * objToAttract.mass) / (distance * distance);
        Vector3 force = direction.normalized * forceMagnitude;

        objToAttract.AddForce(force); 
    }


    // Update is called once per frame
    void Update()
    {
        if (attractees.Count > 0) {
            foreach (Rigidbody objToAttract in attractees)
            {
                Physics.IgnoreCollision(GetComponent<Collider>(), objToAttract.gameObject.GetComponent<Collider>());
                Physics.IgnoreCollision(objToAttract.gameObject.GetComponent<Collider>(), GetComponent<Collider>());


                Attract(objToAttract);
            }
        }
     
    }
}
