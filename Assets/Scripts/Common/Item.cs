// <header>
// File Name : Item.cs
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

public class Item : MonoBehaviour
{

	#region Public/Inspector variables

	/// <summary>
	/// Specifies item's type
	/// </summary>
	public enum ItemType
	{
		Bulb,
		Door,
		Machine
	}

	public ItemType itemType;

	[Space]
	public AudioSource OnSound;
	public AudioSource OffSound;
		
	[Space][Header ("Door")]
	public GameObject stateOn;
	public GameObject stateOff;

	[Space][Header ("Bulb")]
	public Sprite s_StateOn;
	public Sprite s_StateOff;
	public Light pointLight;
	public AudioSource buzzSound;

	[Space][Header ("Machine")]
	public string animatorStartParameter;
	public string animatorStateParameter;

	public AudioSource startSound;
	public AudioSource stopSound;

	#endregion

	#region Static and Private variables/Fields/Properties

	bool isOn = false;
	SpriteRenderer spriteRenderer;

	Animator animator;

	#endregion

	#region Private methods - Unity methods

	// Use this for initialization
	void Start ()
	{
		switch (itemType) {
		case ItemType.Bulb:
			spriteRenderer = GetComponent<SpriteRenderer> ();
			break;

		case ItemType.Machine:
			animator = GetComponent<Animator> ();
			break;
		}
	}

	#endregion

	#region Public methods

	/// <summary>
	/// Alternates between On and Off states.
	/// </summary>
	public void ToggleState ()
	{
		isOn = !isOn;
		switch (itemType) {
		case ItemType.Bulb:
			pointLight.gameObject.SetActive (isOn);
			if (isOn) {
				OnSound.Play ();
				buzzSound.Play ();
				spriteRenderer.sprite = s_StateOn;
			} else {
				buzzSound.Stop ();
				OffSound.Play ();
				spriteRenderer.sprite = s_StateOff;
			}
			break;

		case ItemType.Door:
			((isOn == true) ? OnSound : OffSound).Play ();
			stateOn.SetActive (!stateOn.activeSelf);
			stateOff.SetActive (!stateOff.activeSelf);
			break;

		case ItemType.Machine:
			
			break;
		}
	}

	/// <summary>
	/// Triggers the action for single operation button.
	/// </summary>
	public void TriggerAction ()
	{
		switch (itemType) {
		case ItemType.Machine:
			StartCoroutine (triggerAction ());
			break;
		}
	}

	IEnumerator triggerAction ()
	{
		//Starts up down machine animation
		animator.SetTrigger (animatorStartParameter);
		startSound.Play ();
		yield return new WaitForSeconds (2);
		//Starts a random state
		int random = Random.Range (1, 4);
		animator.SetInteger (animatorStateParameter, random);
		yield return new WaitForSeconds (animator.GetCurrentAnimatorStateInfo (0).length + Time.deltaTime);
		startSound.Stop ();
		stopSound.Play ();
		yield return new WaitForSeconds (animator.GetCurrentAnimatorStateInfo (0).length);
		SceneController.instance.slots [random - 1].GetComponent<Image> ().color = Color.white;
		yield return new WaitForSeconds (1);
		SceneController.instance.LoadScene (random);
	}

	#endregion
}