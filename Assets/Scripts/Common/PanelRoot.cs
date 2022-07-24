using UnityEngine;

public class PanelRoot : MonoBehaviour
{
    public virtual void ShowPanel()
    {
        gameObject.SetActive(true);
    }

    public virtual void HidePanel()
    {
        gameObject.SetActive(false);
    }
}