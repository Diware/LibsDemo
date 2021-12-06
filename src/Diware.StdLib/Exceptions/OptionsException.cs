﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Diware.SL.Exceptions
{
	public class OptionsException
		: Exception
	{
		public OptionsException()
		{
		}

		public OptionsException(string message) : base(message)
		{
		}

		public OptionsException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected OptionsException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
