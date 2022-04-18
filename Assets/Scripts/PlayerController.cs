using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private string resultScene = "ResultsScene";
    private string homeScene = "MainScene";
    private float horizontal = 0f;
    private float vertical = 0f;
    public float speed = 2f;

    SceneChanger newScene = new SceneChanger();
    Stopwatch watch = new Stopwatch();

    [SerializeField] private SceneChanger SceneChanger;

    void Start() {
        watch.Start();
    }

    void Update() {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate() {

        Vector3 move = new Vector3(horizontal, 0.0f, vertical);

        transform.position += move * speed * Time.fixedDeltaTime;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            newScene.ChangeScene(homeScene);
        }
    }

    private void Finish() {
        watch.Stop();
        TimeSpan ts = watch.Elapsed;
        Result.AddNewResult(ts);
        GameState.State = GameState.States.Pass;
    }

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Finish"))
        {
            Finish();
        }

        if (other.CompareTag("Faild"))
        {
            UnityEngine.Debug.Log("Faild");
            GameState.State = GameState.States.Faild;
        }
        newScene.ChangeScene(resultScene);
    }
}