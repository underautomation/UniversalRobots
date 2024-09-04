//              WARNING
// This file is an empty shell containing only public C# items.
// The internal code is hidden; to access it, you need to obtain a Source licence of the library.


namespace Dashboard {
	/// <summary>
	/// Answer return by a command which contains a value
	/// </summary>
	public class CommandResponse<T> : CommandResponse {


		public CommandResponse(CommandResponse command)
		{
			// Source is hidden, a Source licence is needed to access internal code...
		}

		/// <summary>
		/// Value return by the command
		/// </summary>
		public T Value;

		/// <summary>
		/// A human readable answer
		/// </summary>
		public override string ToString()
		{
			// Source is hidden, a Source licence is needed to access internal code...
			return default;
		}
	}
}