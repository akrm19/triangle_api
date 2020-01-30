using System;
using System.ComponentModel.DataAnnotations;

namespace TriangleApi.Models
{
    public class TriangleVertices
    {
        [Required]
        [Range(0, 100)]
        public int TopLeftX { get; set; }

        [Required]
        [Range(0, 100)]
        public int TopLeftY { get; set; }

        [Required]
        [Range(0, 100)]
        public int BottomRightX { get; set; }

        [Required]
        [Range(0, 100)]
        public int BottomRightY { get; set; }

        [Required]
        [Range(0, 100)]
        public int MiddleX { get; set; }

        [Required]
        [Range(0, 100)]
        public int MiddleY { get; set; }

        public TriangleVertices() { }

        public TriangleVertices(int tlX, int tlY, int brX, int brY, int midX, int midY)
        {
            TopLeftX = tlX;
            TopLeftY = tlY;
            BottomRightX = brX;
            BottomRightY = brY;
            MiddleX = midX;
            MiddleY = midY;
        }
    }
}
