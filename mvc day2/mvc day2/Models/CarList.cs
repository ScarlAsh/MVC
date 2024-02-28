namespace mvc_day2.Models
{
	public class CarList 
	{
		public static List<Car> Cars { get; set; } = new List<Car>()
		{
				new Car { Num = 1 , Color = "Red" , Manfacure = "Audi" , Model = "V177"} ,
				new Car { Num = 2 , Color = "Blue" , Manfacure = "Ferari" , Model = "MS324"},
				new Car { Num = 3 , Color = "Green" , Manfacure = "Ford" , Model = "KG980"},
				new Car { Num = 4 , Color = "White" , Manfacure = "BMW" , Model = "QWE34"},
			
		};









		
	}
}
