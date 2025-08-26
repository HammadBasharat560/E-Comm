namespace E_Comm.Server.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal Price { get; set; }

        //navigation property and foriegb key
        public int SellerId { get; set; }
        public User Seller { get; set; }
    }
}
