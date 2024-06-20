using ProtoBuf;

namespace PhoneChipSales.Core.Services
{
    public class CustomerService
    {
        public byte[] SerializeCustomer(Customer customer)
        {
            using (var output = new MemoryStream())
            {
                Serializer.Serialize(output, customer);
                return output.ToArray();
            }
        }

        public Customer DeserializeCustomer(byte[] data)
        {
            using (var input = new MemoryStream(data))
            {
                return Serializer.Deserialize<Customer>(input);
            }
        }
    }
}
