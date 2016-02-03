namespace QA.TelerikAcademy.Core.Constants.Pages
{
    public static class CheckinDevicesConstants
    {
        public const string Url = @"http://stage.telerikacademy.com/Administration/Devices";
        public const string PageTitle = "Устройства за присъствия - Телерик Академия - Студентска система";
        public const string Invalid17CharactersLongNumber = "11111111111111111";
        public const string InvalidSpecialCharactersNumber = "12$@";
        public const string InvalidCyrillicCharactersNumber = "номер";
        public const string ValidNumber = "Device234";
        public const string ValidNumberForUpdate = "DeviceUpdated";
    }
}