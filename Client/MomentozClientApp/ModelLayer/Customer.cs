// Definerer navneområdet for modellaget i MomentozClientApp-applikationen.
namespace MomentozClientApp.ModelLayer
{
    // Customer-klassen repræsenterer en kunde i systemet.
    public class Customer
    {
        // Standardkonstruktør uden parametre.
        public Customer() { }

        // Konstruktør, der tager kundens grundlæggende informationer.
        public Customer(string? firstName, string? lastName, string? mobilePhone, string? email)
        {
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
        }

        // Udvidet konstruktør, der inkluderer loginUserId, udover grundlæggende informationer.
        public Customer(string? firstName, string? lastName, string? mobilePhone, string? email, string? loginUserId)
        {
            FirstName = firstName;
            LastName = lastName;
            MobilePhone = mobilePhone;
            Email = email;
            LoginUserId = loginUserId;
        }

        // Konstruktør, der inkluderer et id, og kalder en anden konstruktør for at sætte de grundlæggende informationer.
        public Customer(int id, string? firstName, string? lastName, string? mobilePhone, string? email) : this(firstName, lastName, mobilePhone, email)
        {
            Id = id;
        }

        // Egenskaber for at holde kundens id, navn, mobiltelefonnummer, email og loginUserId.
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MobilePhone { get; set; }
        public string? Email { get; set; }
        public string? LoginUserId { get; set; }

        // Egenskab for at tjekke, om en kunde mangler væsentlige informationer som f.eks. fornavn eller efternavn.
        public bool IsCustomerEmpty
        {
            get
            {
                bool customerIsEmpty = false;
                if (String.IsNullOrWhiteSpace(FirstName) || String.IsNullOrWhiteSpace(LastName))
                {
                    customerIsEmpty = true;
                }
                return customerIsEmpty;
            }
        }
    }
}
