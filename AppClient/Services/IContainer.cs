﻿using System;

namespace FlexiObject.AppClient.Services
{
    public interface IContainer
    {
        public T Get<T>();
        public object Get(Type type);
        public T Get<T>(Type type);
    }
}
