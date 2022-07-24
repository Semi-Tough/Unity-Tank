using UnityEngine;

[ExecuteAlways]
public class CustomGUIRoot : MonoBehaviour
{
    private CustomGUIControl[] guiContents;

    private void OnGUI()
    {
        guiContents = GetComponentsInChildren<CustomGUIControl>();

        for (int i = 0; i < guiContents.Length; i++)
        {
            guiContents[i].DrawGUI();
        }
    }
}