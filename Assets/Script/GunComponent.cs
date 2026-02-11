using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public float bulletMaxImpulse = 100.0f;
    public float maxChargeTime = 3.0f;

    private float chargeTime = 0.0f;
    private bool isCharging = false;

    void Update()
    {
       
        if (Input.GetButtonDown("Fire1"))
        {
            isCharging = true;
            chargeTime = 0.0f;
        }

       
        if (Input.GetButton("Fire1") && isCharging)
        {
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0.0f, maxChargeTime);
        }

       
        if (Input.GetButtonUp("Fire1") && isCharging)
        {
            ShootBullet();
            isCharging = false;
        }
    }

    void ShootBullet()
    {
        if (bulletPrefab == null || bulletSpawnPoint == null)
        {
            Debug.LogError("GunComponent missing bulletPrefab or bulletSpawnPoint assignment!");
            return;
        }

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Bullet prefab has no Rigidbody!");
            return;
        }

        
        float bulletImpulse = (chargeTime / maxChargeTime) * bulletMaxImpulse;

       
        bulletImpulse = Mathf.Max(bulletImpulse, bulletMaxImpulse * 0.1f);

        rb.AddForce(bulletSpawnPoint.forward * bulletImpulse, ForceMode.Impulse);
    }
}
