using System;
using Microsoft.AspNetCore.Builder;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Error");
}


//use entityFrameworkCore?

app.MapGet("/api/Students", () => 
"Return all Students"
);

app.MapGet("/api/Contacts", () => 
"Return all Contacts"
);

app.MapPost("/api/Students/{StudentID}", () =>
{
    "return all contacts with studentID passed in as parameter"
})

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
