public static class FlyWeightPointer
{
    public static readonly FlyWeight Asteroid = new FlyWeight
    {
        speed = 2,
        score = 10
    };
    public static readonly FlyWeight MiniAsteroid = new FlyWeight
    {
        speed = 1,
        score = 5
    };

}
