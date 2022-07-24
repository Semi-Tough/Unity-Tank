using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject CubeEffect;
    public GameObject[] RandomItem;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Bullet")) return;
        Destroy(gameObject);
        GameObject go = PoolService.Instance.GetPrefab(CubeEffect, transform.position);
        AudioSource audioSource = go.GetComponent<AudioSource>();
        AudioService.Instance.PlayEffectSound(audioSource);

        int num = Random.Range(0, 100);
        if (num < 50)
        {
            PoolService.Instance.GetPrefab(RandomItem[Random.Range(0, RandomItem.Length)], transform.position);
        }
    }
}