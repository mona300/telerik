using System.Collections.ObjectModel;

namespace WithDataForm
{
	public class ViewModel
	{
		public ObservableCollection<Country> Countries { get; set; }

		public Person CurrentPerson { get; set; }

		public ViewModel()
		{
			this.Countries = new ObservableCollection<Country>()
			{
				new Country() { Name = "Australia" , Capital = "Canberra" },
				new Country() { Name = "Bulgaria", Capital = "Sofia" },
				new Country() { Name = "Canada" , Capital = "Ottawa" },
				new Country() { Name = "Denmark" , Capital = "Copenhagen" },
				new Country() { Name = "France" , Capital = "Paris" },
				new Country() { Name = "Germany" , Capital = "Berlin" },
				new Country() { Name = "India" , Capital = "New Delhi" },
				new Country() { Name = "Italy" , Capital = "Rome" },
				new Country() { Name = "Norway" , Capital = "Oslo" },
				new Country() { Name = "Russia" , Capital = "Moscow" },
				new Country() { Name = "Spain " , Capital = "Madrid" },
				new Country() { Name = "United Kingdom" , Capital = "London" },
				new Country() { Name = "United States" , Capital = "Washington, D.C." },
			};
			this.CurrentPerson = new Person()
			{ 
				Name = "Person 1",
				SelectedCountry = this.Countries[0],
				SelectedCountries = new ObservableCollection<Country>()
				{ 
					this.Countries[0],
					this.Countries[1]
				} 
			};
		}
	}
}
