// https://dotnet.libhunt.com/categories/1836-template-engine
// https://dotnet.libhunt.com/scriban-alternatives
// https://github.com/scriban/scriban
// https://shopify.github.io/liquid/tags/variable/
// https://github.com/scriban/scriban/blob/master/doc/language.md

using Scriban;
using static System.Console;

var template = Template.Parse("Hello {{name}}!");
var result = template.Render(new { Name = "World" });
WriteLine(result);

template = Template.ParseLiquid("Hello {{name}}!");
result = template.Render(new { Name = "World" });
WriteLine(result);

template = Template.Parse(@"
<ul id='products'>
  {{ for product in products }}
    <li>
      <h2>{{ product.name }}</h2>
           Price: {{ product.price }}
           {{ product.description | string.truncate 15 }}
    </li>
  {{ end }}
</ul>
");
result = template.Render(new { Products = new[] {
        new { Name = "Product 1", Price = 123.45, Description ="DescriptionDescriptionDescription" },
        new { Name = "Product 2", Price = 678.90, Description ="Description" }
    }
});
WriteLine(result);

template = Template.Parse(@"
Dear {{ model.name }},

Your order, {{ model.order_id}}, is now ready to be collected.

Your order shall be delivered to {{ model.address }}.  If you need it delivered to another location, please contact as ASAP.

Order: {{ model.order_id}}
Total: {{ model.total | math.format ""c"" ""en-US"" }}

Items:
------
{{- for item in model.items }}
 * {{ item.quantity }} x {{ item.name }} - {{ item.total | math.format ""c"" ""en-US"" }}
{{- end }}

Thanks,
BuyFromUs
");
result = template.Render(new
{
    Model = new
    {
        Name = "Bob Smith", Address = "1 Smith St, Smithville", OrderId = "123455", Total = 23435.34,
        Items = new[]
        {
            new { Name = "1kg carrots", Quantity = 1, Total = 4.99 },
            new { Name = "2L Milk", Quantity = 1, Total = 3.5 }
        }
    }
});
WriteLine(result);
