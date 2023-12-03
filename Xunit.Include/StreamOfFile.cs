// Copyright (C) 2020 Serhii Kuzmychov (ku3mich@gmail.com)
// Licensed under the terms of the MIT license. See LICENCE for details.

using System.Diagnostics;

namespace Xunit.Include;

[DebuggerDisplay("{FileName}")]
public class StreamOfFile : File<FileStream>
{
    protected override void Init(string fileName) => Content = new FileStream(PathResolver.Instance.Resolve(fileName), FileMode.Open, FileAccess.Read);

    public StreamOfFile()
    {
    }

    public StreamOfFile(string fileName)
    {
        FileName = fileName;
        Init(fileName);
    }

    public static implicit operator Stream?(StreamOfFile streamOfFile) => streamOfFile?.Content;
}