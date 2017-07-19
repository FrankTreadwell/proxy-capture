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
        public static T CreateCaptureService<T>(T implementation) where T : class
        {
            ProxyGenerator generator = new ProxyGenerator();
            T proxy = (T)generator.CreateInterfaceProxyWithTarget<T>(implementation, new CaptureInterceptor());

            return proxy;
        }
    }
}
