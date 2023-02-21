namespace Domain.Constants
{
    public static class Constants
    {
        public static int UsersCount = 0;
        public const string RequiredValidationLoginErrorText = "Не указан логин пользователя!";
        public const string RequiredValidationFirstNameErrorText = "Не указано имя пользователя!";
        public const string RequiredValidationSecondNameErrorText = "Не указана фамилия пользователя!";
        public const string RequiredValidationPasswordErrorText = "Не указан пароль пользователя!";
        public const string EmailAddressValidationErrorText = "Неверно указан логин пользователя. Логин должен быть указан в формате email!";
        public const string PasswordRegularExpressionErrorText = "Пароль должен состоять хотя бы из одной цифры, одной буквы, одной" +
            " заглавной буквы и одного символа, длина пароля должна быть больше 5 символов, и не превышать 20 символов";
        

        public const string RegistretionUserNameErrorText = "Пользователь с таким логином уже существует!";
        public const string RegistretionNotComparePasswordErrorText = "Пароли не совпадают!"; 
        
        public const string AutorizationNotValidPasswordErrorText = "Некоректный пароль пользователя!";
        public const string AutorizationNotFindUserErrorText = "Пользователя с таким логином не существует. Если вы не зарегистрированы, нажмите на кнопку регистрация нового пользователя!";
    
        public const string RequiredValidationUserInfoNameErrorText = "Не указано имя пользователя!"; 
        public const string RequiredValidationUserInfoPhoneErrorText = "Не указан номер телефона пользователя!";
        public const string RequiredValidationUserInfoEmailErrorText = "Не указана электронная почта!";
        public const string PhoneRegularExpressioRegularExpression = "Номер телефона должен состоять из 10 или 11 символов!";
        public const string InfoNameEmailAddressValidationErrorText = "Некоректный формат электронной почты!";

        public const string RequiredProductNameErrorText = "Не указано название товара!";
        public const string RequiredProductDescriptionErrorText = "Не указано описание товара!";
        public const string RequiredProductCostErrorText = "Не указана цена товара!";
        public const string ProductCostNotValidErrorText = "Некорректная цена товара!Цена товара числом, от 1 до 10000";

        public const string RequiredRoleName = "Не указано название роли!";
    }
}
