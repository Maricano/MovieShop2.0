using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreDTO
{
    public abstract class AbstractDTOConverter<domainModel, dataTransferObject>
    {
        public IEnumerable<dataTransferObject> Convert(IEnumerable<domainModel> toConvert)
        {
            List<dataTransferObject> converted = new List<dataTransferObject>();
            foreach (var item in toConvert)
            {
                converted.Add(Convert(item));
            }
            return converted;
        }

        public abstract dataTransferObject Convert(domainModel item);
    }
}
