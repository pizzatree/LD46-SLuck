﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandling : MonoBehaviour
{
    [SerializeField]
    private float maxDistanceFromPlayer = 3f;

    Transform player => GameObject.FindGameObjectWithTag("Player").transform;
    
    private void Update()
    {
        var mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var offset = mousePos - (Vector2)player.position;
        transform.position = (Vector2)player.position + Vector2.ClampMagnitude(offset, maxDistanceFromPlayer);

        var angle = Mathf.Atan2(transform.position.y - player.position.y, transform.position.x - player.position.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}
