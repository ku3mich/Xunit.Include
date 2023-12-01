// Copyright (C) 2020 Serhii Kuzmychov (ku3mich@gmail.com)
// Licensed under the terms of the MIT license. See LICENCE for details.

using System.Diagnostics;
using Xunit.Abstractions;

namespace Xunit.Include;

public abstract class File<T> : IXunitSerializable
{
    public string? FileName { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public T Content { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public void Deserialize(IXunitSerializationInfo info)
    {
        FileName = (string)info.GetValue(nameof(FileName), typeof(string));
        Init(FileName);
    }

    protected abstract void Init(string fileName);

    public void Serialize(IXunitSerializationInfo info) => info.AddValue(nameof(FileName), FileName);

    public override string? ToString() => FileName;
}

