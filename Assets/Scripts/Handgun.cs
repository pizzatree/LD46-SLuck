﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgun : MonoBehaviour, iWeapon
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float inaccuracy = 0.3f,
                  coolDownTime = .2f,
                  shuntForce = 5f;

    public event Action OnFire = delegate { };

    private bool coolingDown = false;

    private Transform firepoint => transform.Find("Firepoint");

    public void Fire()
    {
        if(!coolingDown)
        {
            OnFire();
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        var shotRot = transform.rotation;
        shotRot.z += UnityEngine.Random.Range(-inaccuracy, inaccuracy);
        Instantiate(bullet, firepoint.position, shotRot);

        coolingDown = true;
        yield return new WaitForSeconds(coolDownTime);
        coolingDown = false;
    }
}