using UnityEngine;
using Zenject;

namespace Brainz.Demo.TDD.Gun
{
	public class Revolver : IGun
	{
		[Inject]
		private IObjectInstantiator instantiator;

		[Inject("Bullet")]
		private GameObject bullet;

		public void Shoot()
		{
			instantiator.Instantiate(bullet);
		}
	}
}