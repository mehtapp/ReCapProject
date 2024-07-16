namespace Entities.Abstract
{
    public interface ICustomer : IUser
    {
        int CustomerId { get; set; }
        //public int MyProperty { get; set; }
        
    }
}