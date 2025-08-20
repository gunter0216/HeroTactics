﻿using System;
using System.Collections.Generic;
using App.Common.Autumn.Runtime.Collection;
using App.Common.Autumn.Tests.TestClasses;
using NUnit.Framework;
using IServiceProvider = App.Common.Autumn.Runtime.Provider.IServiceProvider;
using TestContext = App.Common.Autumn.Tests.TestClasses.TestContext;

namespace App.Common.Autumn.Tests
{
    public class TestServiceCollection
    {
        private IServiceCollection m_ServiceCollection;
        private IServiceProvider m_ServiceProvider;

        [OneTimeSetUp]
        public void Init()
        {
            m_ServiceCollection = new ServiceCollection();
            var scoped = new List<Type>()
            {   
                typeof(Class1Interface1),
                typeof(Class2Interface1),
                typeof(Class1Interface2),
                typeof(InjectedClass),
                typeof(TestClass)
            };

            var singletons = new List<Type>()
            {
                typeof(Singleton1),
            };
            
            foreach (var type in scoped)
            {
                m_ServiceCollection.AddScoped(type, typeof(TestContext));
            }
            
            foreach (var singleton in singletons)
            {
                m_ServiceCollection.AddSingleton(singleton);
            }

            m_ServiceProvider = m_ServiceCollection.BuildServiceProvider(typeof(TestContext), new List<object>());
        }

        [Test]
        public void Test1()
        {
            var testClass = m_ServiceProvider.GetService<TestClass>();
            
            // Assert.AreEqual(class1.GetValue(), 13);
        }
    }
}