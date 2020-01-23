using System;
using System.ComponentModel.DataAnnotations;

namespace TriangleApi.Models
{
    public class TriangleCoordinate
    {
        [Required]
        [RegularExpression("[a-fA-F]")]
        public char Row { get; set; }

        [Required]
        [Range(1, 12)]
        public int Column { get; set; }

        public TriangleCoordinate() { }

        public TriangleCoordinate(char row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
