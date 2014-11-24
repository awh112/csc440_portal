var current = $("#current").text();
var currentNum = Number(current);

var dataset = [5, 10, 13, 19, 21, 25, 22, 18, 15, 13,
                11, 12, 15, 20, 18, 17, 16, 18, 23, 25];

var w = 500;
var h = 100;

var svg = d3.select("#container")
        .append("svg")
        .attr("width", w)
        .attr("height", h);

//create the rectangles used for the bar chart
svg.selectAll("rect")
   .data(dataset)
   .enter()
   .append("rect")
   .attr("x", function (d, i) {
       return i * 21;
   })
   //here we need to subtract from the height because SVG starts
   //in the top left corner
   .attr("y", function (d) {
       return h - (d * 4);
   })
   .attr("width", 20)
   .attr("height", function (d) {
       return d * 4;
   })
   .attr("fill", function (d) {
       return "rgb(" + (d * 8) + ", 0, 0)";
   });