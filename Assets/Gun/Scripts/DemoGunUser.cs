using Brainz.Demo.TDD.Gun;
using UnityEngine;
using Zenject;

namespace Brainz.Demo.TDD
{
	public class DemoGunUser : MonoBehaviour
	{
		[Inject]
		private IGunBehaviour gun;

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Space))
				gun.Shoot();
		}
	}
}