using Elements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Domino
{
	/// <summary>
	/// Override metadata for SubUnitSetOverrideRemoval
	/// </summary>
	public partial class SubUnitSetOverrideRemoval : IOverride
	{
        public static string Name = "SubUnitSet Removal";
        public static string Dependency = null;
        public static string Context = "[*discriminator=Elements.SubUnitSet]";
		public static string Paradigm = "Edit";

        /// <summary>
        /// Get the override name for this override.
        /// </summary>
        public string GetName() {
			return Name;
		}

		public object GetIdentity() {

			return Identity;
		}

	}

}