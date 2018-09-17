namespace WebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EMPLOYEE_DETAILS.TBL_USER")]
    public partial class TBL_USER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long USER_ID { get; set; }

        [StringLength(64)]
        public string LOGIN { get; set; }

        [StringLength(128)]
        public string NAME { get; set; }

        [StringLength(128)]
        public string DESIGNATION { get; set; }

        [StringLength(50)]
        public string PASSWORD { get; set; }

        [StringLength(128)]
        public string EMAIL { get; set; }

        [StringLength(128)]
        public string DEPARTMENT { get; set; }

        public byte? LOGIN_ATTEMPTS { get; set; }

        public bool? IS_PASSWORD_CHANGE_REQUIRED { get; set; }

        public bool? IS_LOCKED { get; set; }

        public bool? IS_ACTIVE { get; set; }

        public DateTime? PASSWORD_CHANGED_ON { get; set; }

        public DateTime? LAST_LOGIN_ON { get; set; }

        public bool? IS_EMAIL_REQUIRED { get; set; }


    }
}
