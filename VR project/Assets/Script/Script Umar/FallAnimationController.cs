
using UnityEngine;

public class FallAnimationController : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if(other.CompareTag("Player"))
            animator.SetTrigger("Fall");
    }
}
