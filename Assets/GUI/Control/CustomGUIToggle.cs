using UnityEngine;
using UnityEngine.Events;

public class CustomGUIToggle : CustomGUIControl
{
    public bool IsSel;
    private bool lastSel;
    public event UnityAction<bool> ChangeValue;

    protected override void StyleOnDraw()
    {
        IsSel = GUI.Toggle(CustomGUITransform.RectPos, IsSel, Content, Style);
        if (lastSel != IsSel)
        {
            ChangeValue?.Invoke(IsSel);
            lastSel = IsSel;
        }
    }

    protected override void StyleOffDraw()
    {
        IsSel = GUI.Toggle(CustomGUITransform.RectPos, IsSel, Content);
        if (lastSel != IsSel)
        {
            ChangeValue?.Invoke(IsSel);
            lastSel = IsSel;
        }
    }
}