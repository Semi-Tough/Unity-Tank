using UnityEngine;

public enum EPropertyType
{
    Atk,
    Def,
    Hp
}

public class AddProperty : MonoBehaviour
{
    public EPropertyType PropertyType;
    public int AddValue;
    public GameObject ItemEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        gameObject.SetActive(false);

        GameObject go = PoolService.Instance.GetPrefab(ItemEffect, transform.position);
        AudioSource audioSource = go.GetComponent<AudioSource>();
        AudioService.Instance.PlayEffectSound(audioSource);
        
        Player player = other.GetComponent<Player>();
        switch (PropertyType)
        {
            case EPropertyType.Atk:
                player.Attack += AddValue;
                break;
            case EPropertyType.Def:
                player.Defense += AddValue;
                break;
            case EPropertyType.Hp:
                player.Hp += AddValue;
                GameSystem.Instance.GamePanel.UpdatePlayerHp(player.Hp, player.MaxHp);
                break;
        }
    }
}