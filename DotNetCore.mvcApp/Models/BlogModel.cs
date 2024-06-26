﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCore.mvcApp.Models
{
    [Table("Tbl_Blog")]
    public class BlogModel
    {
        [Key]
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }

        public string BlogAuthor { get; set; }

        public string BlogContent { get; set; }
    }

    public class BlogMessageResponseModel
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }

    [Table("Tbl_PageStatistics")]
    public class PageStatisticsModel
    {
        [Key]
        public int PageStatisticsId { get; set; }
        public int SessionDuration { get; set; }
        public int PageViews { get; set; }
        public int TotalVisits { get; set; }
        public string CreatedDate { get; set; }
    }

    [Table("Tbl_RadarChart")]
    public class RadarModel
    {
        [Key]
        public int Id { get; set; }
        public string Month { get; set; }
        public int Series { get; set; }
    }

    public class ApexChartRadarResponseModel
    {
        public List<int> Series { get; set; }
        public List<string> Labels { get; set; }
    }

    [Table("Tbl_DataPoints")]
    public class CanvasBarModel
    {
        [Key]
        public int Id { get; set; }
        public string Country { get; set; }

        public decimal GTBRate { get; set; }
    }
    public class CanvasBarResponseModel
    {
        public string label { get; set; }

        public decimal y { get; set; }
    }

    [Table("Tbl_JSBarChart")]
    public class JSChartModel
    {
        [Key]
        public int Id { get; set; }
        public string Month { get; set; }
        public int Points { get; set; }
    }

    public class JSChartResponseModel
    {
        public List<string> Labels { get; set; }
        public List<int> Series { get; set; }
    }
}
