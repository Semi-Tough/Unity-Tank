using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        GameSystem.Instance.PauseGame();
        GameSystem.Instance.VictoryPanel.ShowPanel();
    }
}