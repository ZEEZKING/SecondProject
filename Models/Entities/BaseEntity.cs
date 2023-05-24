using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewProject.Models.Entities
{
    public class  BaseEntity
    {
        public int Id;
        public bool IsDeleted;
        public DateTime DateCreated;

        public BaseEntity(int id, bool isDeleted, DateTime dateCreated)
        {
            Id = id;
            IsDeleted = isDeleted;
            DateCreated = dateCreated;
        }
    }
}