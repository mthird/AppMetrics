﻿// Copyright (c) Allan hardy. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using App.Metrics.Configuration;
using Microsoft.Extensions.Configuration;

// ReSharper disable CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
// ReSharper restore CheckNamespace
{
    public static class MetricsServiceCollectionExtensions
    {
        /// <summary>
        ///     Adds the metrics services and configuration to the <see cref="IServiceCollection">IServiceCollection</see>.
        /// </summary>
        /// <param name="services">The application services collection.</param>
        /// <returns>The metrics host builder</returns>
        public static IMetricsHostBuilder AddMetrics(this IServiceCollection services)
        {
            var builder = services.AddMetricsHostBuilder();

            builder.AddRequiredPlatformServices();

            builder.AddCoreServices();

            return new MetricsHostBuilder(services);
        }

        /// <summary>
        ///     Adds the metrics services and configuration to the <see cref="IServiceCollection">IServiceCollection</see>.
        /// </summary>
        /// <param name="services">The application services collection.</param>
        /// <param name="configuration">
        ///     The <see cref="IConfiguration">IConfiguration</see> from where to load <see cref="AppMetricsOptions">options</see>.
        /// </param>
        /// <returns>The metrics host builder</returns>
        public static IMetricsHostBuilder AddMetrics(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppMetricsOptions>(configuration);
            return services.AddMetrics();
        }

        /// <summary>
        ///     Adds the metrics services and configuration to the <see cref="IServiceCollection">IServiceCollection</see>.
        /// </summary>
        /// <param name="services">The application services collection.</param>
        /// <param name="setupAction">The <see cref="AppMetricsOptions">options</see> setup action.</param>
        /// <param name="configuration">
        ///     The <see cref="IConfiguration">IConfiguration</see> from where to load
        ///     <see cref="AppMetricsOptions">options</see>. Any shared configuration options with the options delegate will be
        ///     overriden by using this configuration.
        /// </param>
        /// <returns>The metrics host builder</returns>
        public static IMetricsHostBuilder AddMetrics(this IServiceCollection services, Action<AppMetricsOptions> setupAction,
            IConfiguration configuration)
        {
            services.Configure(setupAction);
            services.Configure<AppMetricsOptions>(configuration);
            return services.AddMetrics();
        }

        /// <summary>
        ///     Adds the metrics services and configuration to the <see cref="IServiceCollection">IServiceCollection</see>.
        /// </summary>
        /// <param name="services">The application services collection.</param>
        /// <param name="configuration">
        ///     The <see cref="IConfiguration">IConfiguration</see> from where to load
        ///     <see cref="AppMetricsOptions">options</see>.
        /// </param>
        /// <param name="setupAction">The <see cref="AppMetricsOptions">options</see> setup action.</param>
        /// Any shared configuration options with the options IConfiguration will be overriden by the options delegate.
        /// <returns>The metrics host builder</returns>
        public static IMetricsHostBuilder AddMetrics(this IServiceCollection services, IConfiguration configuration,
            Action<AppMetricsOptions> setupAction)
        {
            services.Configure<AppMetricsOptions>(configuration);
            services.Configure(setupAction);
            return services.AddMetrics();
        }

        /// <summary>
        ///     Adds the metrics services and configuration to the <see cref="IServiceCollection">IServiceCollection</see>.
        /// </summary>
        /// <param name="services">The application services collection.</param>
        /// <param name="setupAction">The <see cref="AppMetricsOptions">options</see> setup action.</param>
        /// <returns>The metrics host builder</returns>
        public static IMetricsHostBuilder AddMetrics(this IServiceCollection services, Action<AppMetricsOptions> setupAction)
        {
            services.Configure(setupAction);
            return services.AddMetrics();
        }

        /// <summary>
        ///     Adds the metrics services and configuration to the <see cref="IServiceCollection">IServiceCollection</see>.
        /// </summary>
        /// <param name="services">The application services collection.</param>
        /// <returns>The metrics host builder</returns>
        internal static IMetricsHostBuilder AddMetricsHostBuilder(this IServiceCollection services)
        {
            return new MetricsHostBuilder(services);
        }
    }
}