var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

var app = builder.Build();
app.UseCors();

app.MapGet("/", () => "Välkommen till min värld");

app.MapGet("/add", (int num1, int num2) => AddNumbers(num1, num2));

app.MapGet("/subtract", (int num1, int num2) => SubtractNumbers(num1, num2));

app.MapGet("/encryptNumbers", (string numbers) => EncryptNumbers(numbers)); 
app.MapGet("/decryptNumbers", (string numbers) => DecryptNumbers(numbers));



app.Run();


string AddNumbers(int num1, int num2)
{
    return $"Summan av {num1} och {num2} är: {num1 + num2}";
}

string SubtractNumbers(int num1, int num2)
{
    return $"Differensen av {num1} och {num2} är: {num1 - num2}";
}

string EncryptNumbers(string numbers)
{
    return string.Concat(numbers.Select(c => EncryptDigit(c)));
}

string DecryptNumbers(string numbers)
{
    return string.Concat(numbers.Select(c => DecryptDigit(c)));
}

char EncryptDigit(char digit)
{
    if (!char.IsDigit(digit)) return digit; // Säkerställer att bara siffror behandlas
    int shift = 3;
    int encryptedDigit = ((digit - '0' + shift) % 10) + '0';
    return (char)encryptedDigit;
}

char DecryptDigit(char digit)
{
    if (!char.IsDigit(digit)) return digit; // Säkerställer att bara siffror behandlas
    int shift = 3;
    int decryptedDigit = ((digit - '0' - shift + 10) % 10) + '0';
    return (char)decryptedDigit;
}




