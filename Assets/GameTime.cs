using UnityEngine;
using System.Collections;

public class GameTime : MonoBehaviour {
	public Transform sun;
	public float tempsPourCycleEnMinute = 1;	// 1 Journée est égal à 1 minute
	public float heureLeverSoleil = 6;
	public int jourDepart = 0;
	public int nbJourParCycle = 7;
	
	private float dayCycleInSecond;
	
	private const float SECOND = 1;
	private const float MINUTE = 60 * SECOND;
	private const float HOUR = 60 * MINUTE;
	private const float DAY = 24 * HOUR;
	
	private const float DEGREES_PER_SECOND = 360 / DAY;
	
	private float _hoursInDay_inSecond;
	private float _degreeRotation;
	private float _timeOfDay;
	private int dayInWeek = 0;
	private float hourInDay = 0;
	
	// Use this for initialization
	void Start () {
		
		dayCycleInSecond = tempsPourCycleEnMinute * MINUTE;
		
		_timeOfDay = 0;
		_degreeRotation = DEGREES_PER_SECOND * DAY / (dayCycleInSecond);
		
		_hoursInDay_inSecond = dayCycleInSecond / 24;
		
		sun.Rotate(new Vector3(- (DEGREES_PER_SECOND * (heureLeverSoleil * HOUR)), 0, 0));
		
		dayInWeek = jourDepart;
	}
	
	// Update is called once per frame
	void Update () {
		sun.Rotate(new Vector3(_degreeRotation, 0, 0) * Time.deltaTime);
		_timeOfDay += Time.deltaTime;
		
		if(_timeOfDay > dayCycleInSecond) {
			_timeOfDay = 0;
			dayInWeek++;
		}
		
		if(dayInWeek > nbJourParCycle - 1) {
			dayInWeek = 0;
		}
		
		hourInDay =  _timeOfDay / _hoursInDay_inSecond;
		
		Debug.Log(" Day: " + dayInWeek + " Hour:" + Mathf.Round(hourInDay));
	}
	
	float dayOfWeek() {	
		return dayInWeek;
	}
		
}
