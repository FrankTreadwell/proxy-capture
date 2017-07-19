using CaptureFramework.Attributes;
using Castle.Core.Interceptor;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureFramework.Interceptors
{
    public class CaptureInterceptor : IInterceptor
    {

        public void Intercept(IInvocation invocation)
        {
            var customAttributes = invocation.Method.CustomAttributes;

            if (customAttributes.Count() > 0)
            {
                bool retrievalMethod = customAttributes.Count(x => x.AttributeType.Name == nameof(Retrieval)) > 0;
                bool alterationMethod = customAttributes.Count(x => x.AttributeType.Name == nameof(Alteration)) > 0;

                //if both attributes are detected or no attributes are detected break.
                if ((retrievalMethod && alterationMethod) || (retrievalMethod == false && alterationMethod == false))
                {
                    return;
                }
                else
                {
                    if (retrievalMethod)
                        CaptureRetrieval(invocation);
                    if (alterationMethod)
                        CaptureAlterationWithoutPersistence(invocation);
                }
            }
            else
            {
                Console.WriteLine("No Custom Attributes detected on method. Skipping invocation");
            }

        }

        private void CaptureRetrieval(IInvocation invocation)
        {
            //perform the retrieval
            invocation.Proceed();

            //serialize the return object
            var json = JsonConvert.SerializeObject(invocation.ReturnValue);

            Console.WriteLine($"Received object from method - {invocation.Method.Name} : {json}");
        }

        private void CaptureAlterationWithoutPersistence(IInvocation invocation)
        {
            //serialize the arguments
            var json = JsonConvert.SerializeObject(invocation.Arguments);

            Console.WriteLine($"Method {invocation.Method.Name} tried to save arguments: {json}");
        }
    }
}
