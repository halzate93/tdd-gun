using Brainz.Demo.TDD.Gun;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;
using System;
using UnityEngine;
using Zenject;

namespace Brainz.Demo.TDD.Tests
{
	[TestFixture]
	public class RevolverTest
	{
		private const string SHOULD_BE_DESTROYED_TAG = "ShouldBeDestroyedOnTearDown";
		private Vector3 SHOOT_POSITION = Vector3.zero;

		private IBulletInstantiator instantiator;
		private Revolver revolver;
		private GameObject bullet;

		[SetUp]
		public void MakeRevolver()
		{
			DiContainer container = new DiContainer();

			instantiator = MockInstantiator();
			container.Bind<IBulletInstantiator>().ToInstance(instantiator);

			bullet = MockBullet();
			container.Bind<GameObject>("Bullet").ToInstance(bullet);

			revolver = new Revolver();
			container.Inject(revolver);
		}

		private GameObject MockBullet()
		{
			GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			bullet.tag = SHOULD_BE_DESTROYED_TAG;
			bullet.AddComponent<Rigidbody>();
			return bullet;
		}

		private IBulletInstantiator MockInstantiator()
		{
			IBulletInstantiator instantiator = Substitute.For<IBulletInstantiator>();

			Func<CallInfo, Rigidbody> getRigidBodyComponent = (callInfo) =>
			{
				GameObject bullet = callInfo.Arg<GameObject>();
				return bullet.GetComponent<Rigidbody>();
			};

			instantiator.Instantiate(Arg.Any<GameObject>(), Arg.Any<Vector3>()).Returns(getRigidBodyComponent);

			return instantiator;
		}

		[TearDown]
		public void CleanBullets()
		{
			GameObject[] bullets = GameObject.FindGameObjectsWithTag(SHOULD_BE_DESTROYED_TAG);
			foreach (GameObject toDestroy in bullets)
				GameObject.DestroyImmediate(toDestroy);
		}

		[Test]
		public void InstantiatesBulletOnShoot()
		{
			revolver.Shoot(bullet, SHOOT_POSITION, 0f);
			instantiator.Received().Instantiate(bullet, SHOOT_POSITION);
		}
	}
}