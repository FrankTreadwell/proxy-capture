using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureFramework.Attributes
{
    /// <summary>
    /// This attribute marks the method as one that alters the state of the underlying datastore.
    /// For example a SAVE to db method.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class Alteration : Attribute
    {
    }
}
