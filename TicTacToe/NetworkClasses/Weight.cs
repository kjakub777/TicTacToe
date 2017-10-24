using System;
using Java.Lang;

namespace TicTacToe
{
	/**
	 * Created by kj on 9/6/15.
	 */
	public class Weight : Java.Lang.ICloneable
	{
		int inputNodeNumber = 0;
		int outputNodeNumber = 0;
		public Node InputNode { get; set; }
		public Node OutputNode { get; set; }

		public double WeightRaw { get; set; }

		public IntPtr Handle => throw new NotImplementedException();

		public Weight()
		{
		}


		protected Weight clone()
		{
			Weight newW = (Weight)base.MemberwiseClone();
			newW.inputNodeNumber = this.inputNodeNumber;
			newW.outputNodeNumber = this.outputNodeNumber;
			return newW;
		}
		public Weight(int inputNodeNumber, double weight, int outputNodeNumber)
		{

			this.inputNodeNumber = inputNodeNumber;
			this.outputNodeNumber = outputNodeNumber;
		}

		public Weight(int inputNodeNumber, int outputNodeNumber)
		{
			this.inputNodeNumber = inputNodeNumber;
			this.outputNodeNumber = outputNodeNumber;
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~Weight() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion
	}
}