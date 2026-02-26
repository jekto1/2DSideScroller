using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement movement; // reference to your movement script

    void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(movement.GetHorizontalSpeed()));
        animator.SetBool("IsJumping", !movement.IsGrounded());
    }
}