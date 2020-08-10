using Entities.Entities.Enums;
using Entities.Notifications;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("UserPurchase")]
    public class UserPurchase : Notifies
    {
        [Key]
        [Column("CUS_ID")]
        [Display(Name = "Código")]
        public int CUD_ID { get; set; }

        [Display(Name = "Produto")]
        [ForeignKey("Product")]
        [Column(Order = 1)]
        public int Id_Produto { get; set; }
        public virtual Product Product { get; set; }

        [Column("CUS_ESTADO")]
        [Display(Name = "Estado")]
        public EstadoCompra Estado { get; set; }

        [Column("CUS_QTD")]
        [Display(Name = "Quantidade")]
        public int Quantidade { get; set; }

        [Display(Name = "Usuário")]
        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}