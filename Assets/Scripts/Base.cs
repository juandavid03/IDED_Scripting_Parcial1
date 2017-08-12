using UnityEngine;
using UnityEngine.UI;

public delegate void OnBaseDestroyed(Base thisBase);

public delegate void OnTurnFinished();

[RequireComponent(typeof(Collider))]
public class Base : MonoBehaviour
{
    public OnBaseDestroyed onBaseDestroyed;
    public OnTurnFinished onTurnFinished;

    [SerializeField]
    private float maxHP = 500F;

    [SerializeField]
    private Catapult catapult;

    [SerializeField]
    private RayBeam rayBeam;

    [SerializeField]
    private float currentHP;

    private bool canAttack;
    private bool defending;

    private int totalReparos = 2;



    public void EnableTurn()
    {
        enabled = true;
        canAttack = true;
    }

    public void AttackWithCatapult()
    {

        catapult.Fire();
    }

    public void AttackWithRay()
    {
        Debug.Log("Dispare el RASHOOO!");
        rayBeam.Fire();
    }

    public void Repair()
    {
        Debug.Log("me tengo q reparar");
        currentHP += maxHP * 0.25f;
        if (currentHP > maxHP)
            currentHP = maxHP;
        totalReparos--;
    }

    public void Defend()
    {
        Debug.Log("Used defend");
        defending = true;
    }

    public void TakeDamage(RayBeam ray)
    {
        {
            if (defending == false)
            {
                    currentHP -= ray.DamagePts;
             
            }
            else if (defending == true)
            {
                currentHP -= ray.DamagePts - ray.DamagePts*0.25f;

            }
            defending = false;
            }
        }

    public void TakeDamage(Projectile projectile)
    {
        if (defending == false)
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
        else if (defending == true)
        {
            if (projectile.Type == DamageType.Normal)
            {
                currentHP -= projectile.DamagePts - (projectile.DamagePts * 0.25f);
            }
            if (projectile.Type == DamageType.Medium)
            {
                currentHP -= projectile.DamagePts + (projectile.DamagePts * 0.05f) - (projectile.DamagePts * 0.25f);
            }
            if (projectile.Type == DamageType.Heavy)
            {
                currentHP -= projectile.DamagePts + (projectile.DamagePts * 0.1f) - (projectile.DamagePts * 0.25f);
            }

            defending = false;
        }
    }

    // Use this for initialization
    private void Start()
    {
        currentHP = maxHP;

        enabled = false;
        canAttack = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (canAttack)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                AttackWithCatapult();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                AttackWithRay();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (totalReparos > 0)
                {
                    Repair();

                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Defend();
            }
        }
    }
}