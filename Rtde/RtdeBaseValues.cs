//              WARNING
// This file is an empty shell containing only public C# items.
// The internal code is hidden; to access it, you need to obtain a Source licence of the library.


namespace Rtde {

	public abstract class RtdeBaseValues {


		protected abstract RtdeValue[] InternalValues { get; }


		public RtdeValue[] Values { get; }
	}
}
