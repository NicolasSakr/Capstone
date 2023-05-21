using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public Animator animator;
    public float detectionDistance = 5.0f;
    public Transform target;

    private GameObject player;

    private void Start()
    {
        // Find the GameObject with the "Player" tag
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // Check if the player is close enough to trigger the animation
        if (Vector3.Distance(target.position, transform.position) <= 4f)
        {
            // Trigger the "opened_closed" animation
            animator.SetTrigger("opened_closed");
        }
    }
}


