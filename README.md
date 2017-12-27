
Based on [this tweet][ioUP], I spent ... 30 minutes? Maybe? putting together an example of moving platforms in Unity3D.

> This writeup took longer.

The approach here uses two behaviour classes to achive the classical effect of moving platforms that follow some path.

1. mark some empty [GameObject][u3dGO] as [`Waypoint`][ghWaypoint] instances
1. give each [`Waypoint`][ghWaypoint] a `next` field
1. attach a [`Mover`][ghMover] instance to your platform(s)
	- drag the platform towards the next [`Waypoint`][ghWaypoint] at a fixed rate
	- when you've reached the [`Waypoint`][ghWaypoint], continue with its next one

My example;

- uses the concept of `fuel` to avoid losing movement when fast moving platforms don't have far to travel
- provides some [`Gizmo`][u3dGizmos] logic to make looking at it easier

Normal Unity3D [Rigidbody][u3dRigid] instaces will impact with normal cubes - so if your platforms have a collider you're all set.
If you need-need [Rigidbody][u3dRigid] platforms; you can make them [`Kinematic`][u3dKinematic] to avoid weirdness.

The platform will stop when it reaches the "last" [`Waypoint`][ghWaypoint] so you could modify the [`Mover`][ghMover] to move backwards, or, just have the last platform point to the first platform and create a loop.

[ioUP]: https://twitter.com/g_pechorin/status/946058521182965762
[ghWaypoint]: https://github.com/g-pechorin/PlattyForm/blob/master/Assets/PlattyForm/Assets/Waypoint.cs
[ghMover]: https://github.com/g-pechorin/PlattyForm/blob/master/Assets/PlattyForm/Assets/Mover.cs
[u3dGO]: https://docs.unity3d.com/Manual/class-GameObject.html
[u3dGizmos]: https://docs.unity3d.com/ScriptReference/Gizmos.html
[u3dRigid]: https://docs.unity3d.com/ScriptReference/Rigidbody.html
[u3dKinematic]: https://docs.unity3d.com/ScriptReference/Rigidbody-isKinematic.html
