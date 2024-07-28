using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))  //IValidator tipi gelen tip tipinden bir nesne alabilir mi? 
            {
                throw new System.Exception("Bu bir validation sınıfı değil.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);  //dinamik olarak nesne oluşturma, reflection kullanım alanları
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //Örn: ColourValidator basetype'ı --> AbstractValidator<Colour> gelen generic argument colour
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //çağrı ile gönderilen (çağrı örneğin corporatecustomerdan geliyor o zaman 1 user 1 corporatecustomer kaydı atılacağı için 2 entitiy gelecek) argumanlar yani entity validation'ıv 2si için yapacak
            
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
            
        }
    }
}
