﻿// Inkluderer navneområdet for DTOs (Data Transfer Objects).
using MomentozClientApp.ModelLayer;

// Definerer navneområdet for forretningslogiklaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.BusinessLogicLayer
{
    // ICustomerdata er et interface, der definerer kontrakten for operationer relateret til kunde-data.
    public interface ICustomerdata
    {
        // Metode til at hente en specifik kunde baseret på dens id og returnere den som en CustomerDto.
        Customer Get(string email);

        // Metode til at hente en liste af alle kunder og returnere dem som CustomerDto'er.
        List<Customer>? Get();

        // Metode til at tilføje en ny kunde. Modtager en CustomerDto og returnerer et id for den tilføjede kunde.
        int Add(Customer customerToAdd);

        // Metode til at opdatere en eksisterende kunde. Modtager en CustomerDto og returnerer en boolsk værdi, der indikerer, om opdateringen var succesfuld.
        bool Put(Customer customerToUpdate);

        // Metode til at slette en kunde baseret på dens id. Returnerer en boolsk værdi, der indikerer, om sletningen var succesfuld.
        bool Delete(int id);

        // Metode til at hente en kunde baseret på en brugers login-id og returnere den som en CustomerDto.
        Customer? GetByUserId(string loginid);
    }
}
