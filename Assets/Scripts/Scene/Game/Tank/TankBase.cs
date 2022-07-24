using UnityEngine;

public abstract class TankBase : MonoBehaviour
{
    public int Attack;
    public int Defense;
    public int Hp;

    public int MaxHp = 100;

    public float MoveSpeed;
    public float RotateSpeed;

    public Transform HeadTransform;
    public float HeadRotateSpeed;

    public GameObject DeathPrefab;


    public virtual void Start()
    {
        Hp = MaxHp;
    }

    public abstract void Fire();

    public virtual void Wound(int attack)
    {
        int damage = attack - Defense;

        if (damage <= 0) return;
        Hp -= damage;
        if (Hp <= 0)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        gameObject.SetActive(false);
        if (!DeathPrefab) return;
        GameObject go = PoolService.Instance.GetPrefab(DeathPrefab, transform.position);
        AudioSource audioSource = go.GetComponent<AudioSource>();
        AudioService.Instance.PlayEffectSound(audioSource);
    }
}