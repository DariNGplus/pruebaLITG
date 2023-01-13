using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseView : MonoBehaviour
{
    public float mouseSensitivity = 1000f;

    public Transform player;

    public InputAction camMovementControl;

    public float xRotation = 0f;

    private void OnEnable()
    {
        camMovementControl.Enable();
    }

    private void OnDisable()
    {
        camMovementControl.Disable();

    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 camDirection = camMovementControl.ReadValue<Vector2>() * mouseSensitivity * Time.deltaTime;

        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= camDirection.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        player.Rotate(Vector3.up * camDirection.x);
    }
}
