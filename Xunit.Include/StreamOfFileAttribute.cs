// Copyright (C) 2020 Serhii Kuzmychov (ku3mich@gmail.com)
// Licensed under the terms of the MIT license. See LICENCE for details.

using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Include;

public class StreamOfFileAttribute : DataAttribute
{
    private readonly string[] fileNames;

    public StreamOfFileAttribute(params string[] fileNames)
    {
        this.fileNames = fileNames;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        object[] prms = fileNames
            .Select(s => new StreamOfFile(s))
            .Cast<object>()
            .ToArray();

        yield return prms;
    }
}