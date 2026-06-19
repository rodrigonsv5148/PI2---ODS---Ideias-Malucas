using UnityEngine;

[System.Serializable]
public class Resolution
{
    [SerializeField]
    public int width;
    public int Width 
    {
        get { return width; }
    }

    [SerializeField]
    public int height;
    public int Height
    {
        get { return height; }
    }

    public Resolution (int _width, int _height)
    {
        width = _width;
        height = _height;
    }

    public override string ToString()
    {
        return $"{width}x{height}";
    }
}
