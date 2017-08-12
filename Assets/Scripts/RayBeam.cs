using UnityEngine;

public class RayBeam : MonoBehaviour
{
    private GameController gc;
    [SerializeField]
    private float damage;

    [SerializeField]
    private float rayDistance = 50F;

    public Vector3 targetLocation;
    private Vector3 targetDirection;

    private void Awake()
    {
        gc = GameObject.Find("Main Camera").GetComponent<GameController>();
        targetDirection = gc.targetDirection;
    }
    public float DamagePts
    {
        get
        {
            return damage;
        }
    }

    public void Fire()
    {
        RaycastHit hit;

        if (Physics.Raycast(targetLocation, targetDirection, out hit))
        {
            Debug.Log("le pegue a: " + hit.collider.name);
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, targetDirection);
    }
}