// Copyright (C) 2020 Serhii Kuzmychov (ku3mich@gmail.com)
// Licensed under the terms of the MIT license. See LICENCE for details.

namespace Xunit.Include;

public class InfoOfFile : File<FileInfo>
{
    protected override void Init(string fileName) => Content = new FileInfo(PathResolver.Instance.Resolve(fileName));

    public InfoOfFile()
    {
    }

    public InfoOfFile(string fileName)
    {
        FileName = fileName;
        Init(fileName);
    }
}
