using Real_estate_Abboren.Models;


namespace Real_estate_Abboren.Services
{
    internal class MenuService
    {
        public async void CreateNewContactAsync()
        {
            var renter = new Renter();

            Console.Write("Förnamn: ");
            renter.FirstName = Console.ReadLine() ?? "";

            Console.Write("Efternamn: ");
            renter.LastName = Console.ReadLine() ?? "";

            Console.Write("E-postadress: ");
            renter.Email = Console.ReadLine() ?? "";

            Console.Write("Telefonnummer: ");
            renter.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Gatuadress: ");
            renter.StreetName = Console.ReadLine() ?? "";

            Console.Write("Postnummer: ");
            renter.PostalCode = Console.ReadLine() ?? "";

            Console.Write("Stad: ");
            renter.City = Console.ReadLine() ?? "";

            //save Renter to database
            await RenterService.SaveAsync(renter);
        }

        public async Task ListAllContactsAsync()
        {
            //get all renters+address from database
            var renters = await RenterService.GetAllAsync();

            if (renters.Any())
            {
                foreach (Renter renter in renters)
                {
                    Console.WriteLine($"KundNummer: {renter.Id}");
                    Console.WriteLine($"Name: {renter.FirstName} {renter.LastName}");
                    Console.WriteLine($"E-postadress: {renter.Email}");
                    Console.WriteLine($"Telefonnummer: {renter.PhoneNumber}");
                    Console.WriteLine($"E-postadress: {renter.Email}");
                    Console.WriteLine($"PostalAddress: {renter.StreetName}, {renter.PostalCode} {renter.City}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Inga kunder finns i databasen");
                Console.WriteLine("");
            }
        }

        public async Task ListSpecificContactAsync()
        {
            Console.WriteLine("Ange e-postadress på kunden: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                //get spcific renter+address from database
                var renter = await RenterService.GetAsync(email);

                if (renter != null)
                {
                    Console.WriteLine($"KundNummer: {renter.Id}");
                    Console.WriteLine($"Name: {renter.FirstName} {renter.LastName}");
                    Console.WriteLine($"E-postadress: {renter.Email}");
                    Console.WriteLine($"Telefonnummer: {renter.PhoneNumber}");
                    Console.WriteLine($"E-postadress: {renter.Email}");
                    Console.WriteLine($"PostalAddress: {renter.StreetName}, {renter.PostalCode} {renter.City}");
                    Console.WriteLine("");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Ingen kund med den angivna e-postadressen {email} hittades. ");
                    Console.WriteLine("");
                }
               
              
            }
            else
            {
                Console.WriteLine("Ingen e-postadress angiven.");
                Console.WriteLine("");
            }
        }

        public async Task UpdateSpecificContactAsync()
        {
            Console.WriteLine("Ange e-postadress på kunden: ");
            var email = Console.ReadLine();


            if (!string.IsNullOrEmpty(email))
            {

                var renter = await RenterService.GetAsync(email);

                Console.Write("Förnamn: "); 
                renter.FirstName = Console.ReadLine() ?? null!;


                Console.Write("Efternamn: ");
                renter.LastName = Console.ReadLine() ?? null!;


                Console.Write("E-postadress: ");
                renter.Email = Console.ReadLine() ?? null!;


                Console.Write("Telefonnummer: ");
                renter.PhoneNumber = Console.ReadLine() ?? null!;


                Console.Write("Gatuadress: ");
                renter.StreetName = Console.ReadLine() ?? null!;


                Console.Write("Postnummer: ");
                renter.PostalCode = Console.ReadLine() ?? null!;


                Console.Write("Stad: ");
                renter.City = Console.ReadLine() ?? null!;

                //update specific renter from database
                await RenterService.DeleteAsync(email);
            }
            else
            {
                Console.WriteLine($"Ingen e-postadress angiven.");
                Console.WriteLine("");
            }
        }





        public async Task DeleteSpecificContactAsync()
        {
            Console.WriteLine("Ange e-postadress på kunden: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                //delete specific renter from database
                await RenterService.DeleteAsync(email);
            }
            else
            {
                Console.WriteLine($"Ingen e-postadress angiven.");
                Console.WriteLine("");
            }
        }   
    }
}
