using EfExamples;

var _context = new AppDbContext();

var custOrders = from c in _context.Customers
                 join o in _context.Orders
                    on c.Id equals o.CustomerId
                join ol in _context.OrderLines
                    on o.Id equals ol.OrdersId
                where c.Id == 1
                 select new
                 {
                     OrderDate = o.Date,
                     o.Description,
                     Customer = c.Name,
                     Product = ol.Product,
                     Quantity = ol.Quantity,
                     Price = ol.Price,
                     LineTotal = ol.Quantity * ol.Price
                 };

custOrders.ToList().ForEach(c => Console.WriteLine($"{c.OrderDate} | {c.Description} | {c.Customer} | {c.Product} | {c.Quantity} | {c.Price} | {c.LineTotal}")
);

/*
var orders = _context.Orders.ToList();
orders.ForEach(o => Console.WriteLine(o));
*/








/*
var customers = from c in _context.Customers
                where c.City == "Cincinnati"
                orderby c.Name
                select c;

*/

//Get all customers
/*
foreach(var cust in _context.Customers.ToList())
{
    Console.WriteLine(cust);
}
*/

// Get by Primary Key
//Console.WriteLine(_context.Customers.Find(1));

//Insert Customer
/*
var newCust = new Customer()
{
    Id = 0,
    Code = "MTT",
    Name = "Max",
    City = "Mason",
    State = "OH",
    Active = true
};
_context.Customers.Add(newCust);
_context.SaveChanges();
*/

//Update Customer
/*
var updCustomer = _context.Customers.Find(45);
if (updCustomer == null) return;
updCustomer.Code = "MXT3";
_context.SaveChanges();
*/

//Delete Customers
/*
int id = 47;
var delCust = _context.Customers.Find(id);
if(delCust == null) return;
_context.Remove(delCust);
_context.SaveChanges();

*/