// Copyright (C) 2020 Serhii Kuzmychov (ku3mich@gmail.com)
// Licensed under the terms of the MIT license. See LICENCE for details.

using System.Reflection;
using Xunit.Sdk;

namespace Xunit.Include;

public class InfoOfFileAttribute(params string[] fileNames) : DataAttribute
{
    private string[] fileNames = fileNames;

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        object[] prms = fileNames
            .Select(s => new InfoOfFile(PathResolver.Instance.Resolve(s)))
            .Cast<object>()
            .ToArray();

        yield return prms;
    }
}

