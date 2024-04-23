
using Beneyetna.DataContracts.Enums;

namespace Beneyetna.DataContracts.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Status { get; set; } = (int) EStatus.Active;

    }
}
