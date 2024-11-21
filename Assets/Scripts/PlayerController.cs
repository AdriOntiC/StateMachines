using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator; // Reference to the Animator component

    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();

        // Check if Animator exists to avoid null reference errors
        if (animator == null)
        {
            Debug.LogError("Animator component not found on this GameObject!");
        }
    }

    void Update()
    {
        // Check if the "P" key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePatrolling();
        }
    }

    void TogglePatrolling()
    {
        // Ensure the Animator component exists
        if (animator != null)
        {
            // Get the current value of the "Patrolling" bool
            bool isPatrolling = animator.GetBool("Patroling");

            // Set the "Patrolling" bool to its opposite value
            animator.SetBool("Patroling", !isPatrolling);

            Debug.Log($"Patroling set to: {!isPatrolling}");
        }
    }
}
