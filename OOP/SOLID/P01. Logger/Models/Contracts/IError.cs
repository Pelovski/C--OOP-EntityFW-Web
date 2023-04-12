using System;
using P01._Logger.Models.Enummerations;

namespace P01._Logger.Models.Contracts
{
    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}
