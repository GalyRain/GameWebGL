using UnityEngine;
using System;

public static class Result {
	private static readonly string hasName = "Result";
	public static void setHasResult() {
		if (!PlayerPrefs.HasKey(hasName))
		{
			PlayerPrefs.SetString(hasName, "{\"results\":[]}");
		}
	}
	
	public static void AddNewResult(TimeSpan ts) {
		ResultClass newResult = ConvertTimeToObject(ts);
		ResultCollection resultCollection = TakeResult();
		resultCollection = AddNewResultToObject(resultCollection, newResult);
		Save(resultCollection);
	}

	public static ResultCollection AddNewResultToObject(ResultCollection resultCollection, ResultClass newResult) {
		Array.Resize(ref resultCollection.results, resultCollection.results.Length + 1);
		resultCollection.results[resultCollection.results.Length - 1] = newResult;
		return resultCollection;
	}

	public static ResultCollection TakeResult() {
		var jsonFullResult = PlayerPrefs.GetString(hasName);
		var listREsult = JsonUtility.FromJson<ResultCollection>(jsonFullResult);
		return listREsult;
	}

	public static void Save(ResultCollection datas) {
		var jsonFullResult = JsonUtility.ToJson(datas);
		PlayerPrefs.SetString(hasName, jsonFullResult);
	}

	public static ResultClass ConvertTimeToObject(TimeSpan ts) {
		string elapsedTime = String.Format("{0:00}:{1:00}.{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
		Debug.Log("RunTime " + elapsedTime);
		ResultClass newResult = new ResultClass();
		newResult.time = elapsedTime;
		return newResult;
	}
}