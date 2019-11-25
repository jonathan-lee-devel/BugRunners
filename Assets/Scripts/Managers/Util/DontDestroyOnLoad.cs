/* 13506593 - Jonathan Lee */
using UnityEngine;

/**
 * NON-ORIGINAL CODE - See SOURCES.md
 * 
 * Ensures persistence of GameObject to which the script is attached,
 * intended to be attached to __app GameObject in _preload Scene,
 * allows easier setup of all required singletons such as GameManager
 */
public class DontDestroyOnLoad : MonoBehaviour
{
	private void Awake() {
		DontDestroyOnLoad(gameObject);
	}
}