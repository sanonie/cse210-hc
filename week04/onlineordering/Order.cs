using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products;
    }

    public List<Product> Products => _products;
    public Customer Customer => _customer;

    public double CalculateTotalCost()
    {
        double total = 0;

        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }

        if (_customer.LivesInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        var label = new StringBuilder();
        label.AppendLine("Packing Label:");

        foreach (var product in _products)
        {
            label.AppendLine($"{product.GetName()} - {product.GetProductId()}");
        }

        return label.ToString();
    }

    public string GetShippingLabel()
    {
        var label = new StringBuilder();
        label.AppendLine("Shipping Label:");
        label.AppendLine(_customer.GetName());
        label.Append(_customer.GetAddress().GetFullAddress());
        return label.ToString();
    }
}