using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchtitecture.Domain.Base
{
    public abstract class Entity : IEntity
    {
        //Base Classtan direk olarak Nesne oluşturmadığımız için Abstract class ile yazıyoruz ve abstract classlar new lenemez.
        //Interfaceden kalıtım almamızın sebebi her tabloda oluşturulacak modellerin kalıtımını zorunlu tutmaktır. Bunu direk modellere değil araya bir enetity classı koyarak yapıyoruz.
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string ActionUser { get; set; }
        public long? UserId { get; set; }
        public bool IsDeleted { get; set; }
        public long CreatedDate { get; set; }
        public long? ModifiedDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RecordDate { get; set; }
        
        public Entity()
        {
            CreatedDate = long.Parse("0");
            ModifiedDate = long.Parse("0");
            IsDeleted = false;
        }
    }
}
