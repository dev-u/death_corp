﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{

    #region Variables

    private Animator animator;

    [Header("Earth Configuration")]

    [Range(1, 240)]
    [SerializeField]
    private int periodSeconds = 120;

    [Space(5)]
    [Header("Earth Info")]
    [SerializeField]
    private float population = 0;

    public float Population {
        get {
            return population;
        }

        set {
            population = value;
        }
    }

    #endregion

    void Awake()
    {
        // Tells Singleton GameManager that I'm the main Earth instance  
        GameManager.earthInstance = this;
    }
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        FloatingPopupController.Initialize();
    }

    #region Mouse Inputs

    private void OnMouseEnter()
    {
        if (animator)
        {
            animator.SetBool("MouseEnter", true);
        }
    }

    private void OnMouseExit()
    {
        if (animator)
        {
            animator.SetBool("MouseEnter", false);
        }
    }

    private void OnMouseUp()
    {
        GameManager.gameControllerInstance.CollectSouls();

        if (animator)
        {
            animator.SetBool("MouseDown", false);
        }
        GameManager.mousePointerInstance.Click();
    }
    private void OnMouseDown()
    {
        if (animator)
        {
            animator.SetBool("MouseDown", true);
        }
    }

    #endregion

    private void Rotate()
    {
        float rpm = (60f / periodSeconds);
        float rotationAngle = 6f * rpm * Time.deltaTime;

        transform.Rotate(Vector3.forward, rotationAngle);
    }

    private void Update()
    {
        Rotate();
    }
}
