using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    private Animator animator; // Reference to the Animator component

    void Start()
    {
        instance = this;

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
        // Check if the "Space" key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleAnimatorBool("targetInSight");
        }
    }

    public void ToggleAnimatorBool(string boolParameter)
    {
        // Ensure the Animator component exists
        if (animator != null)
        {
            // Set the bool to its opposite value
            animator.SetBool(boolParameter, !animator.GetBool(boolParameter));

            Debug.Log($"{boolParameter} set to: {animator.GetBool(boolParameter)}");
        }
    }

    public void IncreaseWaitingTime(){
        animator.SetFloat("waitingTime", animator.GetFloat("waitingTime") + Time.deltaTime);
    }

    public void ResetWaitingTime(){
        animator.SetFloat("waitingTime", 0);
    }

    // public void TargetLost(){
    //     StartCoroutine(WaitAndCallFunction());
    // }

    // IEnumerator WaitAndCallFunction()
    // {
    //     // Wait for 5 seconds
    //     yield return new WaitForSeconds(5f);

    //     // Call the function
    //     SetAnimatorBool("isInvestigating", false);
    // }
}
