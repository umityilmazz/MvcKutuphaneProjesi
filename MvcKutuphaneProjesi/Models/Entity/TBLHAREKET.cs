//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcKutuphaneProjesi.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLHAREKET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLHAREKET()
        {
            this.TBLCEZALARs = new HashSet<TBLCEZALAR>();
        }
    
        public int hareket_id { get; set; }
        public Nullable<int> kitap_id { get; set; }
        public Nullable<int> uye_id { get; set; }
        public Nullable<byte> personel_id { get; set; }
        public Nullable<System.DateTime> hareket_alistarih { get; set; }
        public Nullable<System.DateTime> hareket_iadetarih { get; set; }
        public Nullable<System.DateTime> hareket_uyeningetirdigitarih { get; set; }
        public Nullable<bool> hareket_islemdurum { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLCEZALAR> TBLCEZALARs { get; set; }
        public virtual TBLKITAP TBLKITAP { get; set; }
        public virtual TBLPERSONEL TBLPERSONEL { get; set; }
        public virtual TBLUYELER TBLUYELER { get; set; }
    }
}
