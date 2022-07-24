using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform[] ShootPoints;

    [HideInInspector] public TankBase TankBase;

    public void Fire()
    {
        for (int i = 0; i < ShootPoints.Length; i++)
        {
            GameObject go =
                PoolService.Instance.GetPrefab(BulletPrefab, ShootPoints[i].position, ShootPoints[i].rotation);
            go.GetComponent<Bullet>().TankBase = TankBase;
        }
    }
}