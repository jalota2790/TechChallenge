// <header>
// File Name : ToggleButton.cs
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
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent (typeof(Button))]
public class ToggleButton : MonoBehaviour
{
	#region Public/Inspector variables

	public Sprite stateOn;
	public Sprite stateOff;

	[Space]
	public UnityEvent OnClickEvent;

	#endregion

	#region Static and Private variables/Fields/Properties

	bool isOn = false;
	Image imageComponent;

	#endregion

	#region Private methods - Unity methods

	// Use this for initialization
	void Start ()
	{
		imageComponent = GetComponent<Image> ();
		GetComponent<Button> ().onClick.AddListener (OnClickFunction);
	}

	#endregion

	#region Public methods

	/// <summary>
	/// Alternates between On and Off states.
	/// </summary>
	public void OnClickFunction ()
	{
		isOn = !isOn;
		OnClickEvent.Invoke ();
		if (isOn) {
			imageComponent.sprite = stateOn;
		} else {
			imageComponent.sprite = stateOff;
		}
	}

	#endregion
}
