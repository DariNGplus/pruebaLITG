using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public Camera cam;

    [SerializeField]
    private float interactionDistance = 3f;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private PlayerUI playerUI;

    public InputAction playerInteract;

    private void OnEnable()
    {
        playerInteract.Enable();
    }

    private void OnDisable()
    {
        playerInteract.Disable();
    }


        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        Debug.DrawRay(ray.origin, ray.direction * interactionDistance);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, interactionDistance, mask)) {
            if (hitInfo.collider.GetComponent<Interactable>() != null) {

                Interactable temp = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(temp.prompt);

                if (playerInteract.triggered) {
                    temp.BaseInteract();
                }
            }
        }
    }
}
