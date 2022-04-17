using UnityEngine;

public class MainCondition : MonoBehaviour {

    void Start() {
        GameState.State = GameState.States.NotStarted;
    }    
}