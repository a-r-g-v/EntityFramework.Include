# EntityFramework.Include

A library that extends Include of Entity Framework to provide filtering navigation property.

Required EntityFramework version is 6.1.3.

##Download
EntityFramework.Include is available on nuget.org -> [EntityFramework.Include](https://www.nuget.org/packages/EntityFramework.Include/)

To install EntityFramework.Include, run the following command in Package Manager Console.

    PM> Install-Package EntityFramework.Include

##Usage
```c#
    //Required using EntityFramework.Include.Extensions
    
    //Example Entity...
    public class Parent
    {
        public int Id { get; set; }

        public int Age { get; set; }
        
        [NotMapped]
        public int ChildrenCount { get; set; }

        public List<Child> Children { get; set; } = new List<Child>();
    }
    
    public class Child
    {
        public int Id { get; set; }

        public int Age { get; set; }
    }
    
    //In code...
    var list = context.ParentSet.Include(p => p.Children, p => p.Children.Take(10).ToList())
                                .Include(p => P.ChildrenCount, p => p.Children.Count)
                                .ToListWithInclude();
    
    Console.WriteLine(list.First().Children.Count); //10
    Console.WriteLine(list.First().ChildrenCount); //output all Children count

To retrieve as List or T[], use `ToListWithInclude/Aysnc` or `ToArrayWithInclude/Aysnc`
    
    var list = context.ParentSet.Include(p => p.Children, p => p.Children.Take(10).ToList())
                                .Include(p => P.ChildrenCount, p => p.Children.Count)
                                .ToListWithInclude();
                                
    var array = context.ParentSet.Include(p => p.Children, p => p.Children.Take(10).ToList())
                                .Include(p => P.ChildrenCount, p => p.Children.Count)
                                .ToArrayWithInclude();
                                
If include same property, the last include will be preferred

    var list = context.ParentSet.Include(p => p.Children, p => p.Children.Take(10).ToList())
                                .Include(p => p.Children, p => p.Children.Take(20).ToList()) //duplicate
                                .Include(p => P.ChildrenCount, p => p.Children.Count)
                                .ToListWithInclude();
                                
    Console.WriteLine(list.First().Children.Count); //20
```
