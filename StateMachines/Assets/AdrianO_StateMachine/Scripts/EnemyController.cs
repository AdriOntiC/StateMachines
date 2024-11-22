using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// EnemyController script, used to call different functions from the Animator states behaviours, and other possible future functions
public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    private Animator animator;
    [SerializeField] private TextMeshProUGUI stateDebugger;


    void Start()
    {
        instance = this;

        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on this GameObject!");
        }
    }

    void Update()
    {
        // Now implemented with UI toggle button

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     ToggleAnimatorBool("targetInSight");
        // }
    }

    // Function to set the bool to its opposite value (called from UI toggle)
    public void ToggleAnimatorBool(string boolParameter)
    {
        if (animator != null)
        {
            animator.SetBool(boolParameter, !animator.GetBool(boolParameter));

            Debug.Log($"{boolParameter} set to: {animator.GetBool(boolParameter)}");
        }
    }

    // Function to increase time with deltaTime (used for the state transitions, called on the behaviours)
    public void IncreaseWaitingTime(){
        animator.SetFloat("waitingTime", animator.GetFloat("waitingTime") + Time.deltaTime);
    }

    // Function to reset the time counter, so we can use it more than 1 time
    public void ResetWaitingTime(){
        animator.SetFloat("waitingTime", 0);
    }

    // Function to show on UI the current state from the animator
    public void DebugCurrentState(string state){
        stateDebugger.text = state;
    }

    // Additional info: I didn't need to use the isShooting or isPatrolling bools (may use them if the project "grows")
}
