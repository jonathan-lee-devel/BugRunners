/* 13506593 - Jonathan Lee */
using System.Collections.Generic;
using UnityEngine;

/**
 * NON-ORIGINAL CODE - See SOURCES.md
 * 
 * Manages resource loading for the game,
 * allows for more efficient use of system,
 * and hopefully smoother operation of the game
 */
public class ResourcePoolManager : MonoBehaviour
{
	/** Singleton instance of SceneSelectManager */
	public static ResourcePoolManager Instance { get; private set; }

	/**
	 * Each dictionary entry is indexed by Prefab name
	 * Each LinkedList contains spare objects of that type
	 */
	private static Dictionary<string, LinkedList<GameObject>> Pools = new Dictionary<string, LinkedList<GameObject>>();

	/**
	 * Ensure that only one instance of the ResourcePoolManager shall exist,
	 * any further instances will be destoryed
	 */
	private void Awake() {
		if (Instance == null) {
			Instance = this;
		}
		else {
			Destroy(gameObject);// Destory further instances of InputManager
		}
	}

	public static GameObject GetGameObject(string prefabName) {
		if (!Pools.ContainsKey(prefabName))
			Pools.Add(prefabName, new LinkedList<GameObject>());

		LinkedList<GameObject> pool = Pools[prefabName];

		GameObject go;
		if (pool.Count > 0) {
			go = pool.First.Value;
			go.SetActive(true);
			pool.RemoveFirst();
		}
		else {
			go = (GameObject)Instantiate(Resources.Load(prefabName));
			go.name = prefabName;// Gets rid of "(Clone)"
		}

		return go;
	}

	public static void ReturnGameObject(GameObject go) {
		if (!Pools.ContainsKey(go.name))
			Pools.Add(go.name, new LinkedList<GameObject>());

		LinkedList<GameObject> pool = Pools[go.name];

		pool.AddFirst(go);

		go.transform.position = Vector3.zero;

		if (go.transform.rotation.z != 0.0f)
			go.transform.rotation = Quaternion.identity;

		go.SetActive(false);
	}

}