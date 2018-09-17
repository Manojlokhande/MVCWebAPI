namespace WebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLOYEE_DETAILS.TBL_EMPLOYEE")]
    public partial class TBL_EMPLOYEE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long EMP_ID { get; set; }

        [StringLength(64)]
        public string FIRST_NAME { get; set; }

        [StringLength(128)]
        public string LAST_NAME { get; set; }

        [StringLength(25)]
        public string GENDER { get; set; }

        public double SALARY { get; set; }
    }
}
