namespace RestaurantKrustyKrab
{
    internal class TempRemovedMethods
    {
        //public void PrintWaiters()
        //{
        //    foreach (Waiter waiter in WaiterList)
        //    {
        //        Console.SetCursorPosition(waiter.FromTop, waiter.FromLeft);
        //        if (waiter.Company != null)
        //            Console.Write(waiter.Name + " " + waiter.Company.Guests[0]);
        //    }
        //}

        //private void CompanyArrivalRandomizer()
        //{
        //    Random random = new Random();
        //    int number = random.Next(0, 100);
        //    if (number < 50 && Reception.CompanyWaitingQueue.Count < 10)
        //    {
        //        Reception.CompanyWaitingQueue.Enqueue(GenerateCompany());
        //    }
        //    if (number > 50 && Reception.CompanyWaitingQueue.Count > 0)   //Här någonstans kan vi ha en bool som en waiter styr när vi dequeuear
        //    {
        //        foreach (Company company in Reception.CompanyWaitingQueue)
        //        {
        //            company.Guests[0].FromLeft = (company.Guests[0].FromLeft - 1);
        //        }
        //    }
        //}

        //private bool bemöta_gäst(Waiter waiter)
        //{
        //    bool busy = false;

        //    if (Reception.CompanyWaitingQueue.Count > 0)
        //    {
        //        ErasePosition(waiter);
        //        waiter.FromTop = 10;
        //        waiter.FromLeft = 21;
        //        WaitersAtReception.Add(waiter);
        //        Console.SetCursorPosition((waiter.FromTop), waiter.FromLeft);
        //        waiter.Company = Reception.CompanyWaitingQueue.Dequeue();

        //        busy = true;
        //    }
        //    return busy;
        //}

        //public void PrintWaitingCompanies()
        //{
        //    int j = 0;
        //    foreach (Company company in Reception.CompanyWaitingQueue)
        //    {
        //        if (j < 10)
        //        {
        //            j++;
        //            Console.SetCursorPosition(company.Guests[0].FromTop, company.Guests[0].FromLeft);
        //            Console.Write("                          ");   //Rensar raden innan den skriver ut sällskapet
        //            if (Reception.CompanyWaitingQueue.Count > j)
        //            {
        //                Console.SetCursorPosition(company.Guests[0].FromTop, company.Guests[0].FromLeft);
        //                if (company.Guests.Count == 1)
        //                {
        //                    Console.Write("Company" + " " + j + ": " + company.Guests[0].Name); //Skriver endast ut sitt eget namn om sällskapet enbart är en person
        //                }
        //                else if (company.Guests.Count > 1)
        //                {
        //                    Console.Write("Company" + " " + j + ": " + company.Guests[0].Name + " + " + (company.Guests.Count - 1));
        //                }
        //                else
        //                {
        //                    Console.SetCursorPosition(company.Guests[0].FromTop, company.Guests[0].FromLeft);
        //                    Console.Write("                          ");
        //                }
        //            }
        //        }
        //    }
        //}
        //public Company GenerateCompany()
        //{
        //    Company company = new Company(Reception.CompanyWaitingQueue.Count); //Skapar ett nytt company objekt med offset som inparameter, vilket är storleken på sällskapet
        //    return company;
        //}

        //private bool visa_bord(Company company)
        //{
        //    bool busy = false;
        //    foreach (Table table in TableList)
        //    {
        //        if (table.Seats >= company.Guests.Count())
        //        {

        //        }

        //    }
        //    return busy;

        //}
        //if (number > 50 && MyRestaurantAreas["Reception"].CompanyAtArea.Count > 0)   //Här någonstans kan vi ha en bool som en waiter styr när vi dequeuear
        //{
        //    foreach (Company company in MyRestaurantAreas["Reception"].CompanyAtArea)
        //    {
        //        company.Guests[0].FromLeft = (company.Guests[0].FromLeft - 1);
        //    }

        //}
        //private void PrintRestaurantArea(RestaurantArea restaurantArea)
        //{
        //    PrintList(restaurantArea.GuestsAtArea);
        //    PrintList(restaurantArea.CompanyAtArea);
        //    PrintList(restaurantArea.WaitersAtArea);
        //    PrintList(restaurantArea.ChefsAtArea);

        //}
        //private void EraseRestaurantArea(RestaurantArea restaurantArea)
        //{
        //    EraseList(restaurantArea.GuestsAtArea);
        //    EraseList(restaurantArea.CompanyAtArea);
        //    EraseList(restaurantArea.WaitersAtArea);
        //    EraseList(restaurantArea.ChefsAtArea);
        //}
        //public void ErasePosition(Person person)
        //{

        //    Console.SetCursorPosition(person.FromTop, person.FromLeft);
        //    Console.WriteLine("              ");
        //    Console.SetCursorPosition(person.FromTop, person.FromLeft);

        //}
        //public void EraseList<T>(List<T> personList)
        //{
        //    int row = 0;
        //    foreach (T person in personList)
        //    {
        //        Console.SetCursorPosition((person as Person).FromLeft, ((person as Person).FromTop + row));
        //        Console.Write(new string(' ', (person as Person).Name.Length));
        //        row++;
        //    }
        //}
        //public void EraseList<T>(Queue<T> companyList)
        //{
        //    int row = 0;
        //    foreach (T company in companyList)
        //    {
        //        Console.SetCursorPosition((company as Company).Guests[0].FromTop, ((company as Company).Guests[0].FromLeft + row));
        //        Console.Write(new string(' ', (company as Company).Guests[0].Name.Length));
        //        row++;
        //    }
        //}
        //public void PrintList<T>(Queue<T> companyList)
        //{
        //    int row = 0;
        //    foreach (T company in companyList)
        //    {
        //        Console.SetCursorPosition((company as Company).Guests[0].FromTop, ((company as Company).Guests[0].FromLeft + row));
        //        Console.Write((company as Company).Guests[0].Name);
        //        //row++;
        //    }
        //}
        //public void PrintList<T>(List<T> personList)
        //{
        //    int row = 0;
        //    foreach (T person in personList)
        //    {
        //        Console.SetCursorPosition((person as Person).FromLeft, ((person as Person).FromTop + row));
        //        Console.Write((person as Person).Name);
        //        row++;
        //    }
        //}
    }
}
