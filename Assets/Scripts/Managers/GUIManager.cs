/* 13506593 - Jonathan Lee */
using UnityEngine;
using System.Collections.Generic;

/** Managers GUI elements for the game */
public class GUIManager : MonoBehaviour
{
	/** Singleton instance of GUIManager */
	public static GUIManager Instance { get; private set; }

	/** List of all GUIHandlers, application-wide */
	private List<GUIHandler> _guiHandlers;

	/** Ensure that only one instance of GUIManager shall exist */
	private void Awake() {
		if (Instance == null) {
			Instance = this;
			_guiHandlers = new List<GUIHandler>();
		}
		else {
			Destroy(gameObject);// Destroy further instances of GUIManager
		}
	}

	/*
	 * GUI Action Methods
	 */

	public void DisplayGameOverOverlay(GameHandler gameHandler) {

	}

}
