# Alba + JetBrains Rider 2023.3 Service Resolution

When running the tests in JetBrains Rider 2023.3, the following error is thrown:

```text
System.InvalidOperationException
Cannot resolve scoped service 'ServiceResolutionRepro.IntegrationTests.IIdGenerator' from root provider.
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteValidator.ValidateResolution(Type serviceType, IServiceScope scope, IServiceScope rootScope)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.GetService(Type serviceType, ServiceProviderEngineScope serviceProviderEngineScope)
   at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetService[T](IServiceProvider provider)
   at ServiceResolutionRepro.IntegrationTests.When_resolving_iid_generator_from_host_services.InitializeAsync() in /home/alexzeitler/src/alex/alba-rider-2023.3-service-resolution/ServiceResolutionRepro.IntegrationTests/When_resolving_iid_generator_from_host_services.cs:line 19
   at Xunit.Sdk.TestInvoker`1.<RunAsync>b__47_0() in /_/src/xunit.execution/Sdk/Frameworks/Runners/TestInvoker.cs:line 199
   at Xunit.Sdk.ExceptionAggregator.RunAsync[T](Func`1 code) in /_/src/xunit.core/Sdk/ExceptionAggregator.cs:line 107
```

When running the tests in JetBrains Rider 2023.2.3, the tests pass.

When running the tests using `dotnet test`, the tests pass.
