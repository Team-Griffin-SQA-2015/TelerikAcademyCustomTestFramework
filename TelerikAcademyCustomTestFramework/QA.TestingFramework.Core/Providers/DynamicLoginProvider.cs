namespace QA.TestingFramework.Core.Providers
{
    #region using directives

    using ArtOfTest.WebAii.Core;

    using Data;

    #endregion

    public abstract class DynamicLoginProvider<T>
        where T : new()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }

                return _instance;
            }
        }

        public abstract dynamic Login { get; }

        public abstract string Url { get; }

        public void LoginUser(User user)
        {
            Manager.Current.ActiveBrowser.NavigateTo(this.Url);
            this.Login.TypeEmail(user.Email);
            this.Login.TypePassword(user.Password);
            this.Login.Submit();
        }
    }
}