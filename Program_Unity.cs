using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace TDD_BestPractices
{
    partial class Program
    {

        private static void ConfigureUnityContainer()
        {
            UnityConfig.RegisterTypes();
        }
    }
}
