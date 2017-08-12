using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField]
    private GameObject projectileToFire;

    [SerializeField]
    private Transform projectileSpawnTranform;

    public void Fire()
    {
        Instantiate(projectileToFire, projectileSpawnTranform);

    }
}