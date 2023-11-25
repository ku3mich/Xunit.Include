// Copyright (C) 2020 Serhii Kuzmychov (ku3mich@gmail.com)
// Licensed under the terms of the MIT license. See LICENCE for details.

namespace Xunit;

public interface IPathResolver
{
    string Resolve(string? relative = null);
}
