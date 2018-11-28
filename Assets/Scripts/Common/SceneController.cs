// <header>
// File Name : SceneController.cs
// Purpose:  
// Created By  : Arun Jalota (arun@gameandapp.studio)
// Created On  : 23/11/2018
// Modified By : ------------
// Modified On : --/--/----
// Modification Note:  Improved code structure and format
// Other Notes:
// </header>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

	#region Public/Inspector variables

	/// <summary>
	/// The build index of main scene.
	/// </summary>
	public int mainSceneIndex;

	public static SceneController instance;

	[Space][Header ("User Story 3")]
	/// <summary>
	/// Bulbs array.
	/// </summary>
	public Item[] bulbs;

	[Space][Header("User Story 4")]
	public GameObject[] slots;

	#endregion

	#region Static and Private variables/Fields/Properties

	/// <summary>
	/// The index of the current light to change state for User Story 3 scene.
	/// </summary>
	int currentIndex;

	#endregion

	#region Private methods - Unity methods

	void Awake ()
	{
		instance = this;
	}

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	#endregion

	#region UI Button Delegates

	/// <summary>
	/// Button function to load scene, 
	/// parameter sceneBuildIndex is build index of scene to be loaded.
	/// </summary>
	public void LoadScene (int sceneBuildIndex)
	{
		SceneManager.LoadScene (sceneBuildIndex);
	}

	/// <summary>
	/// Gets back to main scene.
	/// </summary>
	public void BackToMainScene ()
	{
		SceneManager.LoadScene (mainSceneIndex);
	}

	#region User Story 3

	/// <summary>
	/// Switches the lights on one by one.
	/// </summary>
	public void OnLightButtonClick ()
	{
		if (currentIndex < bulbs.Length) {
			bulbs [currentIndex].ToggleState ();
			currentIndex++;
		}
	}

	#endregion

	#endregion
}
