using UnityEngine;

public class AttachPlatform : MonoBehaviour
{
    Transform playerParent = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerParent = other.transform.parent;
            playerParent.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerParent.transform.parent = null;
        }
    }
}
