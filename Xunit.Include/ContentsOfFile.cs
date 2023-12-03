// Copyright (C) 2020 Serhii Kuzmychov (ku3mich@gmail.com)
// Licensed under the terms of the MIT license. See LICENCE for details.

namespace Xunit.Include;

public class ContentsOfFile : File<string>
{
    protected override void Init(string fileName) => Content = File.ReadAllText(PathResolver.Instance.Resolve(fileName));

    public ContentsOfFile()
    {
    }

    public ContentsOfFile(string fileName)
    {
        FileName = fileName;
        Init(fileName);
    }

    public static implicit operator string?(ContentsOfFile file) => file?.Content;
}
