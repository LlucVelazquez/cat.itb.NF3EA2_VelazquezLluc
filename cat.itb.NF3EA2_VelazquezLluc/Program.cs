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
			//Exercice2a();
			//Exercice2b();
			//Exercice2c();
			//Exercice2d("11219");
			//Exercice2e();
			//Exercice2f();
			//Exercice2g();
			//Exercice3a();
			//Exercice3b();
			//Exercice3c();
			//Exercice3d();
			Exercice3e();
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
		public static void Exercice2a()
		{
			CountryCRUD.ShowCountriesEurope();
		}
		public static void Exercice2b()
		{
			CountryCRUD.ShowOneCountry("Madagascar");
		}
		public static void Exercice2c()
		{
			BookCRUD.ShowBooksFields();
		}
		public static void Exercice2d(string zipcode)
		{
			RestaurantCRUD.ShowRestaurantsByZipCode(zipcode);
		}
		public static void Exercice2e()
		{
			RestaurantCRUD.RestaurantsChineseBronx("Bronx","Chinese");
		}
        public static void Exercice2f()
        {
			BookCRUD.ShowBooksLess130();
        }
        public static void Exercice2g()
		{
			PeopleCRUD.ShowFriendsByPeople("Caroline Webster");
        }
		public static void Exercice3a()
		{
			RestaurantCRUD.UpdateZipcode("Driggs Avenue", "10443");
		}
		public static void Exercice3b()
		{
			ProductCRUD.AddStockMinim(2000);
		}
		public static void Exercice3c()
		{
			BookCRUD.AddAuthorBook("Code Generation in Action", "Sam Watters");
		}
		public static void Exercice3d()
		{
			ProductCRUD.AddGamaField();
		}
		public static void Exercice3e()
		{
			ProductCRUD.UpdateProductCategory("MacBook Pro","notebook","ipad");
		}
		public static void Exercice3f()
		{
			ProductCRUD.UpdateStockForPriceRange(800,1000,60);
		}


	}
}
