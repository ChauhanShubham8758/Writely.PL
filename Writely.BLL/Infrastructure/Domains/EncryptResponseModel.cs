namespace Writely.BLL.Infrastructure.Domains
{
    public class EncryptResponseModel
    {
        public string Hash { get; set; }
        public byte[] Salt { get; set; }
    }
}
