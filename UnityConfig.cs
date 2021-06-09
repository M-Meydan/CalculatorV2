using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace TDD_BestPractices
{
    /// <summary>
    /// Make sure you have using Unity; added in your classes
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the types for calculator,operators and instruction validator.
        /// </summary>
        public static void RegisterTypes()
        {
            //var container = UnityConfig.Container;
            //container.RegisterType<ICalculator, Calculator>();

            ////operations added as singleton object
            //container.RegisterType<IStrategy, Addition>("add", new ContainerControlledLifetimeManager());
            //container.RegisterType<IStrategy, Subtraction>("subtract", new ContainerControlledLifetimeManager());
            //container.RegisterType<IStrategy, Multiplication>("multiply", new ContainerControlledLifetimeManager());
            //container.RegisterType<IStrategy, Division>("divide", new ContainerControlledLifetimeManager());

            ////validators
            //container.RegisterType<IInstructionValidator, InstructionValidator>();
        }
    }
}
