var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Välkommen till vår räkneapplikation!");

app.MapGet("/add", (int num1, int num2) => AddNumbers(num1, num2));
app.MapGet("/multiplication", (int num1, int num2) => MultiplyNumbers(num1, num2));

app.Run();

string AddNumbers(int num1, int num2)
{
    return $"Summan av {num1} och {num2} = {num1 + num2}.";
}

string MultiplyNumbers(int num1, int num2)
{
    return $"Produkten av {num1} och {num2} = {num1 * num2}.";
}
