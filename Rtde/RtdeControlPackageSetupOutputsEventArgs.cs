//              WARNING
// This file is an empty shell containing only public C# items.
// The internal code is hidden; to access it, you need to obtain a Source licence of the library.

using Common;

namespace Rtde {

	public class RtdeControlPackageSetupOutputsEventArgs : PackageEventArgs {


		public byte OutputRecipeId { get; set; }


		public string[] VariableTypes { get; set; }
	}
}
