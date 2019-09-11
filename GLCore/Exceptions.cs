using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLCore
{
    public class RediredctException : Exception
    {
        public RediredctException()
        {
        }

        public RediredctException(string message)
            : base(message)
        {
        }

        public RediredctException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class GLScriptException : Exception
    {
        public GLScriptException()
        {
        }

        public GLScriptException(string message)
            : base(message)
        {
        }

        public GLScriptException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class MessageException : Exception
    {
        public MessageException()
        {
        }

        public MessageException(string message)
            : base(message)
        {
        }

        public MessageException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
