using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoPlayerController : MonoBehaviour {


	private VideoPlayer videoPlayer;
	public Text currentMinutes;
	public Text currentSeconds;
	public Text totalMinutes;
	public Text totalSeconds;

	public Material playButton;
	public Material pauseButton;
	public Renderer playRenderer;

	public headMover playHead;

	void Awake(){
		videoPlayer = GetComponent<VideoPlayer> ();
	}

	// Use this for initialization
	void Start () {
		setTotalTimeUI ();
	}
	
	// Update is called once per frame
	void Update () {
		if (videoPlayer.isPlaying) {
			setCurrentTimeUI();
			playHead.MovePlayHead(CalculatePlayedFraction ());
		}
		
	}

	public void PlayPause(){
		if (videoPlayer.isPlaying) {
			videoPlayer.Pause ();
			playRenderer.material = playButton;
		} else {
			videoPlayer.Play();
			playRenderer.material = pauseButton;
		}
	}

	void setCurrentTimeUI(){
		string min = Mathf.Floor ((int)videoPlayer.time / 60).ToString("00");
		string sec = ((int)videoPlayer.time % 60).ToString ("00");

		currentMinutes.text = min;
		currentSeconds.text = sec;
	}

	void setTotalTimeUI(){
		string min = Mathf.Floor ((int)videoPlayer.clip.length / 60).ToString("00");
		string sec = ((int)videoPlayer.clip.length % 60).ToString ("00");

		totalMinutes.text = min;
		totalSeconds.text = sec;
	}

	double CalculatePlayedFraction(){
		double fraction = (double)videoPlayer.frame / (double)videoPlayer.clip.frameCount;
		return fraction;
	}
}