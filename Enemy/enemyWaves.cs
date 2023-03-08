using UnityEngine;
using UnityEngine.Events;
using Systems.Collection


public class WaveSpawner : MonoBehaviour {

    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class WaveSpawner
    {
        public string name;
        public UnityEvent OnWaveEnd;
        public GameObject enemy;
        public int count;
        public float rate;
        public bool shouldWaitWaveClear = true;

    }

    public Wave[] waves;
    private int nextWave = 0;
    private int currentWave = 0;

    public int NextWave
    {
        get { return nextWave + 1; }
    }

    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;
    public UnityEvent OnWaveEnd;

    private float waveCountdown;
    public float waveCountdown
    {
        get { return waveCountdown; }
    }

    private float searchCountdown = 1f;

    private SpawnState state =SpawnState.COUNTING;
    public SpawnState state
    {
        get { return state; }
    }

    void Start()
    {
        if (spawnPoints.Length == 0)
        {
              Debug.LogError("No spawn points refrenced.");
        }
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (EnemyIsAlive() || !waves[currentWave].shouldWaitWaveClear)
            {
                WaveCompleted(waves[currentWave]);
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0 || nextWave == 0)
        {

            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine( SpawnWave (waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted(WaVE _wave)
    {
        Debug.Log("Wave Completed");
        _wave.OnWaveEnd.Invoke();

        state = SpawnState
    }
}