using CaptureFramework.Interceptors;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureFramework.Factory
{
    public static class ProxyFactory
    {
        /// <summary>
        /// Returns a Capture proxy which will write method calls to disc. Retrieval methods will call underlying datastores. Alteration methods will NOT call underlying datastores.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="implementation"></param>
        /// <returns></returns>
        public static T CreateCaptureService<T>(T implementation) where T : class
        {
            ProxyGenerator generator = new ProxyGenerator();
            T proxy = (T)generator.CreateInterfaceProxyWithTarget<T>(implementation, new CaptureInterceptor());

            return proxy;
        }

        /// <summary>
        /// Returns a mock proxy which does nothing when methods are called. Does NOT call underlying interface method (no implementation)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T CreateCaptureService<T>() where T : class
        {
            ProxyGenerator generator = new ProxyGenerator();

            T proxy = (T)generator.CreateInterfaceProxyWithoutTarget(typeof(T), new MockInterceptor());

            return proxy;
        }

    }
}
