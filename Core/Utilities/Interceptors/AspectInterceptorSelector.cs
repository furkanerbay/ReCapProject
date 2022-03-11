using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;
using static Core.Utilities.Interceptors.MethodInterceptionBaseAttribute;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute> // class attributelarını oku
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name) //method attributelarını oku.
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true); 
            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderBy(x => x.Priority).ToArray(); // çalışma sırasınıda öncelik değerine göre sırala.
        }
    }

}
