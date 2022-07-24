using UnityEngine;

public enum EStyleType
{
    On,
    Off
}

public abstract class CustomGUIControl : MonoBehaviour
{
    public CustomGUITransform CustomGUITransform;
    public GUIContent Content;

    public EStyleType StyleType = EStyleType.Off;
    public GUIStyle Style;


    public void DrawGUI()
    {
        switch (StyleType)
        {
            case EStyleType.On:
                StyleOnDraw();
                break;
            case EStyleType.Off:
                StyleOffDraw();
                break;
        }
    }

    protected abstract void StyleOnDraw();

    protected abstract void StyleOffDraw();
}