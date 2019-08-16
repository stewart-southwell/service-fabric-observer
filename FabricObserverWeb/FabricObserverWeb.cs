﻿// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Fabric;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Services.Communication.AspNetCore;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace FabricObserver
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance. 
    /// </summary>
    internal sealed class FabricObserverWeb : StatelessService
    {
        internal FabricClient fabricClient;

        public FabricObserverWeb(StatelessServiceContext context) : base(context)
        {
            this.fabricClient = new FabricClient();
        } 

        /// <summary>
        /// Optional override to create listeners (like tcp, http) for this service instance.
        /// </summary>
        /// <returns>The collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[]
            {
                new ServiceInstanceListener(serviceContext =>
                    new KestrelCommunicationListener(serviceContext, "ServiceEndpoint", (url, listener) =>
                    {
                        ServiceEventSource.Current.ServiceMessage(serviceContext, $"Starting Kestrel on {url}");

                        return new WebHostBuilder()
                                    .UseKestrel(opt =>
                                    {
                                        int port = serviceContext.CodePackageActivationContext.GetEndpoint("ServiceEndpoint").Port;
                                        opt.Listen(IPAddress.Loopback, port, listenOptions =>
                                        {
                                            listenOptions.NoDelay = true;
                                        });
                                    })
                                    .ConfigureServices(services => services.AddSingleton(serviceContext))
                                    .ConfigureServices(services => services.AddSingleton(fabricClient))
                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                    .UseStartup<Startup>()
                                    .UseServiceFabricIntegration(listener, ServiceFabricIntegrationOptions.None)
                                    .UseUrls("http://localhost:5000")
                                    .Build();
                    }))
            };
        }
    }
}