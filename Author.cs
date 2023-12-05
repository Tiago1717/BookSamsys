
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Book;

namespace authors;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
}