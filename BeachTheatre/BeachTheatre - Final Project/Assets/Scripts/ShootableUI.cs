using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableUI : MonoBehaviour {
	public VideoPlayerController videoPlayerController;
	public abstract void shotClick();
}
