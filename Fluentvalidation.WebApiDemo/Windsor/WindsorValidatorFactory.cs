using Castle.Windsor;
using FluentValidation;
using System;

namespace Fluentvalidation.WebApiDemo.Windsor
{
    public class WindsorValidatorFactory : ValidatorFactoryBase
    {
        private readonly IWindsorContainer _container; 

        public WindsorValidatorFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            if (_container.Kernel.HasComponent(validatorType))
                return _container.Resolve(validatorType) as IValidator;
            return null;
        }
    }
}