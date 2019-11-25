/* 13506593 - Jonathan Lee */
using UnityEngine;

/** Base class for GUI-element-handlers, intended to be one GUI-element-handler per GUI 'item', e.g. MainMenuStartButtonHandler */
public abstract class GUIElementHandler : MonoBehaviour
{
	public abstract void HideElement();

	public abstract void ShowElement();
}
