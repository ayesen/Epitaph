using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectInspectorManagerScript : MonoBehaviour
{
    static public ObjectInspectorManagerScript me;
    public TMP_Text objectDes_ui;
	public GameObject textBg;
	private bool textShowing = false;

	private void Awake()
	{
		me = this;
	}

	public void ShowText(string content)
	{
		objectDes_ui.gameObject.SetActive(true);
		textBg.SetActive(true);
		objectDes_ui.text = content;
		PlayerScript.me.GetComponentInChildren<Animator>().Play("readingText");
		StartCoroutine(SetTextShowingToTrue());
	}

	private void Update()
	{
		if (textShowing)
		{
			if (Input.GetKeyDown(KeyCode.E)) // hide text
			{
				objectDes_ui.gameObject.SetActive(false);
				textBg.SetActive(false);
				objectDes_ui.text = "";
				textShowing = false;
				PlayerScript.me.GetComponentInChildren<Animator>().Play("testIdle");
			}
		}
	}

	IEnumerator SetTextShowingToTrue()
	{
		yield return new WaitForSeconds(0.1f);
		textShowing = true;
	}
}
