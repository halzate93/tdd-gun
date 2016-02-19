using Brainz.Demo.TDD.Gun;
using UnityEngine;
using Zenject;

namespace Brainz.Demo.TDD
{
	public class GunInstaller : MonoInstaller
	{
		[SerializeField]
		private GunBehaviour gun;

		[SerializeField]
		private GameObject bullet;

		public override void InstallBindings()
		{
			Container.Bind<IBulletInstantiator>().ToSingle<BulletInstantiator>();
			Container.Bind<IGun>().ToSingle<Revolver>();
			Container.Bind<IGunBehaviour>().ToInstance(gun);
		}
	}
}