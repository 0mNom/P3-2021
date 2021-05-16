using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;


[System.Serializable]
public class AIObjects
{
    public string AIGroupName { get { return m_aiGroupName; } }
    public GameObject objectPrefab { get { return m_prefab; } }
    public int maxAI { get { return m_maxAI; } }
    public int spawnRate { get { return m_spawnRate; } }
    public int spawnAmount { get { return m_maxSpawnAmount; } }
    public bool randomiseStats { get { return m_randomiseStats; } }
    public bool enableSpawner { get { return m_enableSpawner; } }


    [Header("AI Group Stats")]
    [SerializeField]
    private string m_aiGroupName;
    [SerializeField]
    private GameObject m_prefab;
    [SerializeField]
    [Range(0f, 30f)]
    private int m_maxAI;
    [SerializeField]
    [Range(0f, 10f)]
    private int m_spawnRate;
    [SerializeField]
    [Range(0f, 10f)]
    private int m_maxSpawnAmount;


    [Header("Main Settings")]
    [SerializeField]
    private bool m_randomiseStats;
    [SerializeField]
    private bool m_enableSpawner;

    public class AISpawScript : MonoBehaviour
    {
        public List<Transform> Waypoints = new List<Transform>();

        public float spawnTimer { get { return m_spawnTimer; } }
        public Vector3 spawsnArea { get { return m_SpawnArea; } }

        [Header("Global Stats")]
        [Range(0f, 600f)]
        [SerializeField]
        private float m_spawnTimer;
        [SerializeField]
        private Color m_SpawnColour = new Color(1.000f, 0.000f, 0.300f);
        [SerializeField]
        private Vector3 m_SpawnArea = new Vector3(20f, 10f, 20f);

        [Header("AI Group Settings")]
        public AIObjects[] AIObject = new AIObjects[5];

        void Start()
        {
            GetWayPoints();
            RandomiseGroups();
            CreateAIGroups();
            InvokeRepeating("SpawnNPC", 0.5f, spawnTimer);
        }

        // Update is called once per frame
        void Update()
        {

        }


        void SpawnNPC()
        {
            for (int i = 0; i < AIObject.Count(); i++)
            {
                if (AIObject[i].enableSpawner && AIObject[i].objectPrefab != null)
                {
                    GameObject tempGroup = GameObject.Find(AIObject[i].AIGroupName);
                    if (tempGroup.GetComponentInChildren<Transform>().childCount < AIObject[i].maxAI)
                    {
                        for (int y = 0; y < Random.Range(0, AIObject[i].spawnAmount); y++)
                        {
                            Quaternion randomRotation = Quaternion.Euler(Random.Range(-20, 20), Random.Range(0, 360), 0);
                            GameObject tempSpawn;
                            tempSpawn = Instantiate(AIObject[i].objectPrefab, RandomPosition(), randomRotation);
                            tempSpawn.transform.parent = tempGroup.transform;
                            tempSpawn.AddComponent<AI_Mover>();
                        }
                    }
                }
            }
        }


        public Vector3 RandomPosition()
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawsnArea.x, spawsnArea.x),
                Random.Range(-spawsnArea.y, spawsnArea.y),
                Random.Range(-spawsnArea.z, spawsnArea.z)
                );
            randomPosition = transform.TransformPoint(randomPosition * .5f);
            return randomPosition;

        }


        public Vector3 RandomWaypoint()
        {
            int randomWP = Random.Range(0, (Waypoints.Count - 1));
            Vector3 randomWaypoint = Waypoints[randomWP].transform.position;
            return randomWaypoint;
        }

        void RandomiseGroups()
        {
            for (int i = 0; i < AIObject.Count(); i++)
            {
                if (AIObject[i].randomiseStats)
                {
                  //  AIObject[i].setValues(Random.Range(1, 30), Random.Range(1, 20), Random.Range(1, 10));
                }
            }
        }

        void CreateAIGroups()
        {
            for (int i = 0; i < AIObject.Count(); i++)
            {
                GameObject AIGroupSpawn;

                if (AIObject[i].AIGroupName != null)
                {
                    AIGroupSpawn = new GameObject(AIObject[i].AIGroupName);
                    AIGroupSpawn.transform.parent = this.gameObject.transform;
                }
            }
        }

        void GetWayPoints()
        {
          /*  Transform[] wpList = transform.GetComponentInChildren<Transform>();

            for (int i = 0; i < wpList.Length; i++)
            {
                if (wpList[i].tag == "waypoint")
                {
                    Waypoints.Add(wpList[i]);
                }
            }*/
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = m_SpawnColour;
            Gizmos.DrawCube(transform.position, spawsnArea);
        }


    }


}

