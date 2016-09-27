using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using System;

public class ProjectBuilder {

	static string[] SCENES = FindEnabledEditorScenes();
	//static string path = "C:/Builds";

	static string APP_NAME = "LostPigglets";
	static string TARGET_DIR = "C:/Users/dadiu/Google Drive/QA - MGP II/MGP2Builds";


	public static void BuildProject(){
		performAndroidBuild ();
		//string[] scenes = FindEnabledEditorScenes(); //["Scenes/Lake Scene.unity", "Scenes/game over.unity", "Scenes/you win.unity"];
		//Directory.CreateDirectory(path);
		//string BuildFolder = System.Diagnostics.Process.Start (Directory.GetCurrentDirectory() + "/" + BuildFolder + "/");
	}

	static void performAndroidBuild(){
		//Set the path to the Android SDK on the machine, since Unity cannot retain the state properly
		//AndroidSDKFolder.Path = "${ANDROID_HOME}";
		string target_dir = APP_NAME + ".apk";
		GenericBuild(SCENES, TARGET_DIR + "/" + target_dir, BuildTarget.Android,BuildOptions.None);
	}


	private static string[] FindEnabledEditorScenes() {
		List<string> EditorScenes = new List<string>();
		foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
			if (!scene.enabled) continue;
			EditorScenes.Add(scene.path);
		}
		return EditorScenes.ToArray();
	}

	static void GenericBuild(string[] scenes, string target_dir, BuildTarget build_target, BuildOptions build_options)
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(build_target);
		string res = BuildPipeline.BuildPlayer(scenes,target_dir,build_target,build_options);
		if (res.Length > 0) {
			throw new Exception("BuildPlayer failure: " + res);
		}
	}

}