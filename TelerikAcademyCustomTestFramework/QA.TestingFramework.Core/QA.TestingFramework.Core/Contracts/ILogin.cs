namespace QA.UI.TestingFramework.Core.Contracts
{
    public interface ILogin
    {
        void TypeEmail(string email);

        void TypePassword(string password);

        void Submit();
    }
}