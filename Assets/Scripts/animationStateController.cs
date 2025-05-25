using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetMouseButtonDown(0) && (CanAttackIdle() || CanAttackRunning())) // Attack on space bar
        {
            animator.SetTrigger("isAttacking");
        }

    }

    private bool CanAttackIdle()
    {
        // Check current animation state
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName("Idle");
    }

    private bool CanAttackRunning()
    {
        // Check current animation state
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName("Running");
    }
}
