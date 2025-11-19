using NXOpen;
using NXOpen.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXOpenSetUPCSharp
{
    public class NXUtilities
    {
        /// <summary>
        /// Converts an NXOpen.Tag to its corresponding TaggedObject instance, later convert or cast to specific types if needed like -- Point nxPoint = (Point)obj;.
        /// </summary>
        /// <remarks>This method uses the NXObjectManager to retrieve the object associated with the given
        /// tag.  Ensure that the tag is valid and corresponds to an existing object in the NXOpen
        /// environment.</remarks>
        /// <param name="tag">The tag representing the object to be retrieved.</param>
        /// <returns>The <see cref="TaggedObject"/> associated with the specified tag, or <see langword="null"/> if the tag does
        /// not correspond to a valid object.</returns>
        public static TaggedObject ConvertTagToObject(NXOpen.Tag tag)
        {
            TaggedObject obj = NXOpen.Utilities.NXObjectManager.Get(tag);
            return obj;

            //
        }
    }
}
