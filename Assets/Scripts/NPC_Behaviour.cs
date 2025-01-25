using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Behaviour : MonoBehaviour
{
    [SerializeField] private Vector3 destination;
    [SerializeField] private Transform path;
    [SerializeField] private int childrenIndex;
    [SerializeField] private Vector3 min, max;

    [SerializeField] private GameObject player;
    [SerializeField] private float PlayerDetectionDistance = 100f;
    [SerializeField] private bool playerDetected;
    [SerializeField] private float angleVision = 360;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // destination = path.GetChild(childrenIndex).position;
        //destination = RandomDestination();
        //GetComponent<NavMeshAgent>().SetDestination(destination);
        StartCoroutine(DistanceDetection());
    }

    // Update is called once per frame
    void Update()
    {

        //if (Vector3.Distance(transform.position, destination) < 1f)
        //{
        //    destination = RandomDestination();
        //    GetComponent<NavMeshAgent>().SetDestination(destination);
        //}
            

        //#region Mouse Button
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit = new RaycastHit();

        //    if (Physics.Raycast(ray, out hit, 1000))
        //    {
        //        GetComponent<NavMeshAgent>().SetDestination(hit.point);
        //    }
        //}
        //#endregion

        #region Patrol Movement

        //if(Vector3.Distance(transform.position, destination) < 1f)
        //{
        //    childrenIndex++;
        //    childrenIndex = childrenIndex % path.childCount;

        //    destination = path.GetChild(childrenIndex).position;
        //    GetComponent<NavMeshAgent>().SetDestination(destination);
        //}

        #endregion

        
    }

    #region RandomDestination

    Vector3 RandomDestination()
    {
        return new Vector3(Random.Range(min.x, max.x), 0, Random.Range(min.z, max.z));
    }
    #endregion

    #region Always Detect
    IEnumerator Follow()
    {
        while (true)
        {
            destination = player.transform.position;
            GetComponent<NavMeshAgent>().SetDestination(destination);
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(1);
        }
    }

    #endregion

    #region Distance Detection

    IEnumerator DistanceDetection()
    {
        while (true)
        {
            if(Vector3.Distance(transform.position, player.transform.position) < PlayerDetectionDistance)
            {
                Vector3 playerVector = player.transform.position - transform.position;
                if (Vector3.Angle(playerVector.normalized, transform.forward) < angleVision)
                {
                    playerDetected = true;
                    destination = player.transform.position;
                    GetComponent<NavMeshAgent>().SetDestination(destination);
                }
        
            } else
            {
                playerDetected= false;
                
            }
            yield return new WaitForSeconds(1);

        }
        
    }

    #endregion
}
