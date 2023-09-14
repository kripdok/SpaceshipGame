using UnityEngine;

public static class EnemyRandomizer
{
    public static float SetFloat(float min, float max)
    {
        return Random.Range(min, max);
    }

    public static Vector3 SetScale(float minScale, float maxScale)
    {
        float scale = SetFloat(minScale, maxScale);
        Vector3 ConcreteScale = new Vector3();

        ConcreteScale.x = scale;
        ConcreteScale.y = scale;
        ConcreteScale.z = scale;

        return ConcreteScale;
    }
}