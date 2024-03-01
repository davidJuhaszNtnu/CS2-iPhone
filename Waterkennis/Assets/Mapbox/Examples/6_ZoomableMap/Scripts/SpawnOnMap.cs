namespace Mapbox.Examples
{
	using UnityEngine;
	using Mapbox.Utils;
	using Mapbox.Unity.Map;
	using Mapbox.Unity.MeshGeneration.Factories;
	using Mapbox.Unity.Utilities;
	using System.Collections.Generic;

	public class SpawnOnMap : MonoBehaviour
	{
		[SerializeField]
		AbstractMap _map;

		[SerializeField]
		[Geocode]
		string[] _locationStrings;
		Vector2d[] _locations;

		[SerializeField]
		[Geocode]
		string[] path1PointsStrings;
		Vector3[] path1_points;
		[SerializeField]
		[Geocode]
		string[] path2PointsStrings;
		Vector3[] path2_points;
		[SerializeField]
		[Geocode]
		string[] path3PointsStrings;
		Vector3[] path3_points;
		[SerializeField]
		[Geocode]
		string[] path4PointsStrings;
		Vector3[] path4_points;

		[SerializeField]
		float _spawnScale = 100f;

		[SerializeField]
		GameObject _markerPrefab;
		[SerializeField]
		GameObject pathPrefab;

		public List<GameObject> _spawnedObjects;
		public List<GameObject> spawnedPaths;
		public GameObject app, player, map;
		public int currentSite;
		float rotationSpeed = 50f;
		float amplitude = 2f;
		float frequency = 0.5f;
		float start_heading;
		float start_time;
		bool objectsSpawned;

		void Start()
		{	
			objectsSpawned=false;
			_locations = new Vector2d[_locationStrings.Length];
			path1_points = new Vector3[path1PointsStrings.Length];
			path2_points = new Vector3[path2PointsStrings.Length];
			path3_points = new Vector3[path3PointsStrings.Length];
			path4_points = new Vector3[path4PointsStrings.Length];

			spawnedPaths = new List<GameObject>();
			_spawnedObjects = new List<GameObject>();
			currentSite = 0;
			for (int i = 0; i < _locationStrings.Length; i++)
			{
				var locationString = _locationStrings[i];
				_locations[i] = Conversions.StringToLatLon(locationString);
				var instance = Instantiate(_markerPrefab);
				instance.transform.SetParent(app.transform,true);
				instance.SetActive(false);
				instance.transform.localPosition = _map.GeoToWorldPosition(_locations[i], true);
				instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
				_spawnedObjects.Add(instance);
			}

			//paths
			for(int i=0;i<4;i++){
				var path=Instantiate(pathPrefab);
				path.transform.SetParent(app.transform,true);
				path.SetActive(false);
				spawnedPaths.Add(path);
			}
			
			for (int i = 0; i < path1PointsStrings.Length; i++)
			{
				var locationString = path1PointsStrings[i];
				Vector2d path_point = Conversions.StringToLatLon(locationString);
				path1_points[i] = _map.GeoToWorldPosition(path_point, true)+(new Vector3(0f,1f,0f));
			}
			for (int i = 0; i < path2PointsStrings.Length; i++)
			{
				var locationString = path2PointsStrings[i];
				Vector2d path_point = Conversions.StringToLatLon(locationString);
				path2_points[i] = _map.GeoToWorldPosition(path_point, true)+(new Vector3(0f,1f,0f));
			}
			for (int i = 0; i < path3PointsStrings.Length; i++)
			{
				var locationString = path3PointsStrings[i];
				Vector2d path_point = Conversions.StringToLatLon(locationString);
				path3_points[i] = _map.GeoToWorldPosition(path_point, true)+(new Vector3(0f,1f,0f));
			}
			for (int i = 0; i < path4PointsStrings.Length; i++)
			{
				var locationString = path4PointsStrings[i];
				Vector2d path_point = Conversions.StringToLatLon(locationString);
				path4_points[i] = _map.GeoToWorldPosition(path_point, true)+(new Vector3(0f,1f,0f));
			}
			LineRenderer lr = spawnedPaths[0].GetComponent<LineRenderer>();
			lr.positionCount=path1PointsStrings.Length;
			lr.numCornerVertices=10;
			lr.numCapVertices=10;

			lr = spawnedPaths[1].GetComponent<LineRenderer>();
			lr.positionCount=path2PointsStrings.Length;
			lr.numCornerVertices=10;
			lr.numCapVertices=10;

			lr = spawnedPaths[2].GetComponent<LineRenderer>();
			lr.positionCount=path3PointsStrings.Length;
			lr.numCornerVertices=10;
			lr.numCapVertices=10;

			lr = spawnedPaths[3].GetComponent<LineRenderer>();
			lr.positionCount=path4PointsStrings.Length;
			lr.numCornerVertices=10;
			lr.numCapVertices=10;

			Input.location.Start();
			start_heading = Input.compass.trueHeading;
			// start_heading = 0f;
			// Debug.Log(start_heading);
			// player.transform.rotation = Quaternion.Euler(0, start_heading, 0)*Quaternion.Euler(0,-90,0);
			start_time = Time.time;
		}

		private void Update()
		{
			//rotate player to his orientation
			if(Time.time < start_time + 0.5f){
				start_heading = (start_heading + (Input.compass.trueHeading))/2;
				// Debug.Log(start_heading);
			}else
			player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.Euler(0, Input.compass.trueHeading - start_heading, 0)*Quaternion.Euler(0, start_heading, 0)*Quaternion.Euler(0,-90,0), Time.deltaTime);
			

			if(_spawnedObjects[1].transform.localPosition.x == 0f && !objectsSpawned){
				int count = _spawnedObjects.Count;
				for (int i = 0; i < count; i++)
				{
					var spawnedObject = _spawnedObjects[i];
					var location = _locations[i];
					spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
					spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
				}

				//paths
				for (int i = 0; i < path1PointsStrings.Length; i++)
				{
					var locationString = path1PointsStrings[i];
					Vector2d path_point = Conversions.StringToLatLon(locationString);
					path1_points[i] = _map.GeoToWorldPosition(path_point, true)+(new Vector3(0f,1f,0f));
				}
				for (int i = 0; i < path2PointsStrings.Length; i++)
				{
					var locationString = path2PointsStrings[i];
					Vector2d path_point = Conversions.StringToLatLon(locationString);
					path2_points[i] = _map.GeoToWorldPosition(path_point, true)+(new Vector3(0f,1f,0f));
				}
				for (int i = 0; i < path3PointsStrings.Length; i++)
				{
					var locationString = path3PointsStrings[i];
					Vector2d path_point = Conversions.StringToLatLon(locationString);
					path3_points[i] = _map.GeoToWorldPosition(path_point, true)+(new Vector3(0f,1f,0f));
				}
				for (int i = 0; i < path4PointsStrings.Length; i++)
				{
					var locationString = path4PointsStrings[i];
					Vector2d path_point = Conversions.StringToLatLon(locationString);
					path4_points[i] = _map.GeoToWorldPosition(path_point, true)+(new Vector3(0f,1f,0f));
				}
				LineRenderer lr = spawnedPaths[0].GetComponent<LineRenderer>();
				lr.positionCount=path1PointsStrings.Length;
				lr.numCornerVertices=10;
				lr.numCapVertices=10;
				lr.SetPositions(path1_points);

				lr = spawnedPaths[1].GetComponent<LineRenderer>();
				lr.positionCount=path2PointsStrings.Length;
				lr.numCornerVertices=10;
				lr.numCapVertices=10;
				lr.SetPositions(path2_points);

				lr = spawnedPaths[2].GetComponent<LineRenderer>();
				lr.positionCount=path3PointsStrings.Length;
				lr.numCornerVertices=10;
				lr.numCapVertices=10;
				lr.SetPositions(path3_points);

				lr = spawnedPaths[3].GetComponent<LineRenderer>();
				lr.positionCount=path4PointsStrings.Length;
				lr.numCornerVertices=10;
				lr.numCapVertices=10;
				lr.SetPositions(path4_points);
			}else objectsSpawned=true;
			if(_spawnedObjects[currentSite].activeSelf && objectsSpawned){
				_spawnedObjects[currentSite].transform.Rotate(Vector3.up, rotationSpeed*Time.deltaTime);
				_spawnedObjects[currentSite].transform.position = new Vector3(_spawnedObjects[currentSite].transform.position.x, (3f+Mathf.Sin(Time.fixedTime*Mathf.PI*frequency)*amplitude),_spawnedObjects[currentSite].transform.position.z);
			}
		}

		public void showSitePath(){
			_spawnedObjects[currentSite].SetActive(true);
			spawnedPaths[currentSite].SetActive(true);
		}
		public void hideSitePath(){
			_spawnedObjects[currentSite].SetActive(false);
			spawnedPaths[currentSite].SetActive(false);
		}
	}
}