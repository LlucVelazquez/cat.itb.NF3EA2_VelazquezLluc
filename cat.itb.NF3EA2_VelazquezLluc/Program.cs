using System;
using cat.itb.NF3EA2_VelazquezLluc.cruds;
using cat.itb.NF3EA2_VelazquezLluc.connections;
namespace cat.itb.NF3EA2_VelazquezLluc
{
    public class Program
    {
        public BookCRUD bookCRUD = new BookCRUD();
        public CountryCRUD countryCRUD = new CountryCRUD();
        public GradeCRUD gradeCRUD = new GradeCRUD();
        public PeopleCRUD peopleCRUD = new PeopleCRUD();
        public ProductCRUD productCRUD = new ProductCRUD();
        public RestaurantCRUD restaurantCRUD = new RestaurantCRUD();
        public StudentCRUD studentCRUD = new StudentCRUD();
		public static void Main(string[] args)
        {
			//LoadAllCollections();
		}
		public static void LoadAllCollections()
        {
			BookCRUD.LoadBooksCollection();
			CountryCRUD.LoadCountriesCollection();
			GradeCRUD.LoadGradesCollection();
			PeopleCRUD.LoadPeopleCollection();
			ProductCRUD.LoadProductsCollection();
			RestaurantCRUD.LoadRestaurantCollection();
			StudentCRUD.LoadStudentsCollection();
		}

	}
}
