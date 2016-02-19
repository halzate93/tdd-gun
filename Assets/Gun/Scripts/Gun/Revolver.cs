using UnityEngine;
using Zenject;

namespace Brainz.Demo.TDD.Gun
{
	public class Revolver : IGun
	{
		[Inject]
		private IBulletInstantiator instantiator;

		public void Shoot(GameObject bulletPrefab, Vector3 position, float impulse)
		{
			Rigidbody bullet = instantiator.Instantiate(bulletPrefab, position);
			bullet.AddForce(Vector3.forward * impulse, ForceMode.Impulse);
		}
	}
}