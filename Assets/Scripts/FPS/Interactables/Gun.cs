using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Interactable
{

    public GameObject weaponLinked;

    [SerializeField]
    public Vector3 position;
    private PlayerMovement playerMovement;
    
    // Start is called before the first frame update
    void Start()
    {
       playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Interact()
    {

        if (weaponLinked != playerMovement.equippedOnHand)
        {
            foreach (Transform child in Camera.main.transform) {
                Destroy(child.gameObject);
            }

            playerMovement.WeaponChanged();

            GameObject newWeapon = Instantiate(weaponLinked);
            newWeapon.transform.SetParent(Camera.main.transform);
            newWeapon.transform.localPosition = position;
            newWeapon.transform.localRotation = Quaternion.identity;

            playerMovement.equippedOnHand = newWeapon;

            playerMovement.ResetWeapon();
        }
        else {
            Debug.Log("Same weapon");
        }
    }
}
