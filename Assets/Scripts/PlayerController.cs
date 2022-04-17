using System;
using System.Diagnostics;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //private Rigidbody rigidbody;

    private string resultScene = "ResultsScene";
    private string hometScene = "MainScene";
    private float horizontal = 0f;
    private float vertical = 0f;
    public float speed = 2f; 
    string fileName = "result.json";

    Stopwatch watch = new Stopwatch();
    SceneChanger newScene = new SceneChanger();

    void Start() {
        //rigidbody = GetComponent<Rigidbody>();
        
        watch.Start();
    }

    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate() {

        Vector3 move = new Vector3(horizontal, 0.0f, vertical);

        transform.position += move * speed * Time.fixedDeltaTime;
        // rigidbody.velocity = new Vector3(horizontal * speed * Time.fixedDeltaTime, 0.0f, rigidbody.velocity.y * speed * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.Escape)) {
            newScene.ChangeScene(hometScene);
        }

    }

    private void Finish() {
        watch.Stop();
        TimeSpan ts = watch.Elapsed;
        SaveResult saveResult = new SaveResult();        
        saveResult.AddNewResult(fileName, ts);
        GameState.State = GameState.States.Pass;
    }

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Finish")) {
            Finish();
        }

        if (other.CompareTag("Faild")) {
            UnityEngine.Debug.Log("Faild");
            GameState.State = GameState.States.Faild;
        }
        newScene.ChangeScene(resultScene);
    }
}