//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IDove
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fancier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fancier()
        {
            this.Pigeon = new HashSet<Pigeon>();
        }
        public Fancier(string IdFancier, int IdSection,int IdDovecote, string FirstName, string LastName, string Adress, string City, string Mail, string Telephone_Number)
        {
            this.IdFancier = IdFancier;
            this.IdSection = IdSection;
            this.IdDovecote = IdDovecote;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Adress = Adress;
            this.City = City;
            this.Mail = Mail;
            this.Telephone_Number = Telephone_Number;
        }
    
        public string IdFancier { get; set; }
        public int IdSection { get; set; }
        public int IdDovecote { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Mail { get; set; }
        public string Telephone_Number { get; set; }
    
        public virtual Dovecote Dovecote { get; set; }
        public virtual Section Section { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pigeon> Pigeon { get; set; }
    }
}
