// Copyright (C) 2020 Serhii Kuzmychov (ku3mich@gmail.com)
// Licensed under the terms of the MIT license. See LICENCE for details.

using System.Reflection;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Include;

public class InfoOfFileAttribute : DataAttribute, IXunitSerializable
{
    private string[] fileNames;

    public InfoOfFileAttribute(params string[] fileNames)
    {
        this.fileNames = fileNames;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        object[] prms = fileNames
            .Select(s => new InfoOfFile(PathResolver.Instance.Resolve(s)))
            .Cast<object>()
            .ToArray();

        yield return prms;
    }

    public void Serialize(IXunitSerializationInfo info) => info.AddValue(nameof(fileNames), fileNames);
    public void Deserialize(IXunitSerializationInfo info) => fileNames = (string[])info.GetValue(nameof(fileNames), typeof(string[]));
}

