﻿using Converters.Domain.Abstractions.Services;

namespace Converters.Services;

public abstract class BaseService : IBaseService
{
    public virtual void Dispose()
    {
        //
    }
}
