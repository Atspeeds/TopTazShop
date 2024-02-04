namespace TT.FrameWork.Messages
{
    public static class ServiceMessage
    {

        public const string SuccessfulOperation = "عملیات با موفقیت انجام شد";


        public const string EmptyRecord = ".رکوردی با این آیدی پیدا نشد لطفا مجدد تلاش کنید";

        public const string IsRequired = "این مقدار نمی تواند خالی باشد";

        public const string MaxFileSize = "فایل حجیم تر از حد مجاز است";

        public const string InvalidFileFormat = "فرمت فایل مجاز نیست";

        public const string MaxLenght = "مقدار وارد شده بیش از طول مجاز است";

        public const string DuplicateMessage = "این مسیج بیش از یک بار وارد شده";

        public const string PasswordMismatch = "رمز عبور با تکرار رمز عبور متفاوت است";

        public const string UserNotFound = "نام کاربری یا رمز عبور اشتباه است";

        public static string DuplicateMobailRegister = ".کاربر عزیز با این شماره قبلا ثبت نام انجام شده";

        public static string InvalidVerificationCode = ".کد تایید نادرست است";

        public static string InvalidMobileNumber = ".شماره موبایل نادرست است";

        public const string MobileVerification = "Ok";
    }
}
