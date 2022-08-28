using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] ObstaclePrefab;
    public GameObject FirstPickUp;
    public GameObject StartOffset;
    public int MinObstacles;
    public int MaxObstacles;
    public float DistanceBetweenObstacles;
    public Transform FinishLine;
    public Transform Road;
    public float ExtraRoadScale;
    public GameMonitor Monitor;

    private void Awake()
    {
        int LevelIndex = Monitor.LevelIndex;
        Random random = new Random(LevelIndex);
        int obstaclesCount = RandomRange(random, MinObstacles, MaxObstacles + 1);
        for(int i = 0; i < obstaclesCount; i++)
        {
            int prefabIndex = RandomRange(random, 0, ObstaclePrefab.Length);
            GameObject obstaclePrefab = i == 0 ? StartOffset : i == 1 ? FirstPickUp: ObstaclePrefab[prefabIndex];
            GameObject obstacle = Instantiate(obstaclePrefab,transform);
            obstacle.transform.localPosition = CalculateObstaclePosition(i);
            
        }
        FinishLine.localPosition = CalculateObstaclePosition(obstaclesCount);

        Road.localScale = new Vector3(1.25f, 1, obstaclesCount * DistanceBetweenObstacles + ExtraRoadScale);
    }

    private Vector3 CalculateObstaclePosition(int obstacleindex)
    {
        return new Vector3(0,0.5f, DistanceBetweenObstacles * obstacleindex);
    }

    private int RandomRange(Random random, int min, int maxExclusive)
    {
        int number = random.Next();
        int length = maxExclusive - min;
        number %= length;
        return min + number;
    }

    private float RandomRange(Random random, float min, float max)
    {
        float t = (float)random.NextDouble();
        return Mathf.Lerp(min, max, t);
    }

}
