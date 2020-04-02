using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


namespace Tasak.Api.Models
{
    public class StudentLogin
    {
        [Required]
        public string Nick { get; set; }
        [Required]
        public int? Pin { get; set; }
        [Required]
        public string ConnectionId { get; set; }
    }
}
