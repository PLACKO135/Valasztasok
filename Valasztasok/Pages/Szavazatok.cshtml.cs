﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Valasztasok.Models;

namespace Valasztasok.Pages
{
    public class SzavazatokModel : PageModel
    {
        private readonly Valasztasok.Models.Valasztas_db_Context _context;

        public SzavazatokModel(Valasztasok.Models.Valasztas_db_Context context)
        {
            _context = context;
        }

        public IList<Jelolt> Jelolt { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Jelolt = await _context.Jeloltek.ToListAsync();
        }
    }
}
