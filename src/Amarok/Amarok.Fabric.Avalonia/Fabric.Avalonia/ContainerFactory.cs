// Copyright (c) 2025, Olaf Kober <olaf.kober@outlook.com>

using System.Reflection;
using DryIoc;
using DryIoc.MefAttributedModel;
using Microsoft.Extensions.FileSystemGlobbing;


namespace Amarok.Fabric.Avalonia;


internal sealed class ContainerFactory
{
    public Container Create(
        IEnumerable<String> assemblyIncludeGlobs,
        IEnumerable<String> assemblyExcludeGlobs
    )
    {
        var container = new Container(
            Rules.Default.WithMicrosoftDependencyInjectionRules()
                .WithMefAttributedModel()
                .WithoutTrackingDisposableTransients()
        );

        var matcher = new Matcher(StringComparison.OrdinalIgnoreCase);
        matcher.AddIncludePatterns(assemblyIncludeGlobs);
        matcher.AddExcludePatterns(assemblyExcludeGlobs);

        var assemblies = matcher.GetResultsInFullPath(AppContext.BaseDirectory)
            .Select(Assembly.LoadFrom)
            .Concat([ typeof(ApplicationBase).Assembly ]);

        container.RegisterExports(assemblies);

        return container;
    }
}
