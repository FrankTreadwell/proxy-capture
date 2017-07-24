using CaptureFramework.Datastores;
using CaptureFramework.Factory;
using CaptureFramework.Interceptors;
using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            var proxy = ProxyFactory.CreateCaptureService<IStudentDatastore>(new StudentDatastore());

            Console.WriteLine("Begin Capture Proxy Test.");
            proxy.SaveStudent(new Student() { id = 5 });
            proxy.GetStudentByID(1);

           
            var mockProxy = ProxyFactory.CreateCaptureService<IStudentDatastore>();
            Console.WriteLine("Begin Mock Proxy Test.");
            mockProxy.GetStudentByID(1);
            Console.ReadLine();
        }
    }
}
