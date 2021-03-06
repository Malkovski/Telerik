//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompanySampleDataImporter.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMPLOYEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EMPLOYEE()
        {
            this.EMPLOYEES1 = new HashSet<EMPLOYEE>();
            this.PROJECTS_EMPLOYEES = new HashSet<PROJECTS_EMPLOYEES>();
            this.REPORTS = new HashSet<REPORT>();
        }
    
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public decimal yearSalary { get; set; }
        public Nullable<int> managerId { get; set; }
        public int departmentId { get; set; }
    
        public virtual DEPARTMENT DEPARTMENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EMPLOYEE> EMPLOYEES1 { get; set; }
        public virtual EMPLOYEE EMPLOYEE1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROJECTS_EMPLOYEES> PROJECTS_EMPLOYEES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<REPORT> REPORTS { get; set; }
    }
}
