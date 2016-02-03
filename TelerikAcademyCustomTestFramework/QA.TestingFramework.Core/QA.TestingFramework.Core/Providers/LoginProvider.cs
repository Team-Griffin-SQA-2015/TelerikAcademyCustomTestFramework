namespace QA.UI.TestingFramework.Core.Providers
{
    using ArtOfTest.WebAii.Core;

    using Contracts;

    using Data;

    public abstract class LoginProvider<T>
        where T : new()
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;
            }
        }

        public abstract ILogin Login { get; }

        public abstract string Url { get; }

        public void LoginUser(User user)
        {
            Manager.Current.ActiveBrowser.NavigateTo(this.Url);
            this.Login.TypeEmail(user.Username);
            this.Login.TypePassword(user.Password);
            this.Login.Submit();
        }
    }
}