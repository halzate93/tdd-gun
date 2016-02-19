using UnityEngine;
using Zenject;

namespace Brainz.Demo.TDD.Gun
{
	public class GunBehaviour : MonoBehaviour, IGunBehaviour
	{
		[Inject]
		private IGun gun;

		[SerializeField]
		private float impulse;

		[SerializeField]
		private GameObject bullet;

		public void Shoot()
		{
			gun.Shoot(bullet, transform.position, impulse);
		}
	}
}