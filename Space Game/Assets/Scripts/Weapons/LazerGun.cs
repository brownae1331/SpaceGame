using System;
using System.Collections;
using UnityEngine;


public class LazerGun : MonoBehaviour
{
    private LineRenderer lazer;
    public Transform lazerOrigin;
    public Camera fpsCam;
    public PauseManager pauseManager;

    public float maxRange = 100f;
    public float damage = 1f;

    private void Awake()
    {
        lazer = GetComponent<LineRenderer>();
        lazer.enabled = false;
    }

    private void Update()
    {
        if (!pauseManager.isPaused)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StopCoroutine("Shoot");
                StartCoroutine("Shoot");
            }
        }
    }

    IEnumerator Shoot()
    {
        lazer.enabled = true;

        while (Input.GetButton("Fire1"))
        {
            lazer.SetPosition(0, lazerOrigin.position);

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, maxRange))
            {
                lazer.SetPosition(1, hit.point);

                MineableTarget target = hit.collider.GetComponent<MineableTarget>();

                if (target != null) 
                {
                    target.TakeDamage();
                }
            }
            else
            {
                lazer.SetPosition(1, lazerOrigin.position + fpsCam.transform.forward * maxRange);
            }
            yield return null;
        }

        lazer.enabled = false;
    }
}
