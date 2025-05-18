
using System.Runtime.InteropServices;

class Cylinder
{
    private Circle _circle;
    private double _height;

    public void sethight(double height)
    {
        _height = height;
    }

    public void setcircle(Circle circle)
    {
        _circle = circle;
    }

    public double getVolume()
    {
        return Math.PI * _circle.getRadius() * _circle.getRadius() * _height;
    }
}