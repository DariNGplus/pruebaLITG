using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputAction playerMovement;
    public InputAction playerFire;

    public float speed = 12f;

    public GameObject equippedOnHand;
    // Start is called before the first frame update
    private void OnEnable()
    {
        playerMovement.Enable();

        playerFire.Enable();
        ResetWeapon();
    }

    public void WeaponChanged() {

        if (equippedOnHand != null)
        {
            playerFire.performed -= equippedOnHand.GetComponent<Weapon>().Fire;
        }
    }

    public void ResetWeapon() {
        if (equippedOnHand != null) {
            playerFire.performed += equippedOnHand.GetComponent<Weapon>().Fire;
        }
    }

    private void OnDisable()
    {
        playerMovement.Disable();
        playerFire.Disable();

    }
    // Update is called once per frame
    void Update()
    {
        Vector2 input = playerMovement.ReadValue<Vector2>();

        Vector3 movement = new Vector3 (input.x, 0, input.y);

        movement = transform.right * movement.x + transform.forward * movement.z;

        GetComponent<CharacterController>().Move(movement * speed * Time.deltaTime);
    }
}
