# Lith.DocStore
A document database in the most literal case.

This document storage could be used to create quick prototypes without the need of connecting to an actual database.
Lith.DocStore provides interfaces that allow you to create physical data files which can be JSON, XML or anything you can serialize.

The idea behind this is that you can run unit tests against models and logic without commiting to a database or having a connection.

# Benefits
1.  Models can live in a seperate project, which reduces the need for DTO project/objects.
2.  No setup apart from Creating your models
3.  Can be used instead of having the need to create a database when building a new project
4.  Any other benefits I couldn't think of.

# Installation
nuget: [install-package lith.docstore](https://www.nuget.org/packages/Lith.DocStore)

# Usage
1. Create Models
```C#
    public abstract class BaseRecord : IStoreable
    {
        public Guid ID { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class Transaction : BaseRecord
    {
        public bool IsExpense { get; set; }

        public Shop Shop { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
```

2. Setup Context
```C#
  public class ModelsContext : StoreContext
    {
        public ModelsContext()
            : base(new JSONModelHelper())
        {

        }

        public ItemSet<Shop> Shops { get; set; }

        public ItemSet<Transaction> Transactions { get; set; }

        public ItemSet<Summary> Summaries { get; set; }
    }
```

3. Add Record
```C#
  var shopA = new Shop
  {
      Category = "XX",
      Name = "SupermarketX"
  };

  using (var ctx = new ModelsContext())
  {
      ctx.Shops.Add(shopA);
      ctx.Save();
  }
```

4. Query Record
```C#
  using (var ctx = new ModelsContext())
  {
      var results = from a in ctx.Shops
                    where a.Name == "SupermarketX"
                    && a.Category == "XX"
                    select a;
  }
```

5. Find and Update Record
```C#
	using(var ctx = new ModelsContext())
	{
		var item = ctx.Shops.Find(id);
		item.Name = "DEF";

		ctx.Save();
	}
```

6. Have a cold one ;)
