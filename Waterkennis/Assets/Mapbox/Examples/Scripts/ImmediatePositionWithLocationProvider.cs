namespace Mapbox.Examples
{
	using Mapbox.Unity.Location;
	using Mapbox.Unity.Map;
	using UnityEngine;

	public class ImmediatePositionWithLocationProvider : MonoBehaviour
	{

		bool _isInitialized;
		bool gotInitialPosition;
		Vector3 currentPosition;

		ILocationProvider _locationProvider;
		ILocationProvider LocationProvider
		{
			get
			{
				if (_locationProvider == null)
				{
					_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
				}

				return _locationProvider;
			}
		}

		Vector3 _targetPosition;

		float distance;
		public GameObject player_model;
		Animator animator;

		void Start()
		{
			LocationProviderFactory.Instance.mapManager.OnInitialized += () => _isInitialized = true;
			gotInitialPosition = false;
			animator = player_model.transform.GetComponent<Animator>();
		}

		void LateUpdate()
		{
			if (_isInitialized)
			{
				var map = LocationProviderFactory.Instance.mapManager;
				transform.localPosition = Vector3.Lerp(transform.localPosition, map.GeoToWorldPosition(LocationProvider.CurrentLocation.LatitudeLongitude), Time.deltaTime);
				if(!gotInitialPosition){
					gotInitialPosition = true;
					currentPosition = transform.localPosition;
					// Debug.Log(currentPosition);
				}
				distance = Vector3.Magnitude(transform.localPosition - currentPosition);
				if(distance > 0.01f)
					animator.SetBool("walk", true);
				else animator.SetBool("walk", false);
				currentPosition = transform.localPosition;
			}
		}
	}
}