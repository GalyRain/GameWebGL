using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour {


    SceneChanger newScene = new SceneChanger();
    private string homeScene = "MainScene";

    [SerializeField] private Text ResultText;
    [SerializeField] private Text InformText;

    void Start() {
        ResultCollection resultCollection = Result.TakeResult();

        if (resultCollection.results.Length != 0) {
            ResultText.text = resultCollection.results[resultCollection.results.Length - 1].time;
        } 
        else {
            ResultText.text = "Oops! There is nothing here yet))";
        }

        switch (GameState.State) {
            case GameState.States.Faild:
                {
                    if (InformText != null) {
                        InformText.text = "You've lost((";
                    }
                    break;
                }
            case GameState.States.Pass:
                {
                    if(InformText != null)
                    {
                        InformText.text = "You have won!";
                    }
                    break;
                }
            default: break;
        }
    }

    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            newScene.ChangeScene(homeScene);
        }
    }
}
