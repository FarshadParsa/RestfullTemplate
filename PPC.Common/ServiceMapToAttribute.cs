using System;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Common.Attributes
{
    /// <summary>
    /// Maps a class to its service type and defines its lifetime in the dependency injection container.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ServiceMapToAttribute : Attribute
    {
        /// <summary>
        /// Gets the service type.
        /// </summary>
        public Type ServiceType { get; }

        /// <summary>
        /// Gets the service lifetime.
        /// </summary>
        public ServiceLifetime Lifetime { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceMapToAttribute"/> class.
        /// </summary>
        /// <param name="serviceType">The interface or base class that this class implements.</param>
        /// <param name="lifetime">The service lifetime (Singleton, Scoped, Transient).</param>
        public ServiceMapToAttribute(Type serviceType, ServiceLifetime lifetime = ServiceLifetime.Transient)
        {

            #region validation

            if (!Enum.IsDefined(typeof(ServiceLifetime), lifetime))
            {
                throw new ArgumentException("Invalid ServiceLifetime value.", nameof(lifetime));
            }

            #endregion

            ServiceType = serviceType;
            Lifetime = lifetime;
        }

    }
}
