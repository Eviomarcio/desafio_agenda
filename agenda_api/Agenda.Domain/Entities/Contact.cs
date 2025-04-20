using System.Text.RegularExpressions;
using Agenda.Domain.Exceptions;

namespace Agenda.Domain.Entities
{
    public class Contact : Base
    {
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public int IdAgenda { get; private set; }

        public Contact(string name, string email, string phone, int idAgenda)
        {
            SetName(name);
            SetEmail(email);
            SetPhone(phone);
            IdAgenda = idAgenda;
        }

        public Contact(int id, string name, string email, string phone, int idAgenda)
        {
            SetId(id);
            SetName(name);
            SetEmail(email);
            SetPhone(phone);
            IdAgenda = idAgenda;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name cannot be empty.");
            Name = name;
        }

        public void SetEmail(string email)
        {
            if (!IsValidEmail(email))
                throw new DomainException("Invalid email format.");
            Email = email;
        }

        public void SetPhone(string phone)
        {
            if (!Regex.IsMatch(phone, @"^\d{10,15}$"))
                throw new DomainException("Phone number must be between 10 and 15 digits.");
            Phone = phone;
        }

        public bool IsDuplicate(Contact other)
        {
            return this.Email.Equals(other.Email, StringComparison.OrdinalIgnoreCase) ||
                   this.Phone.Equals(other.Phone);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}