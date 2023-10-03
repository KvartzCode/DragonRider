using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SheepStateManager : MonoBehaviour
{
    [SerializeField]
    public SheepBaseState currentState;
    public NavMeshAgent sheepAgent;

    public List<GameObject> sheepWaypoints = new List<GameObject>();

    public ChillState chillState = new ChillState();
    public PanicState panicState = new PanicState();
    public DyingState dyingState = new DyingState();
    public CruiseState cruiseState = new CruiseState();
    public RamboState ramboState = new RamboState();

    public int timesPissedOff;
    public int pissedOffTolerance = 2;
    public float timeToSuffer = 5;

    [SerializeField]
    private GameObject minigun;

    // Start is called before the first frame update
    void Start()
    {
        //if (GetComponentInChildren<Minigun>().transform.gameObject != null)
        sheepAgent = GetComponent<NavMeshAgent>();
        currentState = chillState;
        currentState.StartState(this);
        //Debug.Log(currentState.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTrigger(this, other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Fireball>())
        {
            currentState.OnCollision(this, collision);
            GetComponent<Sheep>().StartKillSheep();
        }
    }

    public void ChangeSheepState(SheepBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
        //Debug.Log(currentState.ToString());
    }
}
