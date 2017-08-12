using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private DamageType type;
    
    public float force;

    [SerializeField]
    private float damagePts;

    [SerializeField]
    private float flightTime = 3F;

    private float elapsedTime;

    private Vector3 targetLocation;
    private Vector3 initialLocation;
    public Rigidbody rb;

    public DamageType Type
    {
        get
        {
            return type;
        }
    }

    public float DamagePts
    {
        get
        {
            return damagePts;
        }
    }

    public void Start()
    {
        Debug.Log(type);
        initialLocation = transform.position;
        rb.AddForce(transform.right * force*3, ForceMode.Impulse);
        rb.AddForce(transform.up * force, ForceMode.Impulse);
        if (GameController.Instance != null)
        {
            targetLocation = GameController.Instance.TargetLocation;
        }

        Invoke("AutoDestroy", 15F);
    }

    public void Update()
    {
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "barrier")
        {
            Debug.Log("me choque con: " + collision.gameObject.name);
            collision.gameObject.GetComponent<Barrier>().TakeDamage(this);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "base")
        {
            Debug.Log("me choque con: " + collision.gameObject.name);
            collision.gameObject.GetComponent<Base>().TakeDamage(this);
            Destroy(this.gameObject);
        }
    }
}