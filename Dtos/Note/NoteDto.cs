using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace notes_api.Dtos.Note
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}