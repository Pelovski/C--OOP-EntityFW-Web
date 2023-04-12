using P01._Logger.Models.Enummerations;

namespace P01._Logger.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level level { get; }
        void Append(IError error);
    }
}
