using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float MoveSpeed;
    public int DefaultDamage;

    public GameObject ExplodePrefab;

    public TankBase TankBase;
    private int Damage => DefaultDamage + TankBase.Attack;


    private Rigidbody bulletRig;
    private TrailRenderer bulletTrail;

    private void Awake()
    {
        bulletRig = GetComponent<Rigidbody>();
        bulletTrail = GetComponentInChildren<TrailRenderer>();
    }

    private void OnEnable()
    {
        bulletRig.velocity = Vector3.zero;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * (MoveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (TankBase == null) return;
        if (other.CompareTag(TankBase.gameObject.tag)) return;
        gameObject.SetActive(false);

        if (other.TryGetComponent(out TankBase tank)) tank.Wound(Damage);

        if (!ExplodePrefab) return;
        GameObject go = PoolService.Instance.GetPrefab(ExplodePrefab, transform.position, transform.rotation);
        AudioSource audioSource = go.GetComponent<AudioSource>();
        AudioService.Instance.PlayEffectSound(audioSource);
    }

    private void OnDisable()
    {
        bulletTrail.Clear();
    }
}