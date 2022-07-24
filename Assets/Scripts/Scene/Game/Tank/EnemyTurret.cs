using UnityEngine;

public class EnemyTurret : TankBase
{
    public GameObject BulletPrefab;
    public Transform[] ShootPoints;
    private TankBase tankBase;

    public override void Start()
    {
        tankBase = this;
        InvokeRepeating(nameof(Fire), 2, 2);
    }

    public override void Fire()
    {
        for (int i = 0; i < ShootPoints.Length; i++)
        {
            GameObject go =
                PoolService.Instance.GetPrefab(BulletPrefab, ShootPoints[i].position, ShootPoints[i].rotation);
            go.GetComponent<Bullet>().TankBase = tankBase;
        }
    }

    public override void Wound(int attack)
    {
    }
}