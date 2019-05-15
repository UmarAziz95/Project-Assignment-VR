using UnityEngine;

public class ButtonInteractable : MonoBehaviour
{
    PlayerController controller;
    public Transform interactionPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Enter");
            controller = other.GetComponent<PlayerController>();
            controller.SetButtonTrigger(true);
            controller.SetTriggerPosition(interactionPoint.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Exit");
            controller.SetButtonTrigger(false);
            controller.SetTriggerPosition(Vector3.zero);
        }
    }
}
