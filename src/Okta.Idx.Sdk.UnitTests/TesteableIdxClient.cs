﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Logging.Abstractions;
using Okta.Idx.Sdk.Configuration;
using Okta.Sdk.Abstractions;
using Okta.Sdk.Abstractions.Configuration;

namespace Okta.Idx.Sdk.UnitTests
{
    public class TesteableIdxClient : IdxClient
    {
        public static readonly IdxConfiguration DefaultFakeConfiguration = new IdxConfiguration
        {
            Issuer = "https://fake.example.com",
            ClientId = "foo",
        };

        public TesteableIdxClient(IRequestExecutor requestExecutor)
            : base(
                new DefaultDataStore(requestExecutor, new DefaultSerializer(), new ResourceFactory(null, null, new AbstractResourceTypeResolverFactory(ResourceTypeHelper.GetAllDefinedTypes(typeof(Resource)))),
                    NullLogger.Instance,
                    new UserAgentBuilder("test",
                        typeof(TesteableIdxClient).GetTypeInfo().Assembly.GetName().Version)),
                DefaultFakeConfiguration,
                new RequestContext())
        {
        }
    }
}
