﻿using UnityEngine;
using System.Collections;

public abstract class Attack : Mobile {

	string _myName = "Attack Not Identified";
	bool nameDeclared = false;
	public string myName {
		get { 
			if (!nameDeclared) {
				DeclareMyName();
			}
			return _myName;
		}
		set { _myName = value; }
	}

	public virtual void DeclareMyName () {
		nameDeclared = true;
	}

	protected virtual void Awake () {

	}

	// Use this for initialization
	protected virtual void Start () {
		Move ();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if (transform.position.x > 15.0f) {
			GameObject.Find("GameController").GetComponent<GameController>().RemoveFromList(gameObject);
			GameObject.Destroy(gameObject);
		}
	}

	protected virtual void Move() {
		rigidbody.velocity = new Vector3(5f,0,0);
	}

	protected virtual void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "Mobiles") {
			GameObject.Find("GameController").GetComponent<GameController>().RemoveFromList(collision.gameObject);
			Destroy (collision.gameObject);
		}
	}
}
