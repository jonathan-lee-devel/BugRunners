/* 13506593 - Jonathan Lee */
using UnityEngine;
using System.Collections.Generic;

/** Base class for GUI-handlers, intended to be one GUI-handler per GUI 'section', e.g. MainMenuGUIHandler, for all GUI related to main menu */
public abstract class GUIHandler : MonoBehaviour
{

	protected List<GUIElementHandler> _guiElementHandlers = new List<GUIElementHandler>();

	/** Add GUIElementHandler to list of GUIElementHandlers contained by this GUIHandler */
	public void AddGUIElementHandler(GUIElementHandler guiElementHandler) {
		_guiElementHandlers.Add(guiElementHandler);
	}

	/** Hide all GUIElementHandlers contained by this GUIHandler */
	public void HideAllGUIElements() {
		foreach (GUIElementHandler guiElementHandler in _guiElementHandlers) {
			guiElementHandler.HideElement();
		}
	}

	/** Show all GUIElementHandlers contained by this GUIHandler */
	public void ShowAllGUIElements() {
		foreach (GUIElementHandler guiElementHandler in _guiElementHandlers) {
			guiElementHandler.ShowElement();
		}
	}

}