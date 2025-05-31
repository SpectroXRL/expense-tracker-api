using ExpenseTrackerApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApi.Endpoints
{
    public static class ExpenseTrackerEndpoints
    {
        private static readonly List<Expense> expenses = new List<Expense>() 
        {
            new Expense
            {
                Id = Guid.NewGuid(),
                Name = "Coffee",
                Amount = 3.50m,
                Category = new Category { Id = Guid.NewGuid(), Name = "Food" },
                Date = DateTime.UtcNow
            },
            new Expense
            {
                Id = Guid.NewGuid(),
                Name = "Bus Ticket",
                Amount = 2.00m,
                Category = new Category { Id = Guid.NewGuid(), Name = "Transport" },
                Date = DateTime.UtcNow
            }
        };
        public static void RegisterExpenseTrackerEndpoints(this WebApplication app)
        {
            app.MapGet("/expenses", () =>
            {
                return TypedResults.Ok(expenses);
            });

            app.MapPost("/expenses", ([FromBody]Expense expense) =>
            {
                expense.Id = Guid.NewGuid();
                expense.Date = DateTime.UtcNow;
                expenses.Add(expense);
            });

            app.MapPut("/expenses/{id}", Results<NoContent, NotFound>(Guid id, [FromBody]Expense updatedExpense) =>
            {
                var existingExpense = expenses.FirstOrDefault(e => e.Id == id);

                if (existingExpense != null)
                {
                    existingExpense.Name = updatedExpense.Name;
                    existingExpense.Amount = updatedExpense.Amount;
                    existingExpense.Category = updatedExpense.Category;
                    existingExpense.Date = updatedExpense.Date;

                    return TypedResults.NoContent();
                }
                else
                {
                    return TypedResults.NotFound();
                }
            });

            app.MapDelete("/expenses/{id}", Results<NoContent, NotFound>(Guid id) =>
            {
                var expense = expenses.FirstOrDefault(e => e.Id == id);
                if (expense != null)
                {
                    expenses.Remove(expense);
                    return TypedResults.NoContent();
                }
                return TypedResults.NotFound();
            });
        }
    }
}
