using UnityEngine;

public class CustomGUIToggleGroup : MonoBehaviour
{
    public CustomGUIToggle[] Toggles;
    private CustomGUIToggle lasToggle;
    private void Start()
    {
        for (int i = 0; i < Toggles.Length; i++)
        {
            Toggles[0].IsSel = true;
            CustomGUIToggle toggle = Toggles[i];
            toggle.ChangeValue += (value) =>
            {
                if (value)
                {
                    lasToggle = toggle;
                    for (int j = 0; j < Toggles.Length; j++)
                    {
                        if (toggle != Toggles[j])
                        {
                            Toggles[j].IsSel = false;
                        }
                    }
                }
                else if( toggle==lasToggle)
                {
                    toggle.IsSel = true;
                }
            };
        }
    }
}