using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureFramework.Attributes
{
    /// <summary>
    /// This attribute marks the method as one that DOES NOT alter the state of the underlying datastore.
    /// For example a GET BY ID method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class Retrieval : Attribute
    {
    }
}
