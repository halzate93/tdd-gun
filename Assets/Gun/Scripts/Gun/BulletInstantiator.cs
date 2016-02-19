using UnityEngine;

namespace Brainz.Demo.TDD.Gun
{
	public class BulletInstantiator : IBulletInstantiator
	{
		public Rigidbody Instantiate(GameObject prefab, Vector3 position)
		{
			GameObject instantiated = GameObject.Instantiate(prefab, position, Quaternion.identity) as GameObject;
			return instantiated.GetComponent<Rigidbody>();
		}
	}
}