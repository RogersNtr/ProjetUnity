using UnityEngine;
using Pathfinding;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class enemyAI : MonoBehaviour {

    public Transform target;
    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;

    public Path path;

    public float speed = 300f;
    public ForceMode2D fMode;

    public bool searchForPlayer = false;

    /***Variable Detection***/
    public float distanceDetect = 4f;

    [HideInInspector]
    public bool pathIsEnded = false;

    public float nextWaypointDistance = 3f;
    private int currentWaypoint = 0;

	// Use this for initialization
	void Start () {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if ( target == null)
        {
            if (!searchForPlayer)
            {
                searchForPlayer = true;
                StartCoroutine(SearchingForPlayer());
            }
            return;
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
	}
	
    public void OnPathComplete(Path p)
    {
        Debug.Log("We got a point. Did it have an error ?" + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    IEnumerator SearchingForPlayer()
    {
        GameObject sResult1 = GameObject.FindGameObjectWithTag("Player");
        GameObject sResult2 = GameObject.FindGameObjectWithTag("Player2");
        if (sResult1 == null && sResult2 == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SearchingForPlayer());
        }
        else if (sResult1 != null && sResult2 != null)
        {
            float sqrLen1 = (sResult1.transform.position - transform.position).sqrMagnitude;
            float sqrLen2 = (sResult2.transform.position - transform.position).sqrMagnitude;
            if (sqrLen1 < distanceDetect * distanceDetect)
            {
                target = sResult1.transform;
                searchForPlayer = false;
                StartCoroutine(UpdatePath());
            }
            else if (sqrLen2 < distanceDetect * distanceDetect)
            {
                target = sResult2.transform;
                searchForPlayer = false;
                StartCoroutine(UpdatePath());
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                StartCoroutine(SearchingForPlayer());
            }
            yield break;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SearchingForPlayer());
    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            if (!searchForPlayer)
            {
                searchForPlayer = true;
                StartCoroutine(SearchingForPlayer());
            }
            yield break;
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1/updateRate);
        StartCoroutine(UpdatePath());
    }
    // Update is called once per frame
    void FixedUpdate () {
        if (target == null)
        {
            if (!searchForPlayer)
            {
                searchForPlayer = true;
                StartCoroutine(SearchingForPlayer());
            }
            return;
        }
        if (path == null)
        {
            return ;
        }

         if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;
        }
        Debug.Log("End of path reached");
        pathIsEnded = true;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        rb.AddForce(dir, fMode);
        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }
}
