using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingBytes;

public class Meteor : FauxGravityBody {

	// public GameObject explosion;

	public SphereCollider sphereCol;
	public ParticleSystem trail;

	private string poolName = "CraterPool";
	List<GameObject> goList = new List<GameObject>();

	void OnCollisionEnter(Collision col)
	{
		Quaternion rot = Quaternion.LookRotation(transform.position.normalized);
		rot *= Quaternion.Euler(90f, 0f, 0f);
		// Instantiate(explosion, col.contacts[0].point, rot);
		GameObject go = EasyObjectPool.instance.GetObjectFromPool(poolName,col.contacts[0].point,rot);
		sphereCol.enabled = false;
		trail.Stop(true, ParticleSystemStopBehavior.StopEmitting);

		this.enabled = false;
		GetComponent<AudioSource>().Stop();

		// Destroy(gameObject, 4f);
		StartCoroutine(ReturnSelfToPool());
	}

	IEnumerator ReturnSelfToPool()
	{
		yield return new WaitForSeconds(3f);
		EasyObjectPool.instance.ReturnObjectToPool(gameObject);
	}

}
