using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{

	[Serializable]
	public class OrderHandlingException : Exception
	{
		public OrderHandlingException() { }
		public OrderHandlingException(string message) : base(message) { }
		public OrderHandlingException(string message, Exception inner) : base(message, inner) { }
		protected OrderHandlingException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
