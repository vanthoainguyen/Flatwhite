﻿using Autofac;
using Castle.DynamicProxy;
using Flatwhite.Strategy;

namespace Flatwhite.AutofacIntergration
{
    internal class FlatwhiteCoreModule : Module
    { 
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => Global.CacheKeyProvider);
            builder.Register(c => Global.CacheStoreProvider);
            builder.Register(c => Global.ContextProvider);
            builder.Register(c => Global.CacheStrategyProvider);
            builder.Register(c => Global.AttributeProvider);
            builder.Register(c => Global.CacheAttributeProvider);
            builder.Register(c => Global.HashCodeGeneratorProvider);

            builder.RegisterType<DefaultCacheStrategy>().As<ICacheStrategy>();
            builder.RegisterType<CacheInterceptorAdaptor>()
                   .Keyed<IInterceptor>(typeof(CacheInterceptor))
                   .Named<IInterceptor>(typeof(CacheInterceptor).Name)
                   .AsSelf();
        }
    }
}
