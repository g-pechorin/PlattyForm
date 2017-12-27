using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

	public Waypoint next;
	public float speed = 3.14f;

	void FixedUpdate()
	{
		Move(speed * Time.fixedDeltaTime);
	}

	private void Move(float fuel)
	{
		if (null == next)
			return;

		if (fuel == 0)
			return;

		// this could probably be ... prettier

		var todo = next.transform.position - transform.position;
		var length = todo.magnitude;

		if (0 == length)
		{
			next = next.next;
			Move(fuel);
		}

		// advance us
		transform.position = transform.position + todo.normalized * Mathf.Min(length, fuel);

		// continue
		fuel -= length;
		if (0 < fuel)
			Move(fuel - length);
	}


	void OnDrawGizmosSelected()
	{
		var waypoints = new HashSet<Waypoint>();

		// draw where we're going
		if (null == next)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, .14f);
			return;
		}

		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(transform.position, next.transform.position);

		// now draw all the points in this path
		waypoints.Add(next);
		bool done;
		do
		{
			done = true;
			foreach (var other in FindObjectsOfType<Waypoint>())
				if (waypoints.Contains(other.next))
					if (waypoints.Add(other))
					{
						done = false;
						Gizmos.color = Color.blue;
						Gizmos.DrawLine(other.transform.position, other.next.transform.position);
					}
		}
		while (!done);
	}
}
