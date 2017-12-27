using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
	public Waypoint next;

	void OnDrawGizmosSelected()
	{
		var waypoints = new HashSet<Waypoint>();

		// draw where we're going
		if (null == next)
		{
			Gizmos.color = Color.red;
		}
		else
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(transform.position, next.transform.position);
		}
		Gizmos.DrawWireSphere(transform.position, .14f);

		// now draw all the points in this path
		waypoints.Add(this);
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
