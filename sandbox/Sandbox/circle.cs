class Circle
{
    private double _radius;
    private double _area;
    private double _circumference;
    public double getRadius()
    {
        return _radius;
    }
    public double getArea()
    {
        return _area;
    }
    public double getCircumference()
    {
        return _circumference;
    }
    public void setRadius(double radius)
    {
        _radius = radius;
        _area = Math.PI * _radius * _radius;
        _circumference = 2 * Math.PI * _radius;
    }
}