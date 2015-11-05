namespace SourceControlSystem.Api.Infrastucture
{
    using Ninject;
    using System;
    using System.Linq;

    public static class ObjectFactory
    {
        private static IKernel savedKernel;

        public static void Initialize(IKernel kernel)
        {
            savedKernel = kernel;
        }

        public static T Get<T>()
        {
            return savedKernel.Get<T>();
        }
    }
}