using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public int maxAmmo = 30;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzzleFlash;
    public GameObject impactEffect;
    public PauseManager pauseManager;

    private float nextTimeToFire = 0f;

    public Animator animator;

    public TextMeshProUGUI ammoText;

    private void Awake()
    {
        currentAmmo = maxAmmo;
    }

    void Start()
    {
        ammoText.gameObject.SetActive(true);
    }

    public void UpdateAmmoText()
    {
        if (ammoText != null)
        {
            ammoText.text = currentAmmo.ToString();
        }
    }

    public void SetAnimator() 
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }
     
    void Update()
    {
        if (!pauseManager.isPaused)
        {
            if (isReloading)
            {
                return;
            }

            if ((currentAmmo <= 0 || Input.GetKeyDown("r")) && currentAmmo != maxAmmo)
            {
                StartCoroutine(Reload());
                return;
            }

            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        muzzzleFlash.Play();

        currentAmmo--;
        UpdateAmmoText();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
        UpdateAmmoText();
    }
}
