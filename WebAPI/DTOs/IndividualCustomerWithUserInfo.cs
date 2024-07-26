namespace WebAPI.DTOs
{
    public class IndividualCustomerWithUserInfo
    {
        public int IndividualCustomerId { get; set; } //uniq data oluşturmak amaçlı eklenmiştir. Datalar çekilirken kalıtım aldığı Customer tablosundaki (müşteri) Id'si ile kullanılacaktır.

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
