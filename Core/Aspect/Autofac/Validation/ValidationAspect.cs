using Castle.DynamicProxy;
using Core.CrossCuttingConcerns;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspect.Autofac.Validation
{
    public class ValidationAspect : MethodInterception // Bu bir attribute suan
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) // attribute oldugundan type olmak zorunda
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //Validator tipi ver diyor. !!! tipi abstractvalidator değilse !!!!
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil."); //uyuşmuyorsa hata fırlat. validation değilse abstractvalidator!!!!
            }

            _validatorType = validatorType; //abstract validator ise eşitle.
        }
        protected override void OnBefore(IInvocation invocation) //validation onBefore'da olacak.
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //Reflection - çalışma anında bir şeyleri çalıştırabilmemizi sağlıyor. new'leme çalışma anında. CarValidator'un instance'ını oluştur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //ProductValidator'un çalışma tipini bul. CarValidator<Car>
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //Bu sefer onun parametrelerini bul. İlgili methodun parametreleri IResult Add(Car car)
            //invocation = method
            foreach (var entity in entities) //Birden fazla parametre olacağından her birini tek tek tek gez
            {
                ValidationTool.Validate(validator, entity); //ValidationTool'u kullanarak Validate et.
            }
        }
    }
}
