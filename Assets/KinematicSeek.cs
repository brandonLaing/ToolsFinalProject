﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSeek : MonoBehaviour
{

    public bool lookWhereYouAreGoing = true;
    public float moveSpeed = 1.0f;
    public Vector3 destination;
    public float radiusOfSatisfaction = 0.05f;

    private CharacterController characterController;
    public bool IsAtTarget { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target2d = new Vector3(destination.x, transform.position.y, destination.z);
        if (Vector3.Distance(target2d, transform.position) <= radiusOfSatisfaction)
        {
            IsAtTarget = true;
            return;
        }
        IsAtTarget = false;

        Vector3 moveDirection = (target2d - transform.position).normalized;
        Vector3 move = moveDirection * (moveSpeed * Time.deltaTime);
        characterController.Move(move);

        if (lookWhereYouAreGoing)
        {
            transform.LookAt(transform.position + move);
        }
    }
}
