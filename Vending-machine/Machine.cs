class Machine
{

    //Kolla varför stock contoll inte funkar.
    //Ska Inventory och Person ha constructor?

    Inventory pepsi = new Inventory()
    {
        Name = "pepsi",
        Price = 20,
        Id = 1,
        AmountInStock = 1
    };
    Inventory Kexchoklad = new Inventory()
    {
        Name = "kexchoklad",
        Price = 10,
        Id = 2,
        AmountInStock = 2
    };
    Inventory hubbabubba = new Inventory()
    {
        Name = "Hubbabubba",
        Price = 5,
        Id = 3,
        AmountInStock = 1
    };
    Inventory Fanta = new Inventory()
    {
        Name = "Fanta",
        Price = 20,
        Id = 4,
        AmountInStock = 1
    };
    Inventory Chips = new Inventory()
    {
        Name = "Chips",
        Price = 25,
        Id = 5,
        AmountInStock = 1
    };

    Person costumer = new Person(20);

    public void Run()
    {
        bool keepRunning = false;

        Console.WriteLine("*** Welcome please choose your product ***");

        while (!keepRunning)
        {
            Console.WriteLine($"*** You have enterd {costumer.Money}:- ***");
            Console.WriteLine("Choose your product by id");
            Console.WriteLine($"#{pepsi.Id} In stock {pepsi.AmountInStock}------------- {pepsi.Name} {pepsi.Price}:-");
            Console.WriteLine($"#{Kexchoklad.Id} In stock {Kexchoklad.AmountInStock} ------------ {Kexchoklad.Name} {Kexchoklad.Price}:-");
            Console.WriteLine($"#{hubbabubba.Id} In stock {hubbabubba.AmountInStock} ------------ {hubbabubba.Name} {hubbabubba.Price}:-");
            Console.WriteLine("");
            Console.WriteLine("Enter quit to exit.");
            Console.WriteLine("Enter add to add money.");

            var input = Console.ReadLine();

            if (!int.TryParse(input, out int chioce))
            {
                if (input.ToLower() == "quit")
                {
                    break;
                }
                if (input.ToLower() == "add")
                {
                    Add();
                    continue;
                }
                Console.WriteLine("Please enter a numer or valid command.");
                continue;
            }

            if (chioce == 1)
            {
                if (!CheckStock(pepsi.AmountInStock))
                    continue;

                Pay(pepsi.Price, pepsi.AmountInStock, pepsi);
            }
            else if (chioce == 2)
            {
                if (!CheckStock(pepsi.AmountInStock))
                    continue;

                Pay(Kexchoklad.Price, Kexchoklad.AmountInStock, Kexchoklad);
            }
            else if (chioce == 3)
            {
                if (!CheckStock(pepsi.AmountInStock))
                    continue;

                Pay(hubbabubba.Price, hubbabubba.AmountInStock, hubbabubba);
            }
        }
    }

    private void Pay(int price, int amountInStock, Inventory name)
    {
        int money = costumer.Money;

        if (price > money)
        {
            Console.WriteLine("Not enough, sorry... Add more money.");
            return;
        }
        if (price == money)
        {
            Console.WriteLine($"Here is your {name.Name}");
            Console.WriteLine("Welcome back!");
        }
        if (price < money)
        {
            int change = money - price;
            Console.WriteLine($"Here is your {name.Name}");
            Console.WriteLine($"You change is:{change}:-");
            Console.WriteLine("Welcome back!");
        }
        costumer.Money = costumer.Money - price;
        name.AmountInStock = name.AmountInStock - 1;
    }

    private void Add()
    {
        bool isValid = true;

        while (isValid)
        {
            Console.WriteLine("How much would you like to add?");

            var input = Console.ReadLine();

            if (!int.TryParse(input, out int chioce))
            {
                Console.WriteLine("Please enter a valid number...");
                return;
            }
            else if (chioce > 100)
            {
                Console.WriteLine("Sorry maximum amount to enter is 100:-");
                continue;
            }

            costumer.Money = chioce + costumer.Money;
            break;
        }
    }

    private bool CheckStock(int amount)
    {
        if (amount <= 1)
        {
            return true;
        }
        Console.WriteLine("Sorry we are out, choose another product");
        return false;
    }

}

