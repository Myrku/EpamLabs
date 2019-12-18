using Framework.Services;

namespace Framework.Models
{
    class CustomerEmpty
    {
        public string surname { get; set; }
        public string name { get; set; }
        public string passport { get; set; }
        public CustomerEmpty()
        {
            surname = GetCustomerEmpty("Surname");
            name = GetCustomerEmpty("Name");
            passport = GetCustomerEmpty("PassportNum");
        }
        string GetCustomerEmpty(string key)
        {
            return CustomerInfoEmptyReader.GetData(key);
        }
    }
}
