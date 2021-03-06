using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
	[Header("Move Object")]
	Rigidbody rb;
	public float flyAmount;
	public GameObject enemy;
	public float sinkSpd;
	public bool sink;

	[Header("Object Inspection")]
	public GameObject player;
	private Material defaultMat;
	public Material highLightMat;
	public float inspectionRange;
	private MeshRenderer mr;
	[TextArea]
	public string objectDescription;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		mr = GetComponent<MeshRenderer>();
		defaultMat = mr.material;
	}

	private void Update()
	{
		if (sink)
		{
			Sinking();
		}
		if (player != null && Vector3.Distance(player.transform.position, transform.position) < inspectionRange)
		{
			mr.material = highLightMat;
			if (Input.GetKeyDown(KeyCode.E) &&
				player.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).IsName("testIdle"))
			{
				ObjectInspectorManagerScript.me.ShowText(objectDescription);
			}
		}
		else
		{
			mr.material = defaultMat;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (enemy != null)
		{
			Vector3 dir = transform.position - enemy.transform.position;
			if (collision.gameObject.CompareTag("Enemy"))
			{
				rb.AddForce(dir.normalized * flyAmount, ForceMode.Impulse);
				StartCoroutine(StartSink());
			}
		}
	}

	IEnumerator StartSink()
	{
		yield return new WaitForSeconds(2);
		sink = true;
		GetComponent<Rigidbody>().isKinematic = true;
		GetComponent<BoxCollider>().enabled = false;
	}

	private void Sinking()
	{
		float y;
		y = transform.position.y - sinkSpd * Time.deltaTime;
		transform.position = new Vector3(transform.position.x, y, transform.position.z);
	}
}
