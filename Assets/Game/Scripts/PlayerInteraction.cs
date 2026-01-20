using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 3f;
    public LayerMask interactableLayer;
    public SubmarineController subController;

    void Update()
    {
        // Check for click (assuming 'Fire' or 'Interact' action in Input System)
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            DoInteract();
        }
    }

    void DoInteract()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange, interactableLayer))
        {
            // Check which button we hit by name or tag
            if (hit.collider.CompareTag("DropButton"))
            {
                subController.TriggerSuddenDrop(15f);
            }
            else if (hit.collider.CompareTag("StopButton"))
            {
                subController.ToggleEnginePause();
            }
        }
    }
}