﻿namespace Proiect_ASP.Models.Base
{
    public class IBaseEntity
    {
        Guid Id { get; set; }
        DateTime? DateCreated { get; set; }
        DateTime? DateModified { get; set; }

    }
}
