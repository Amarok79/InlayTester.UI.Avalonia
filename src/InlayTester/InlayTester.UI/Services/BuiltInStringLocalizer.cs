// Copyright (c) 2024, Olaf Kober <olaf.kober@outlook.com>

using System.Collections.Concurrent;
using Amarok.Fabric;
using Microsoft.Extensions.Localization;
using StringTokenFormatter;
using StringTokenFormatter.Impl;
using Tommy;
using Tommy.Extensions;


namespace InlayTester.Services;


[Export<IStringLocalizer>]
internal sealed class BuiltInStringLocalizer : IStringLocalizer
{
    private readonly String mBaseDir;
    private readonly InterpolatedStringResolver mResolver;
    private readonly ConcurrentDictionary<CultureInfo, ResourceReader?> mReaders = new();


    public BuiltInStringLocalizer(String baseDir)
    {
        mBaseDir = baseDir;

        mResolver = new InterpolatedStringResolver(
            StringTokenFormatterSettings.Default with {
                Syntax = new TokenSyntax("$(", ")", "$$("),
                NameComparer = StringComparer.Ordinal,
                Commands = [ ExpanderCommandFactory.Standard ],
            }
        );
    }


    public IEnumerable<LocalizedString> GetAllStrings(Boolean includeParentCultures)
    {
        throw new NotSupportedException();
    }

    public LocalizedString this[String name] => _GetString(name);

    public LocalizedString this[String name, params Object[] arguments] => _GetString(name, arguments);


    private LocalizedString _GetString(String key, params Object[]? args)
    {
        return _GetString(key, CultureInfo.CurrentUICulture, args);
    }

    private LocalizedString _GetString(String key, CultureInfo language, params Object[]? args)
    {
        var reader = _GetReaderWithFallback(language);

        if (reader != null)
        {
            var text = reader.GetString(key);

            if (text != null)
            {
                text = mResolver.FromFunc(text, token => reader.GetString(token));

                if (args != null && args.Length > 0)
                    text = String.Format(CultureInfo.CurrentCulture, text, args);

                return new LocalizedString(key, text, true);
            }
        }

        return _GetMissingString(key);
    }

    private ResourceReader? _GetReaderWithFallback(CultureInfo language)
    {
        while (true)
        {
            var reader = mReaders.GetOrAdd(
                language,
                static (language, baseDir) => _CreateReader(language, baseDir),
                mBaseDir
            );

            if (reader != null || language.IsNeutralCulture)
                return reader;

            language = language.Parent;
        }
    }

    private static TomlResourceReader? _CreateReader(CultureInfo language, String baseDir)
    {
        var path = Path.Combine(baseDir, $"{language.Name}.toml");

        return File.Exists(path) ? new TomlResourceReader(path) : null;
    }

    private LocalizedString _GetMissingString(String key)
    {
        return new LocalizedString(key, $"[{key}]", false);
    }



    private abstract class ResourceReader
    {
        public abstract String? GetString(String key);
    }

    private sealed class TomlResourceReader : ResourceReader
    {
        private readonly String mFilePath;
        private readonly Lazy<TomlTable> mTable;

        public TomlResourceReader(String filePath)
        {
            mFilePath = filePath;
            mTable    = new Lazy<TomlTable>(_ReadFile);
        }

        private TomlTable _ReadFile()
        {
            using var stream = new StreamReader(mFilePath);
            return TOML.Parse(stream);
        }

        public override String? GetString(String key)
        {
            return mTable.Value.FindNode(key)?.ToString();
        }
    }
}
