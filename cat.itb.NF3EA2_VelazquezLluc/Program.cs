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
			const string Msg = "0: Sortir \n1: Exercici1 \n2a: Exercici2a \n2b: Exercici2b \n2c: Exercici2c \n2d: Exercici2d " +
				"\n2e: Exercici2e \n2f: Exercici2f \n2g: Exercici2g \n3a: Exercici3a \n3b: Exercici3b \n3c: Exercici3c \n3d: Exercici3d" +
				"\n3e: Exercici3e \n3f: Exercici3f \n3g: Exercici3g \n4a: Exercici4a \n4b: Exercici4b \n4c: Exercici4c \n4d: Exercici4d " +
				"\n4e: Exercici4e \n4f: Exercici4f \n4g: Exercici4g \n4h: Exercici4h \n5: Exercici5";
			bool flag = true;
			while (flag)
			{
				Console.WriteLine(Msg);
				string num = Console.ReadLine();
				switch (num)
				{
					case "1":
						LoadAllCollections();
						break;
					case "2a":
						Exercice2a();
						break;
					case "2b":
						Exercice2b();
						break;
					case "2c":
						Exercice2c();
						break;
					case "2d":
						Exercice2d("11219");
						break;
					case "2e":
						Exercice2e();
						break;
					case "2f":
						Exercice2f();
						break;
					case "2g":
						Exercice2g();
						break;
					case "3a":
						Exercice3a();
						break;
					case "3b":
						Exercice3b();
						break;
					case "3c":
						Exercice3c();
						break;
					case "3d":
						Exercice3d();
						break;
					case "3e":
						Exercice3e();
						break;
					case "3f":
						Exercice3f();
						break;
					case "3g":
						Exercice3g();
						break;
					case "4a":
						Exercice4a();
						break;
					case "4b":
						Exercice4b();
						break;
					case "4c":
						Exercice4c();
						break;
					case "4d":
						Exercice4d();
						break;
					case "4e":
						Exercice4e();
						break;
					case "4f":
						Exercice4f();
						break;
					case "4g":
						Exercice4g();
						break;
					case "4h":
						Exercice4h();
						break;
					case "5":
						Exercice5();
						break;
					default:
						flag = false;
						break;
				}
			}
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
		public static void Exercice3g()
		{
			CountryCRUD.AddCallingCodeToIceland(356);
		}
		public static void Exercice4a()
		{
			RestaurantCRUD.DeleteRestaurantsInManhattan();
		}
		public static void Exercice4b()
		{
			ProductCRUD.RemoveFirstCategory("iPhone 7");
		}
		public static void Exercice4c()
		{
			BookCRUD.DeleteBooksWithPageCountBetween(0, 100);
		}
		public static void Exercice4d()
		{
			ProductCRUD.DeleteProductByName("Apple TV");
		}
		public static void Exercice4e()
		{
			BookCRUD.RemoveLastCategoryByISBN(1933988177);
		}
		public static void Exercice4f()
		{
			ProductCRUD.DeleteProductsByCategory("phone");
		}
		public static void Exercice4g()
		{
			PeopleCRUD.RemoveTagsFromTeachers();
		}
		public static void Exercice4h()
		{
			CountryCRUD.DeleteCountriesByLanguage("Spanish");
		}
		public static void Exercice5()
		{
			GeneralCRUD.DropCollection("itb", "books");
			GeneralCRUD.DropCollection("itb", "countries");
			GeneralCRUD.DropCollection("itb", "grades");
			GeneralCRUD.DropCollection("itb", "people");
			GeneralCRUD.DropCollection("itb", "products");
			GeneralCRUD.DropCollection("itb", "restaurants");
			GeneralCRUD.DropCollection("itb", "students");
		}
	}
}
