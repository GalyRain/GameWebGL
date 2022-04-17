using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour {

    string fileName = "result.json";
    private string hometcene = "MainScene";

    SceneChanger newScene = new SceneChanger();
    [SerializeField] private Text ResultText;
    [SerializeField] private Text InformText;

    void Start() {
        SaveResult saveResult = new SaveResult();
        ResultCollection resultCollection = saveResult.ReadFile(fileName);

        if (resultCollection.results.Length != 0) {
            ResultText.text = resultCollection.results[resultCollection.results.Length - 1].time;
        } 
        else {
            ResultText.text = "Упс! Тут пока ничего нет))";
        }

        switch (GameState.State) {
            case GameState.States.Faild: {
                    InformText.text = "Вы проиграли";
                    break;
                }
            case GameState.States.Pass: {
                    InformText.text = "Вы выиграли";
                    break;
                }
            default: break;
        }
    }

    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            newScene.ChangeScene(hometcene);
        }
    }
}
