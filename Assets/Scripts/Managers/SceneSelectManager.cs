/* 13506593 - Jonathan Lee */
using UnityEngine;
using UnityEngine.SceneManagement;

/** Manages transitions between scenes, providing safe & controlled access to Scene system */
public class SceneSelectManager : MonoBehaviour
{
	/** Singleton instnace of SceneSelectManager */
	public static SceneSelectManager Instance { get; private set; }

	/** Current scene which is to be displayed */
	private Scene _scene;

	/** Various scenes available to be used by the game */
	public enum Scene
	{
		LOADING,
		MAIN_MENU,
		DEV
	}

	/** Ensure that only one instnace of SceneSelectManager shall exist */
	private void Awake() {
		if (Instance == null) {
			Instance = this;
		}
		else {
			Destroy(gameObject);// Destory further instances of SceneSelectManager
		}
	}

	/** Performs appropriate actions required in order to change scene e.g. loading/unloading */
	public void UpdateScene(Scene scene) {
		switch (scene) {
			case Scene.LOADING:
				SceneManager.LoadScene("LoadingScene");
				break;
			case Scene.MAIN_MENU:
				SceneManager.LoadScene("MainMenu");
				break;
			case Scene.DEV:
				SceneManager.LoadScene("DevScene");
				break;
		}

		_scene = scene;
	}

}
