using UnityEngine;

public class RandomWeapon : MonoBehaviour
{
    public int WeaponCount;
    public GameObject ItemEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        gameObject.SetActive(false);

        GameObject go = PoolService.Instance.GetPrefab(ItemEffect, transform.position);
        AudioSource audioSource = go.GetComponent<AudioSource>();
        AudioService.Instance.PlayEffectSound(audioSource);

        other.GetComponent<Player>().ChangeWeapon(Random.Range(0, WeaponCount));
    }
}