namespace TplProducerConsumer
{
	public class Maybe<T, TE>
	{
		public bool HasError { get; }

		public TE Error { get; }

		public T Value { get; }

		public Maybe(T value)
		{
			Value = value;
			HasError = false;
		}

		public Maybe(TE error)
		{
			Error = error;
			HasError = true;
		}
	}
}
