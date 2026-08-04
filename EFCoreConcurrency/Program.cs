using EFCoreConcurrency;
using Microsoft.EntityFrameworkCore;

await using var context1 = new AppDbContext();
await using var context2 = new AppDbContext();

// يجب تحميل النسختين قبل تنفيذ أي SaveChanges
var product1 = await context1.Products
    .SingleAsync(p => p.Id == 1);

var product2 = await context2.Products
    .SingleAsync(p => p.Id == 1);

Console.WriteLine(
    $"Context 1 RowVersion: {Convert.ToHexString(product1.RowVersion)}");

Console.WriteLine(
    $"Context 2 RowVersion: {Convert.ToHexString(product2.RowVersion)}");

// المستخدم الأول يعدّل ويحفظ
product1.Price = 29.99m;

await context1.SaveChangesAsync();

Console.WriteLine("Context 1 saved successfully.");

Console.WriteLine(
    $"Context 1 new RowVersion: {Convert.ToHexString(product1.RowVersion)}");

// المستخدم الثاني يعدّل نسخة قديمة
product2.Price = 291.99m;

try
{
    await context2.SaveChangesAsync();

    Console.WriteLine("Context 2 saved successfully.");
}
catch (DbUpdateConcurrencyException ex)
{
    Console.WriteLine("Concurrency conflict detected.");

    foreach (var entry in ex.Entries)
    {
        var databaseValues = await entry.GetDatabaseValuesAsync();

        if (databaseValues is null)
        {
            Console.WriteLine("The record was deleted by another user.");
            continue;
        }

        var currentProduct = (Product)entry.Entity;
        var databaseProduct = (Product)databaseValues.ToObject();

        Console.WriteLine($"Attempted price: {currentProduct.Price}");
        Console.WriteLine($"Database price: {databaseProduct.Price}");

        Console.WriteLine(
            $"Old RowVersion: {Convert.ToHexString(currentProduct.RowVersion)}");

        Console.WriteLine(
            $"Database RowVersion: {Convert.ToHexString(databaseProduct.RowVersion)}");
    }
}