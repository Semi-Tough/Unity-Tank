using System;
using UnityEngine;

public enum EAlignmentType
{
    Up,
    Down,
    Left,
    Right,
    Center,
    LeftUp,
    LeftDown,
    RightUp,
    RightDown
}

[Serializable]
public class CustomGUITransform
{
    public float Width = 100;
    public float Height = 50;

    public Vector2 Offset;
    public EAlignmentType ScreenAlignmentType = EAlignmentType.Center;
    public EAlignmentType ControlAlignmentType = EAlignmentType.Center;

    private Vector2 centerPos;
    private Rect rectPos = new(0, 0, 100, 50);

    public Rect RectPos
    {
        get
        {
            GetCenterPos();
            GetScreenPos();
            rectPos.width = Width;
            rectPos.height = Height;
            return rectPos;
        }
    }

    private void GetCenterPos()
    {
        switch (ControlAlignmentType)
        {
            case EAlignmentType.Up:
                centerPos.x = -Width / 2;
                centerPos.y = 0;
                break;
            case EAlignmentType.Down:
                centerPos.x = -Width / 2;
                centerPos.y = -Height;
                break;
            case EAlignmentType.Left:
                centerPos.x = 0;
                centerPos.y = -Height / 2;
                break;
            case EAlignmentType.Right:
                centerPos.x = -Width;
                centerPos.y = -Height / 2;
                break;
            case EAlignmentType.Center:
                centerPos.x = -Width / 2;
                centerPos.y = -Height / 2;
                break;
            case EAlignmentType.LeftUp:
                centerPos.x = 0;
                centerPos.y = 0;
                break;
            case EAlignmentType.LeftDown:
                centerPos.x = 0;
                centerPos.y = -Height;
                break;
            case EAlignmentType.RightUp:
                centerPos.x = -Width;
                centerPos.y = 0;
                break;
            case EAlignmentType.RightDown:
                centerPos.x = -Width;
                centerPos.y = -Height;
                break;
        }
    }

    private void GetScreenPos()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        switch (ScreenAlignmentType)
        {
            case EAlignmentType.Up:
                rectPos.x = screenWidth / 2 + centerPos.x + Offset.x;
                rectPos.y = 0 + centerPos.y + Offset.y;
                break;
            case EAlignmentType.Down:
                rectPos.x = screenWidth / 2 + centerPos.x + Offset.x;
                rectPos.y = screenHeight + centerPos.y + Offset.y;
                break;
            case EAlignmentType.Left:
                rectPos.x = 0 + centerPos.x + Offset.x;
                rectPos.y = screenHeight / 2 + centerPos.y + Offset.y;
                break;
            case EAlignmentType.Right:
                rectPos.x = screenWidth + centerPos.x + Offset.x;
                rectPos.y = screenHeight / 2 + centerPos.y + Offset.y;
                break;
            case EAlignmentType.Center:
                rectPos.x = screenWidth / 2 + centerPos.x + Offset.x;
                rectPos.y = screenHeight / 2 + centerPos.y + Offset.y;
                break;
            case EAlignmentType.LeftUp:
                rectPos.x = 0 + centerPos.x + Offset.x;
                rectPos.y = 0 + centerPos.y + Offset.y;
                break;
            case EAlignmentType.LeftDown:
                rectPos.x = 0 + centerPos.x + Offset.x;
                rectPos.y = screenHeight + centerPos.y + Offset.y;
                break;
            case EAlignmentType.RightUp:
                rectPos.x = screenWidth + centerPos.x + Offset.x;
                rectPos.y = 0 + centerPos.y + Offset.y;
                break;
            case EAlignmentType.RightDown:
                rectPos.x = screenWidth + centerPos.x + Offset.x;
                rectPos.y = screenHeight + centerPos.y + Offset.y;
                break;
        }
    }
}