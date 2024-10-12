#if UNITY_EDITOR
using System;
using UnityEngine;

namespace Entitas.Generic
{
	[Serializable]
	internal abstract class GeneratorBase
	{
		[field: SerializeField] public bool Enabled { get; set; } = true;

		public abstract string Name { get; }

		public abstract void Generate();

		public override bool Equals(object obj) => obj is GeneratorBase other && Equals(other);

		protected bool Equals(GeneratorBase other) => Name == other.Name;

		public override int GetHashCode() => HashCode.Combine(Name);
	}
}
#endif