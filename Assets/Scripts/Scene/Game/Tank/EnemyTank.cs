using UnityEngine;

public class EnemyTank : TankBase
{
    private Transform moveTarget;
    private Transform headTarget;
    private TankBase tankBase;

    public int Score;
    public float FireDis = 10;
    public float FireInterval = 2;
    public GameObject BulletPrefab;
    public Transform[] ShootPoints;
    public Transform[] RandomPos;

    private Rect maxHpRect;
    private Rect nowHpRect;

    private float temp;

    public override void Start()
    {
        base.Start();
        GetRandomPos();
        tankBase = this;
        headTarget = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(headTarget.position, transform.position) < FireDis)
        {
            TurnToTarget(HeadTransform, headTarget, HeadRotateSpeed);
            temp += Time.deltaTime;
            if (!(temp > FireInterval)) return;
            Fire();
            temp = 0;
        }
        else
        {
            TurnToTarget(transform, moveTarget, RotateSpeed);

            HeadTransform.localRotation = Quaternion.Slerp(HeadTransform.localRotation, Quaternion.identity,
                HeadRotateSpeed * Time.deltaTime);

            transform.Translate(Vector3.forward * (MoveSpeed * Time.deltaTime));
            if (Vector3.Distance(transform.position, moveTarget.position) < 0.5f) GetRandomPos();
        }
    }

    private void GetRandomPos()
    {
        moveTarget = RandomPos[Random.Range(0, RandomPos.Length)];
    }

    private void TurnToTarget(Transform current, Transform target, float rotateSpeed)
    {
        Quaternion rotate3 = Quaternion.LookRotation(target.position - current.position);
        current.rotation = Quaternion.Lerp(current.rotation, rotate3, rotateSpeed * Time.deltaTime);
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
        base.Wound(attack);
        GameSystem.Instance.GamePanel.TargetEnemy = transform;
        GameSystem.Instance.GamePanel.UpdateEnemyHp(Hp, MaxHp);
    }

    protected override void Death()
    {
        base.Death();
        GameSystem.Instance.UpdateScore(Score);
    }
}