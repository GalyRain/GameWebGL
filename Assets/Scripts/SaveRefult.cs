using UnityEngine;
using System;
using System.IO;

public class SaveResult {

	string filepath = "./Assets/Result/";

	public void AddNewResult(string filename, TimeSpan ts) {
		ResultClass result = ConvertTimeToObject(ts);
		ResultCollection resultCollection = this.ReadFile(filename);
		resultCollection = this.AddNewResultToObject(resultCollection, result);
		this.Save(filename, resultCollection);
	}

	public ResultCollection AddNewResultToObject(ResultCollection resultCollection, ResultClass result) {
		Array.Resize(ref resultCollection.results, resultCollection.results.Length + 1);
		resultCollection.results[resultCollection.results.Length - 1] = result;
		return resultCollection;
	}

	public ResultCollection ReadFile(string filename) {
		string filepathToResult = filepath + filename;
		var jsonFullResult = File.ReadAllText(filepathToResult);
		var listREsult = JsonUtility.FromJson<ResultCollection>(jsonFullResult);
		return listREsult;
	}

	public void Save(string filename, ResultCollection datas) {
		string filepathToResult = filepath + filename;
		File.WriteAllText(filepathToResult, JsonUtility.ToJson(datas));
	}

	public ResultClass ConvertTimeToObject(TimeSpan ts) {
		string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
		ts.Hours, ts.Minutes, ts.Seconds,
		ts.Milliseconds / 10);
		UnityEngine.Debug.Log("RunTime " + elapsedTime);

		ResultClass newResult = new ResultClass();
		newResult.time = elapsedTime;
		return newResult;
	}
}