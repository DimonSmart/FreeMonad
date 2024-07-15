﻿namespace FreeMonadDemo
{
    public class Pure<TOutput> : IFree<TOutput>
    {
        public TOutput Value { get; private set; }

        public Pure(TOutput value)
        {
            Value = value;
        }

        public static implicit operator Pure<TOutput>(TOutput value)
        {
            return new Pure<TOutput>(value);
        }
    }

    public class Free<TOutput> : IFree<TOutput>
    {
        public ICommand<TOutput> Next { get; set; }
    }

    public interface ICommand<TOutput>
    {
    }

    public interface IFree<TOutput>
    {
    }
}
