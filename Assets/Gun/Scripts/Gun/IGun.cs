using UnityEngine;

namespace Brainz.Demo.TDD.Gun
{
	public interface IGun
	{
		void Shoot(GameObject bulletPrefab, Vector3 position, float impulse);
	}
}