using UnityEngine;

namespace Brainz.Demo.TDD.Gun
{
	public interface IBulletInstantiator
	{
		Rigidbody Instantiate(GameObject prefab, Vector3 position);
	}
}