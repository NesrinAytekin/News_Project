using News_Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News_Project.Map.Mapping
{
    //Önceden Attribute Bazında entity yapıyorduk artık prof. olarak yapıyoruz bunu.Bu sınıf diğer bütün entitylerime kalıtım verecek olan Map'im.
    // "T" demek ilerleyen safhalarda tip bağımsız jenerik birşey gönderebilrim Like,Category, Appuser..vb
    //:EntityTypeConfiguration : Bu Yapıyı bana EntityFrameWork sağladıgından projeye indirilir.
    public class CoreMap <T> :EntityTypeConfiguration<T> where T: BaseEntity
    {
        public CoreMap()//Burada yapıcı metotda içerisinde propertiy'lerimi mapliyorum yani şekil şemalini belirtiyorum
        {
            Property(x => x.Id).HasColumnName("Id").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Status).HasColumnName("Status").IsRequired();
            Property(x => x.CreateDate).HasColumnName("CreateDate").IsRequired();
            Property(x => x.UpdateDate).HasColumnName("UpdateDate").IsOptional();
            Property(x => x.DeleteDate).HasColumnName("DeleteDate").IsOptional();
        }
    }
}
