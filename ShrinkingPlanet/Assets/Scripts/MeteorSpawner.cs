using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingBytes;

public class MeteorSpawner : MonoBehaviour {

	public GameObject meteorPrefab;
	public float distance = 20f;

	public string poolName;
	public List<GameObject> goList = new List<GameObject>();

	void Start ()
	{
		StartCoroutine(SpawnMeteor());
	}

	IEnumerator SpawnMeteor()
	{
		Vector3 pos = Random.onUnitSphere * distance;
		// Instantiate(meteorPrefab, pos, Quaternion.identity);
		GameObject go = EasyObjectPool.instance.GetObjectFromPool(poolName,pos,Quaternion.identity);

		yield return new WaitForSeconds(2f);

		StartCoroutine(SpawnMeteor());
	}

	

}
