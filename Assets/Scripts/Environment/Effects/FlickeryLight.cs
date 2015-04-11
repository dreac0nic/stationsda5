using UnityEngine;
using System.Collections;

public class FlickeryLight : MonoBehaviour {
	public enum WaveStyles { Sine, Noise };

	// Light Reference
	public Light lightObj;

	// Flicker Style
	public WaveStyles Style = WaveStyles.Sine;
	public float Base = 0.0f;
	public float Amplitude = 0.1f;
	public float Phase = 0.0f;
	public float Frequency = 0.5f;

	// Original Light Properties
	private Color lightColor;

	void Start()
	{
		if(!lightObj)
			lightObj = this.GetComponentInChildren<Light>();

		lightColor = lightObj.color;
	}

	void Update()
	{
		lightObj.color = lightColor*FlickerWave(Time.time);
	}

	float FlickerWave(float time)
	{
		float input = (time + Phase)*Frequency;
		float result = 1.0f;

		switch(Style) {
		case WaveStyles.Sine:
			result = Mathf.Sin(2*Mathf.PI*input);
			break;

		case WaveStyles.Noise:
			result = 1.0f - (Random.value*2);
			break;
		}

		return Base + (result*Amplitude);
	}
}
