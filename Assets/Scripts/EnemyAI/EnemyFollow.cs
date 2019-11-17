using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
	float rot_x, rot_y, rot_z;
    void Update()
    {
		rot_x = transform.eulerAngles.x;
		rot_y = transform.eulerAngles.y;
		rot_z = transform.eulerAngles.z;
		transform.LookAt(LocalPlayer.Singleton.player.transform);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rot_z);
    }
}
