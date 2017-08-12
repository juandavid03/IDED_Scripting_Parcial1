using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Barrier : MonoBehaviour
{
    [SerializeField]
    private DamageType type;

    [SerializeField]
    private float maxHp = 2;

    [SerializeField]
    private float currentHP;

    public float CurrentHP
    {
        get
        {
            return currentHP;
        }

        set
        {
            currentHP = value;
        }
    }

    public void TakeDamage(RayBeam ray)
    {
        currentHP -= ray.DamagePts;
        Debug.Log("ME DAÑE WEY, por: " +ray.DamagePts);
    }

    public void TakeDamage(Projectile projectile)
    {
        if (projectile.Type == DamageType.Normal)
        {
            currentHP -= projectile.DamagePts;
        }
        if (projectile.Type == DamageType.Medium)
        {
            currentHP -= projectile.DamagePts + (projectile.DamagePts * 0.05f);
        }
        if (projectile.Type == DamageType.Heavy)
        {
            currentHP -= projectile.DamagePts + (projectile.DamagePts * 0.1f);
        }
        Debug.Log("ME DAÑE WEY, por: " + projectile.DamagePts);
    }

    // Use this for initialization
    private void Start()
    {
        currentHP = maxHp;
    }

    private void Update()
    {
        if (currentHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}