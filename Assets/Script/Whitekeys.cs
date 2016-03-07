using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocketIO;
using System.Text.RegularExpressions;
using System;

public class Whitekeys : MonoBehaviour {

    private Renderer render;

    private AudioSource audioPlay;

    //private GameObject[] gameObjects;

    private SocketIOComponent socket;

    //public GameObject game;

	// Use this for initialization
	void Start () {
        render = GetComponent<Renderer>();

        audioPlay = GetComponent<AudioSource>();

        //gameObjects = GameObject.FindGameObjectsWithTag("white");

        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        //socket.On("open", OnSocketOpen);
        //socket.On("boop", Boop);
        socket.On("boop", Boop);
        //Debug.Log(gameObjects.Length);
        //Instantiate(game, new Vector3(0, 0, 0), transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKey(KeyCode.D))
        //{
        //    render.material.color = Color.gray;
        //}
        //int a = 0;
        //if (Input.GetKeyDown(KeyCode.A)) a = 1;
        //else if (Input.GetKeyDown(KeyCode.S)) a = 2;
        //else if (Input.GetKeyDown(KeyCode.D)) a = 3;
        //else if (Input.GetKeyDown(KeyCode.F)) a = 4;
        //else if (Input.GetKeyDown(KeyCode.G)) a = 5;
        //else if (Input.GetKeyDown(KeyCode.H)) a = 6;
        //else if (Input.GetKeyDown(KeyCode.J)) a = 7;
        //else if (Input.GetKeyDown(KeyCode.K)) a = 8;

        //switch (a)
        //{
        //    case 1: controller(gameObjects[a]); break;
        //    case 2: controller(gameObjects[a]); break;
        //    case 3: controller(gameObjects[a]); break;
        //    case 4: controller(gameObjects[a]); break;
        //    case 5: controller(gameObjects[a]); break;
        //    case 6: controller(gameObjects[a]); break;
        //    case 7: controller(gameObjects[a]); break;

        //}
	}

    void OnMouseDown()
    {
        render.material.color = Color.gray;
        audioPlay.Play();
        JSONObject json = new JSONObject("{\"name\":" + GetInstanceID() + "}");

        socket.Emit("login", json); 
    }

    void OnMouseUp()
    {
        render.material.color = Color.white;
    }

    public void Boop(SocketIOEvent e)
    {
        //int name = 0;
        //if (Int32.TryParse(e.data["name"].ToString(), out name))
        //{
        //    Debug.Log(name + "");
        //}
        int name = Int32.Parse(e.data["name"].ToString());
        int a = name + 30;
        Debug.Log(name + " " + a);
        
    }

    //public void OnSocketOpen(SocketIOEvent ev)
    //{
    //    Debug.Log("updated socket id " + socket.sid);
    //} 

    //private void controller(GameObject game)
    //{
    //    game.GetComponent<Renderer>().material.color = Color.gray;
    //}
}
