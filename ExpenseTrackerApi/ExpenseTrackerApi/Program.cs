using ExpenseTrackerApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.RegisterExpenseTrackerEndpoints();

app.Run();
